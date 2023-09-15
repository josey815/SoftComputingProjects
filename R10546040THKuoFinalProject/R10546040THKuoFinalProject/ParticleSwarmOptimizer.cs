using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COP;
using Steema.TeeChart.Styles;

namespace R10546040THKuoAss10
{
    public enum OptimizationMode
    {
        Minimization,
        Maximization
    }
    public delegate double ObjectiveFunction(double[] solution);
    public class ParticleSwarmOptimizer
    {
        #region DATA FIELDS
        COPBenchmark cop;
        protected double[] soFarTheBestSolution;
        protected double soFarTheBestObjective;
        protected double[][] selfBestSolutions;
        double[] selfBestObjective;
        double[] selfObjective;
        double[][] velocity;
        protected double socialFactor = 0.5;
        protected double cognitionFactor = 0.5;
        protected int numberOfParticles = 10;
        protected int numberOfVariables;
        double[] variableLowerBound;
        double[] variableUpperBound;
        protected int iterationCount = 0;
        protected int iterationLimit = 100;
        protected double iterationAverage;
        protected double iterationBestObjective;
        protected double[][] solutions;
        protected OptimizationMode optimizationMode = OptimizationMode.Minimization;
        Random rnd = new Random();
        #endregion

        #region PROPERTIES
        // public properties
        [Browsable(false)]
        [Category("Execution")]
        public double[][] Solutions { get => solutions; }
        [Category("Execution")]
        [Browsable(false)]
        public int IterationCount { get => iterationCount; set => iterationCount = value; }
        [Category("Execution")]
        public int IterationLimit { get => iterationLimit; set => iterationLimit = value; }
        [Category("Execution")]
        [Browsable(false)]
        public double IterationAverage { get => iterationAverage; set => iterationAverage = value; }
        [Category("Execution")]
        [Browsable(false)]
        public double SoFarTheBestObjective { get => soFarTheBestObjective; set => soFarTheBestObjective = value; }
        [Category("Execution")]
        [Browsable(false)]
        public double[] SoFarTheBestSolution { get => soFarTheBestSolution; set => soFarTheBestSolution = value; }
        [Category("PSO Parameters")]
        public int NumberOfParticles { get => numberOfParticles; set => numberOfParticles = value; }
        [Category("PSO Parameters")]
        public double SocialFactor { get => socialFactor; set => socialFactor = value; }
        [Category("PSO Parameters")]
        public double CognitionFactor { get => cognitionFactor; set => cognitionFactor = value; }
        [Browsable(false)]
        [Category("Execution")]
        public double[][] SelfBestSolutions { get => selfBestSolutions; set => selfBestSolutions = value; }
        [Browsable(false)]
        [Category("Execution")]
        public double IterationBestObjective { get => iterationBestObjective; set => iterationBestObjective = value; }
        #endregion

        #region FUNCTIONS
        // public function
        public ParticleSwarmOptimizer(int numberOfVariables, double[] lowerBounds, double[] upperBounds, OptimizationMode opType, ObjectiveFunction objFun)
        {
            // memory allocation for data related to number of variables
            this.numberOfVariables = numberOfVariables;
            variableLowerBound = new double[numberOfVariables];
            variableUpperBound = new double[numberOfVariables];
            for (int i = 0; i < numberOfVariables; i++)
            {
                this.variableLowerBound[i] = lowerBounds[i];
                this.variableUpperBound[i] = upperBounds[i];
            }
            solutions = new double[numberOfParticles][];
            for (int i = 0; i < numberOfParticles; i++)
            {
                solutions[i] = new double[numberOfVariables];
                for (int j = 0; j < numberOfVariables; j++)
                {
                    solutions[i][j] = variableLowerBound[j] + (variableUpperBound[j] - variableLowerBound[j]) * rnd.NextDouble();
                }
            }
        }
        public void Reset(COPBenchmark cop)
        {
            // memory reallocation for data related to number of particles
            solutions = new double[numberOfParticles][];
            selfBestObjective = new double[numberOfParticles];
            selfBestSolutions = new double[numberOfParticles][];
            soFarTheBestSolution = new double[numberOfVariables];
            soFarTheBestObjective = 0;
            iterationCount = 0;
            // assign initial position to each particle
            for (int i = 0; i < numberOfParticles; i++)
            {
                solutions[i] = new double[numberOfVariables];
                selfBestSolutions[i] = new double[numberOfVariables];
                for (int j = 0; j < numberOfVariables; j++)
                {
                    // fill in initial solution and assign to self best solution
                    solutions[i][j] = variableLowerBound[j] + (variableUpperBound[j] - variableLowerBound[j]) * rnd.NextDouble();
                    selfBestSolutions[i][j] = solutions[i][j];
                }
                // calculate particle objective value
                selfBestObjective[i] = cop.GetObjectiveValue(selfBestSolutions[i]);
            }
            // assign so-far-the-best solution and objective
            if (optimizationMode == OptimizationMode.Maximization)
            {
                double bestObj = Double.MinValue;
                int bestIdx = -1;
                for (int i = 0; i < numberOfParticles; i++)
                {
                    if (selfBestObjective[i] > bestObj)
                    {
                        bestObj = selfBestObjective[i];
                        bestIdx = i;
                    }
                }
                soFarTheBestObjective = bestObj;
                for (int i = 0; i < numberOfVariables; i++)
                {
                    soFarTheBestSolution[i] = selfBestSolutions[bestIdx][i];
                }
            }
            else // Minimization
            {
                double bestObj = Double.MaxValue;
                int bestIdx = -1;
                for (int i = 0; i < numberOfParticles; i++)
                {
                    if (selfBestObjective[i] < bestObj)
                    {
                        bestObj = selfBestObjective[i];
                        bestIdx = i;
                    }
                }
                soFarTheBestObjective = bestObj;
                for (int i = 0; i < numberOfVariables; i++)
                {
                    soFarTheBestSolution[i] = selfBestSolutions[bestIdx][i];
                }
            }
        }

