using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSPBenchmark;

namespace R10546040THKuoAss09
{
    public class AntColonySystem : AntColonyOptimizer
    {
        public AntColonySystem(int numberOfVariables, OptimizationType opType, ObjectiveFunction objFun, double[,] heuMatrix) : 
            base(numberOfVariables, opType, objFun, heuMatrix)
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
            // drop pheromone on so-far-the-best trail
            for (int i = 0; i < numberOfVariables - 1; i++)
            {
                PheromoneMatrix[SoFarTheBestSolution[i], SoFarTheBestSolution[i + 1]] += PheromoneDropAmount;
                PheromoneMatrix[SoFarTheBestSolution[i + 1], SoFarTheBestSolution[i]] += PheromoneDropAmount;
            }
        }
    }
}