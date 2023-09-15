using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using TSPBenchmark;

namespace R10546040THKuoAss09
{
    // public delegate double HeuristicValueFunction(int i, int j);
    public delegate double ObjectiveFunction(int[] solution);
    public enum OptimizationType
    {
        Minimization,
        Maximization
    }
    
    public class AntColonyOptimizer
    {
        #region DATA FIELDS
        protected double[,] pheromoneMatrix;
        protected double[,] heuristicMatrix;
        protected int[] candidateCities;
        protected double[] fitness;
        protected int[][] solutions;
        protected double pheromoneFactor = 1.0;
        protected double heuristicFactor = 3.0;
        protected int numberOfAnts = 40;
        protected int iterationLimit = 500;
        protected double initialPheromone = 0.001;
        protected double pheromoneDropAmount = 0.002;
        protected double dropMultiplier = TSPBenchmarkProblem.GlobalShorestLength4TSP;
        protected double evaporationRate = 0.1;
        protected double threshold = 0.8;
        protected int iterationCount = 0;
        protected double[] objectives;
        protected int numberOfVariables = 10;
        protected int[] soFarTheBestSolution;
        protected double soFarTheBestObjective;
        protected double iterationObjectiveAverage;
        protected double iterationBestObjective;
        protected int[] tempCities;
        protected OptimizationType optimizationMode = OptimizationType.Minimization;
        protected ObjectiveFunction objFunction;
        protected Random randomizer = new Random();
        //HeuristicValueFunction heuristicFunction;
        #endregion

        #region PROPERTIES
        [Category("Execution")]
        public int IterationLimit 
        { get => iterationLimit;
            set 
            {
                if (value > 0) iterationLimit = value;
            }
        }

        [Browsable(false)]
        [Category("Execution")]
        public int IterationCount { get => iterationCount; }

        [Browsable(false)]
        [Category("Execution")]
        public double IterationObjectiveAverage { get => iterationObjectiveAverage; set => iterationObjectiveAverage = value; }

        [Browsable(false)]
        [Category("Execution")]
        public double IterationBestObjective { get => iterationBestObjective; set => iterationBestObjective = value; }

        [Browsable(false)]
        [Category("Execution")]
        public double SoFarTheBestObjective { get => soFarTheBestObjective; set => soFarTheBestObjective = value; }

        [Browsable(false)]
        [Category("Execution")]
        public int[] SoFarTheBestSolution { get => soFarTheBestSolution; set => soFarTheBestSolution = value; }

        [Category("Execution")]
        [Browsable(false)]
        public int[][] Solutions { get => solutions; set => solutions = value; }
        
        [Category("Execution")]
        [Browsable(false)]
        public double[] Objectives { get => objectives; set => objectives = value; }

        [Category("Execution")]
        [Browsable(false)]
        public int[] SoFarTheBestSolution1 { get => soFarTheBestSolution; set => soFarTheBestSolution = value; }


        [Category("ACO Setting")]
        public double PheromoneFactor 
        { get => pheromoneFactor;
            set 
            { 
                if (value > 0) pheromoneFactor = value;
            } 
        }

        [Category("ACO Setting")]
        public double HeuristicFactor 
        { get => heuristicFactor;
            set
            {
                if (value > 0) heuristicFactor = value;
            }
        }

        [Category("ACO Setting")]
        public int NumberOfAnts 
        { get => numberOfAnts;
            set
            {
                if (value > 0) numberOfAnts = value;
            }
        }

        [Category("ACO Setting")]
        public double InitialPheromone 
        { get => initialPheromone;
            set
            {
                if (value > 0) initialPheromone = value;
            } 
        }

        [Category("ACO Setting")]
        public double PheromoneDropAmount 
        { get => pheromoneDropAmount;
            set
            {
                if (value > 0) pheromoneDropAmount = value;
            }
        }

        [Category("ACO Setting")]
        public double EvaporationRate 
        { get => evaporationRate;
            set
            {
                if (value > 0 && value < 1) evaporationRate = value;
            } 
        }

        [Category("ACO Setting")]
        public double Threshold 
        { get => threshold; 
            set
            {
                if (value >= 0.5 && value <= 1.0) threshold = value;
            }
        }

        [Category("ACO Setting")]
        [Browsable(false)]
        public int NumberOfVariables { get => numberOfVariables; set => numberOfVariables = value; }
        