        public void RunOneIteration(COPBenchmark cop)
        {
            MoveAllParticlesToNewPosition();
            ComputeObjectivesAndUpdateSoFarTheBest(cop);
            iterationCount++;
        }

        public void RunToEnd()
        {
            do
            {
                RunOneIteration(cop);
            } while (iterationCount < iterationLimit);
        }

        private void MoveAllParticlesToNewPosition()
        {
            double alpha = 0;
            double beta = 0;
            velocity = new double[numberOfParticles][];
            for (int i = 0; i < numberOfParticles; i++)
            {
                velocity[i] = new double[numberOfVariables];
                alpha = cognitionFactor * rnd.NextDouble();
                beta = socialFactor * rnd.NextDouble();
                for (int j = 0; j < numberOfVariables; j++)
                {
                    velocity[i][j] = alpha * (selfBestSolutions[i][j] - solutions[i][j]) + beta * (soFarTheBestSolution[j] - solutions[i][j]);
                    solutions[i][j] += velocity[i][j];
                    if (solutions[i][j] > variableUpperBound[j])
                    {
                        solutions[i][j] = variableUpperBound[j];
                    }else if (solutions[i][j] < variableLowerBound[j])
                    {
                        solutions[i][j] = variableLowerBound[j];
                    }
                    else // keep the same position
                    {
                        solutions[i][j] = solutions[i][j];
                    }
                }
            }
        }

        private void ComputeObjectivesAndUpdateSoFarTheBest(COPBenchmark cop)
        {
            selfObjective = new double[numberOfParticles];
            iterationBestObjective = 0;
            iterationAverage = 0;
            if (optimizationMode == OptimizationMode.Minimization)
            {
                double objSum = 0;
                double bestObj = Double.MaxValue;
                int bestIdx = -1;
                for (int i = 0; i < numberOfParticles; i++)
                {
                    selfObjective[i] = cop.GetObjectiveValue(solutions[i]);
                    objSum += selfObjective[i];
                    // check if current solution is better than iteration best
                    if (selfObjective[i] < bestObj)
                    {
                        bestObj = selfObjective[i];
                        bestIdx = i;
                    }
                    // check if current solution is better than self-best solution
                    if (selfObjective[i] < selfBestObjective[i])
                    {
                        selfBestObjective[i] = selfObjective[i];
                        for (int j = 0; j < numberOfVariables; j++)
                        {
                            selfBestSolutions[i][j] = solutions[i][j];
                        }
                        // check if current solution is better than so-far-the-best solution
                        if (selfObjective[i] < soFarTheBestObjective)
                        {
                            soFarTheBestObjective = selfObjective[i];
                            for (int k = 0; k < numberOfVariables; k++)
                            {
                                soFarTheBestSolution[k] = solutions[i][k];
                            }
                        }
                    }
                }
                iterationBestObjective = bestObj;
                iterationAverage = objSum / numberOfParticles;
            }
            else // Maximization
            {
                double objSum = 0;
                double bestObj = Double.MinValue;
                int bestIdx = -1;
                for (int i = 0; i < numberOfParticles; i++)
                {
                    selfObjective[i] = cop.GetObjectiveValue(solutions[i]);
                    objSum += selfObjective[i];
                    // check if current solution is better than iteration best
                    if (selfObjective[i] > bestObj)
                    {
                        bestObj = selfObjective[i];
                        bestIdx = i;
                    }
                    // check if current solution is better than self-best solution
                    if (selfObjective[i] > selfBestObjective[i])
                    {
                        selfBestObjective[i] = selfObjective[i];
                        for (int j = 0; j < numberOfVariables; j++)
                        {
                            selfBestSolutions[i][j] = solutions[i][j];
                        }
                        // check if current solution is better than so-far-the-best solution
                        if (selfObjective[i] > soFarTheBestObjective)
                        {
                            soFarTheBestObjective = selfObjective[i];
                            for (int k = 0; k < numberOfVariables; k++)
                            {
                                soFarTheBestSolution[k] = solutions[i][k];
                            }
                        }
                    }
                }
                iterationBestObjective = bestObj;
                iterationAverage = objSum / numberOfParticles;
            }
        }
        #endregion
    }
}
