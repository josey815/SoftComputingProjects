using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSPBenchmark;

namespace R10546040THKuoAss09
{
    public class AntSystem : AntColonyOptimizer
    {
        public AntSystem(int numberOfVariables, OptimizationType opType, ObjectiveFunction objFun, double[,] heuMatrix) : base(numberOfVariables, opType, objFun, heuMatrix)
        {

        }

        protected override void UpdatePheromoneMatrix()
        {
            // evaporate pheromone
            for (int i = 0; i < NumberOfVariables; i++)
            {
                for (int j = 0; j < NumberOfVariables; j++)
                {
                    PheromoneMatrix[i, j] = PheromoneMatrix[i, j] * (1 - EvaporationRate);
                }
            }
            // drop pheromone on each ant's trail
            for (int i = 0; i < NumberOfAnts; i++)
            {
                double addAmount = 1 / TSPBenchmarkProblem.ComputeObjectiveValue(Solutions[i]);
                for (int j = 0; j < NumberOfVariables-1; j++)
                {
                    PheromoneMatrix[Solutions[i][j], Solutions[i][j + 1]] += addAmount;
                    PheromoneMatrix[Solutions[i][j+1], Solutions[i][j]] += addAmount;
                }
            }
        }

        protected override void AllAntCreateSolution()
        {
            if (IterationCount == 0)
            {
                // create initial solution and assign to so-far-the-best
                for (int i = 0; i < NumberOfVariables; i++)
                {
                    SoFarTheBestSolution[i] = CandidateCities[i];
                }

                SoFarTheBestObjective = TSPBenchmarkProblem.ComputeObjectiveValue(SoFarTheBestSolution);
                UpdatePheromoneMatrix();
            }

            int selectNum;
            int temp;
            double heuristicValue;
            double pheromoneValue;
            // default operations
            for (int i = 0; i < NumberOfAnts; i++)
            {
                for (int j = 0; j < NumberOfVariables; j++)
                {
                    double randomNum = randomizer.NextDouble();
                    if (j == 0) // pick starting city
                    {
                        selectNum = (int)(randomNum * NumberOfVariables);
                        Solutions[i][j] = CandidateCities[selectNum];
                        temp = CandidateCities[selectNum];
                        CandidateCities[selectNum] = CandidateCities[NumberOfVariables - 1];
                        CandidateCities[NumberOfVariables - 1] = temp;
                    }
                    else
                    {
                        // deterministic selection
                        // calculate fitness value
                        double bestFit = 0;
                        int nextPick = 0;
                        for (int k = 0; k < NumberOfVariables - j; k++)
                        {
                            pheromoneValue = Math.Pow(PheromoneMatrix[CandidateCities[NumberOfVariables - j], CandidateCities[k]], PheromoneFactor);
                            heuristicValue = Math.Pow((1 / (HeuristicMatrix[CandidateCities[NumberOfVariables - j], CandidateCities[k]])), HeuristicFactor);
                            Fitness[k] = pheromoneValue * heuristicValue;
                            if (Fitness[k] > bestFit)
                            {
                                bestFit = Fitness[k];
                                nextPick = k;
                            }
                        }
                        // select next city
                        Solutions[i][j] = CandidateCities[nextPick];
                        temp = CandidateCities[nextPick];
                        CandidateCities[nextPick] = CandidateCities[NumberOfVariables - 1 - j];
                        CandidateCities[NumberOfVariables - 1 - j] = temp;
                    }
                    // update pheromone matrix if step-wise pheromone update strategy is use
                    // UpdatePheromoneMatrix();
                }
                // update pheromone matrix if trail-wise pheromone update strategy is use
                //UpdatePheromoneMatrix();
            }
        }
    }
}