        [Category("ACO Setting")]
        [Browsable(false)]
        public double[,] PheromoneMatrix { get => pheromoneMatrix; set => pheromoneMatrix = value; }
        [Category("ACO Setting")]
        [Browsable(false)]
        public double DropMultiplier { get => dropMultiplier; set => dropMultiplier = value; }
        [Category("Execution")]
        [Browsable(false)]
        public int[] CandidateCities { get => candidateCities; set => candidateCities = value; }
        [Category("Execution")]
        [Browsable(false)]
        public double[] Fitness { get => fitness; set => fitness = value; }
        [Category("Execution")]
        [Browsable(false)]
        public double[,] HeuristicMatrix { get => heuristicMatrix; set => heuristicMatrix = value; }
        #endregion

        #region CTOR

        public AntColonyOptimizer(int numberOfVariables, OptimizationType opType, ObjectiveFunction objFun, double[,] heuMatrix)
        {
            this.numberOfVariables = numberOfVariables;
            // set up heuristic matrix
            if (heuMatrix == null || heuMatrix.GetLength(0) != numberOfVariables || heuMatrix.GetLength(1) != numberOfVariables) throw new Exception("No heuristic matrix or dimension is not matched.");
            heuristicMatrix = heuMatrix;

            optimizationMode = opType;
            objFunction = objFun;

            soFarTheBestSolution = new int[this.numberOfVariables];
            candidateCities = new int[numberOfVariables];
            fitness = new double[numberOfVariables];
            pheromoneMatrix = new double[numberOfVariables,numberOfVariables];
            tempCities = new int[numberOfVariables];
        }
        #endregion

        #region PUBLIC FUNCTIONS
        // public functions
        public void Reset()
        {
            InitializePheromoneMatrix();
            iterationCount = 0;

            // numberOfAnts depended array memory allocation
            solutions = new int[numberOfAnts][];
            for (int i = 0; i < numberOfAnts; i++)
            {
                solutions[i] = new int[numberOfVariables];
            }
            objectives = new double[numberOfAnts];

            // initialize candidate cities
            for (int i = 0; i < numberOfVariables; i++)
            {
                candidateCities[i] = i;
            }

            // shuffle cities order
            for (int i = 0; i < numberOfVariables; i++)
            {
                int pick_1 = randomizer.Next(numberOfVariables);
                int pick_2 = randomizer.Next(numberOfVariables);
                tempCities[i] = candidateCities[pick_1];
                candidateCities[pick_1] = candidateCities[pick_2];
                candidateCities[pick_2] = tempCities[i];
            }
        }

        protected virtual void InitializePheromoneMatrix()
        {
            for (int i = 0; i < numberOfVariables; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    pheromoneMatrix[i, j] = InitialPheromone;
                }
            }
        }

        public void RunOneIteration()
        {
            AllAntCreateSolution();
            EvaluateObjectiveAndUpdateSoFarTheBest();
            UpdatePheromoneMatrix();
            iterationCount++;
        }

        public void RunToEnd()
        {
            do
            {
                RunOneIteration();
            } while (iterationCount < iterationLimit);
        }

        protected virtual void UpdatePheromoneMatrix()
        {
            throw new NotImplementedException();
        }

        protected virtual void EvaluateObjectiveAndUpdateSoFarTheBest()
        {
            // evaluate objectives
            int iterationBestIdx = -1;
            double sumOfObjectiveValues = 0;
            if (optimizationMode == OptimizationType.Maximization) // Maximization
            {
                iterationBestObjective = Double.MinValue;
                for (int i = 0; i < numberOfAnts; i++)
                {
                    // calculate objective value
                    objectives[i] = TSPBenchmarkProblem.ComputeObjectiveValue(solutions[i]);
                    sumOfObjectiveValues += objectives[i];

                    // update iteration-best
                    if (objectives[i] > iterationBestObjective)
                    {
                        iterationBestObjective = objectives[i];
                        iterationBestIdx = i;
                    }
                }
                // check if iteration best is better than so-far-the-best
                if (iterationBestObjective > soFarTheBestObjective)
                {
                    //update so-far-the-best objective and solution
                    soFarTheBestObjective = iterationBestObjective;
                    for (int k = 0; k < numberOfVariables; k++)
                    {
                        soFarTheBestSolution[k] = solutions[iterationBestIdx][k];
                    }
                }
            }
            else // Minimization
            {
                iterationBestObjective = Double.MaxValue;
                for (int i = 0; i < numberOfAnts; i++)
                {
                    objectives[i] = TSPBenchmarkProblem.ComputeObjectiveValue(solutions[i]);
                    sumOfObjectiveValues += objectives[i];

                    // update iteration-best
                    if (objectives[i] < iterationBestObjective)
                    {
                        iterationBestObjective = objectives[i];
                        iterationBestIdx = i;
                    }
                }
                // check if iteration best is better than so-far-the-best
                if (iterationBestObjective < soFarTheBestObjective)
                {
                    //update so-far-the-best objective and solution
                    soFarTheBestObjective = iterationBestObjective;
                    for (int k = 0; k < numberOfVariables; k++)
                    {
                        soFarTheBestSolution[k] = solutions[iterationBestIdx][k];
                    }
                }
            }
            // update iteration average
            iterationObjectiveAverage = sumOfObjectiveValues / numberOfAnts;
        }

