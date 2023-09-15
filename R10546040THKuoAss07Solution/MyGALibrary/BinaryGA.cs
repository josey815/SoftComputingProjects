using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGALibrary
{
    public class BinaryGA : GenericGASolver<byte>
    {
        public BinaryGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<byte> objectiveEvaluationFunction) : 
            base(numberOfVariables, optimizationType, objectiveEvaluationFunction)
        {

        }

        protected override void InitializePopulation()
        {
            for (int r = 0; r < populationSize; r++)
            {
                for (int c = 0; c < numberOfGenes; c++)
                {
                    chromosomes[r][c] = (byte)randomizer.Next(2);
                }
            }
        }

        public override void GenerateAPairOfCrossoveredChildren(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            int cutPos = randomizer.Next(numberOfGenes);
            switch (CrossOverCut)
            {
                case CutMode.OnePointCut:
                    for (int c = 0; c < numberOfGenes; c++)
                    {
                        if (c < cutPos)
                        {
                            chromosomes[child1Idx][c] = chromosomes[fatherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[motherIdx][c];
                        }
                        else
                        {
                            chromosomes[child1Idx][c] = chromosomes[motherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[fatherIdx][c];
                        }
                    }
                    break;
                case CutMode.TwoPointCut:
                    int cutPos2 = randomizer.Next(numberOfGenes);
                    int firstPos = Math.Min(cutPos, cutPos2);
                    int secondPos = Math.Max(cutPos, cutPos2);
                    for (int c = 0; c < numberOfGenes; c++)
                    {
                        if (c < firstPos)
                        {
                            chromosomes[child1Idx][c] = chromosomes[fatherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[motherIdx][c];
                        }
                        else if (c > firstPos && c < secondPos)
                        {
                            chromosomes[child1Idx][c] = chromosomes[motherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[fatherIdx][c];
                        }
                        else
                        {
                            chromosomes[child1Idx][c] = chromosomes[fatherIdx][c];
                            chromosomes[child2Idx][c] = chromosomes[motherIdx][c];
                        }
                    }
                    break;
                case CutMode.NPointCut:
                    int numberOfCutPoints = 2 + randomizer.Next(numberOfGenes / 4);
                    int currentCutPos = 0;

                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        cutPositionFlags[i] = false;
                    }
                    for ( int i = 0; i < numberOfCutPoints; i++)
                    {
                        int pos = randomizer.Next(numberOfGenes);
                        cutPositionFlags[pos] = true;
                    }

                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        if (cutPositionFlags[i]) currentCutPos++;

                        if (currentCutPos % 2 == 0)
                        {
                            chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                            chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
                        }
                        else
                        {
                            chromosomes[child1Idx][i] = chromosomes[motherIdx][i];
                            chromosomes[child2Idx][i] = chromosomes[fatherIdx][i];
                        }
                    }
                    break;
            }
        }

        public override void GenerateAGeneBasedMutatedChild(int parentIdx, int childIdx)
        {
            // refer to mutatedFlags to mutate gene values
            for (int c = 0; c < numberOfGenes; c++)
            {
                chromosomes[childIdx][c] = chromosomes[parentIdx][c];

                if (mutatedFlags[parentIdx][c] == true)
                {
                    if (chromosomes[parentIdx][c] == 0)
                    {
                        chromosomes[childIdx][c] = 1;
                    }
                    else
                    {
                        chromosomes[childIdx][c] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// PopulationSize-based mutation
        /// </summary>
        /// <param name="parentIdx"></param>
        /// <param name="childIdx"></param>
        public override void GenerateAMutatedChild(int parentIdx, int childIdx)
        {
            // only mutate one gene
            int mutatePos = randomizer.Next(numberOfGenes);
            for (int c = 0; c < numberOfGenes; c++)
            {
                chromosomes[childIdx][c] = chromosomes[parentIdx][c];
            }
            if (chromosomes[parentIdx][mutatePos] == 0)
            {
                chromosomes[childIdx][mutatePos] = 1;
            }
            else
            {
                chromosomes[childIdx][mutatePos] = 0;
            }
        }
    }
}