        protected virtual void AllAntCreateSolution()
        {
            if (iterationCount == 0)
            {
                // create initial solution and assign to so-far-the-best
                for (int i = 0; i < numberOfVariables; i++)
                {
                    soFarTheBestSolution[i] = candidateCities[i];
                }

                soFarTheBestObjective = TSPBenchmarkProblem.ComputeObjectiveValue(soFarTheBestSolution);
                UpdatePheromoneMatrix();
            }
            
            int selectNum;
            int temp;
            double heuristicValue;
            double pheromoneValue;
            // default operations
            for (int i = 0; i < numberOfAnts; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    double randomNum = randomizer.NextDouble();
                    if (j == 0) // pick starting city
                    {
                        selectNum = (int)(randomNum * numberOfVariables);
                        solutions[i][j] = candidateCities[selectNum];
                        temp = candidateCities[selectNum];
                        candidateCities[selectNum] = candidateCities[numberOfVariables - 1];
                        candidateCities[numberOfVariables - 1] = temp;
                    }
                    else
                    {
                        if (randomNum > Threshold) // stochastic selection
                        {
                            // calculate fitness value
                            int nextPick = -1;
                            double[] fitSum = new double[numberOfVariables];
                            double fitnessSum = 0;
                            for (int k = 0; k < numberOfVariables - j; k++)
                            {
                                pheromoneValue = Math.Pow(pheromoneMatrix[candidateCities[numberOfVariables - j], candidateCities[k]], pheromoneFactor);
                                heuristicValue = Math.Pow(((heuristicMatrix[candidateCities[numberOfVariables - j], candidateCities[k]])), heuristicFactor);
                                fitness[k] = pheromoneValue * heuristicValue;
                                fitnessSum += fitness[k];
                                fitSum[k] = fitnessSum;
                            }
                            selectNum = (int)(fitnessSum * randomNum);
                            for (int s = 0; s < numberOfVariables - j; s++)
                            {
                                if (selectNum > fitSum[s])
                                {
                                    nextPick = s;
                                }
                            }
                            nextPick += 1;
                            // select next city
                            solutions[i][j] = candidateCities[nextPick];
                            temp = candidateCities[nextPick];
                            candidateCities[nextPick] = candidateCities[numberOfVariables - 1 - j];
                            candidateCities[numberOfVariables - 1 - j] = temp;
                        }
                        else // deterministic selection
                        {
                            // calculate fitness value
                            double bestFit = 0;
                            int nextPick = 0;
                            for (int k = 0; k < numberOfVariables - j; k++)
                            {
                                pheromoneValue = Math.Pow(pheromoneMatrix[candidateCities[numberOfVariables-j], candidateCities[k]], pheromoneFactor);
                                heuristicValue = Math.Pow(((heuristicMatrix[candidateCities[numberOfVariables - j], candidateCities[k]])), heuristicFactor);
                                fitness[k] = pheromoneValue * heuristicValue;
                                if (fitness[k] > bestFit)
                                {
                                    bestFit = fitness[k];
                                    nextPick = k;
                                }
                            }
                            // select next city
                            solutions[i][j] = candidateCities[nextPick];
                            temp = candidateCities[nextPick];
                            candidateCities[nextPick] = candidateCities[numberOfVariables - 1 - j];
                            candidateCities[numberOfVariables - 1 - j] = temp;
                        }
                    }
                    // update pheromone matrix if step-wise pheromone update strategy is use
                    //UpdatePheromoneMatrix();
                }
                // update pheromone matrix if trail-wise pheromone update strategy is use
                //UpdatePheromoneMatrix();
            }
        }
        #endregion
    }
}