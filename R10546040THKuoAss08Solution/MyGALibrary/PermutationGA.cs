using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyGALibrary
{
    public class PermutationGA : GenericGASolver<int>
    {
        int[] temp1;
        int[] temp2;
        int[] temp3;
        int[] temp4;
        int[] temp5;
        int[] temp6;
        // int[] populationSizeDependedTempArray;
        public PermutationCrossoverOperator CrossoverOperator { get; set; } = PermutationCrossoverOperator.PartialMappedCrossover;
        public PermutationMutationOperator MutationOperator { get; set; } = PermutationMutationOperator.InversionMutation;
        public PermutationGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<int> objectiveEvaluationFunction, Panel host = null) : 
            base(numberOfVariables, optimizationType, objectiveEvaluationFunction, host)
        {
            temp1 = new int[numberOfVariables];
            temp2 = new int[numberOfVariables];
            temp3 = new int[numberOfVariables];
            temp4 = new int[numberOfVariables];
            temp5 = new int[numberOfVariables];
            temp6 = new int[numberOfVariables*2];
        }
        // helping function
        void ShuffleToInitializeChromosome(int r)
        {
            // fill in ordered number
            for (int c = 0; c < numberOfGenes; c++)
            {
                chromosomes[r][c] = c;   
            }
            // shuffle ordered number
            for (int c = 0; c < numberOfGenes; c++)
            {
                int pos1 = randomizer.Next(numberOfGenes);
                int pos2 = randomizer.Next(numberOfGenes);
                temp1[c] = chromosomes[r][pos2];
                chromosomes[r][pos2] = chromosomes[r][pos1];
                chromosomes[r][pos1] = temp1[c];
            }
        }

        protected override void InitializePopulation()
        {
            for (int r = 0; r < populationSize; r++)
            {
                ShuffleToInitializeChromosome(r);
            }
        }

        public override void GenerateAPairOfCrossoveredChildren(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            switch (CrossoverOperator)
            {
                case PermutationCrossoverOperator.PartialMappedCrossover:
                    PMX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
                case PermutationCrossoverOperator.OrderCrossover:
                    OX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
                case PermutationCrossoverOperator.PositionBasedCrossover:
                    PBX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
                case PermutationCrossoverOperator.OrderBasedCrossover:
                    OBX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
                case PermutationCrossoverOperator.CycleCrossover:
                    CX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
                case PermutationCrossoverOperator.SubtourExchangeCrossover:
                    STX(fatherIdx, motherIdx, child1Idx, child2Idx);
                    break;
            }
        }

        public override void GenerateAMutatedChild(int parentIdx, int childIdx)
        {
            for (int c = 0; c < numberOfGenes; c++)
            {
                chromosomes[childIdx][c] = chromosomes[parentIdx][c];
            }
            switch (MutationOperator)
            {
                case PermutationMutationOperator.InversionMutation:
                    InversionMutation(parentIdx, childIdx);
                    break;
                case PermutationMutationOperator.InsertionMutation:
                    InsertionMutation(parentIdx, childIdx);
                    break;
                case PermutationMutationOperator.DisplacementMutation:
                    DisplacementMutation(parentIdx, childIdx);
                    break;
                case PermutationMutationOperator.ReciprocalExchangeMutation:
                    ReciprocalExchangeMutation(parentIdx, childIdx);
                    break;
                case PermutationMutationOperator.SwappedMutation:
                    SwappedMutation(parentIdx, childIdx);
                    break;
            }
        }
        #region MUTATION OPERATORS
        // swapped exchange mutation
        private void SwappedMutation(int parentIdx, int childIdx)
        {
            int subLength = randomizer.Next(numberOfGenes/4);
            int pos1 = randomizer.Next(numberOfGenes - 2 * subLength);
            int pos2 = randomizer.Next(pos1 + subLength, numberOfGenes - subLength);

            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i < pos1)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                }else if (i >= pos1 && i < pos1 + subLength)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i + pos2 - pos1];
                }else if (i >= pos1 + subLength && i < pos2)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                }else if (i >= pos2 && i < pos2 + subLength)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i - pos2 + pos1];
                }
                else
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                }
            }
        }

        // reciprocal exchange mutation
        private void ReciprocalExchangeMutation(int parentIdx, int childIdx)
        {
            int pos1 = randomizer.Next(numberOfGenes);
            int pos2 = randomizer.Next(numberOfGenes);
            // make sure pos1 is less then pos2
            if (pos1 > pos2)
            {
                temp1[0] = pos2;
                pos2 = pos1;
                pos1 = temp1[0];
            }
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i < pos1)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                }else if (i == pos1)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][pos2];
                }else if (i > pos1 && i < pos2)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                }else if (i == pos2)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][pos1];
                }
                else
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                }
            }
        }

        // displacement mutation
        private void DisplacementMutation(int parentIdx, int childIdx)
        {
            int pos1 = randomizer.Next(numberOfGenes);
            int pos2 = randomizer.Next(numberOfGenes);
            // make sure pos1 is less then pos2
            if (pos1 > pos2)
            {
                temp1[0] = pos2;
                pos2 = pos1;
                pos1 = temp1[0];
            }
            int subLength = pos2 - pos1;
            // determine insert position
            int insertPos = randomizer.Next(numberOfGenes - subLength);
            int minPos = Math.Min(pos1, insertPos);
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (minPos == pos1)
                {
                    if(i < pos1)
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                    }else if (i >= pos1 && i < insertPos)
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i+subLength];
                    }else if (i >= insertPos && i < insertPos + subLength)
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i-insertPos+pos1];
                    }
                    else
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                    }
                }
                else
                {
                    if (i < insertPos)
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                    }else if (i >= insertPos && i < insertPos + subLength)
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i + pos1 - insertPos];
                    }else if (i >= insertPos + subLength && i < pos2)
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i - subLength];
                    }
                    else
                    {
                        chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                    }
                }
            }
        }

        // insertion mutation
        private void InsertionMutation(int parentIdx, int childIdx)
        {
            int pos1 = randomizer.Next(numberOfGenes);
            int pos2 = randomizer.Next(numberOfGenes);
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i < pos1)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                }else if (i > pos2)
                {
                    chromosomes[childIdx][i] = chromosomes[parentIdx][i];
                }
                else if (i == pos1)
                {
                    chromosomes[childIdx][pos2] = chromosomes[parentIdx][i];
                }
                else
                {
                    chromosomes[childIdx][i-1] = chromosomes[parentIdx][i];
                }
            }
        }

        // inversion mutation
        private void InversionMutation(int parentIdx, int childIdx)
        {
            int pos1 = randomizer.Next(numberOfGenes);
            int pos2 = randomizer.Next(numberOfGenes);
            for (int i = 0; i < numberOfGenes; i++)
            {
                chromosomes[childIdx][i] = chromosomes[parentIdx][i];
            }
            // make sure pos1 is less then pos2
            if (pos1 > pos2)
            {
                temp1[0] = pos2;
                pos2 = pos1;
                pos1 = temp1[0];
            }
            // fill in number inversely
            for (int i = pos1; i < pos2; i++)
            {
                chromosomes[childIdx][i] = chromosomes[parentIdx][pos1+pos2-i-1];
            }
        }
        #endregion

        #region CROSSOVER OPERATORS
        // sub-tour crossover
        private void STX(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            // determine subtour position
            int pos1 = randomizer.Next(numberOfGenes);
            int pos2 = randomizer.Next(numberOfGenes);
            // make sure pos1 is less then pos2
            if (pos1 > pos2)
            {
                temp1[0] = pos2;
                pos2 = pos1;
                pos1 = temp1[0];
            }
            // determine sublength
            int subLength = pos2 - pos1;
            // copy parent to proto-child
            for (int i = 0; i < numberOfGenes; i++)
            {
                temp1[i] = chromosomes[fatherIdx][i];
                temp2[i] = chromosomes[motherIdx][i];
                temp3[i] = -1;
            }
            // find father's subtour corresponding position in mother
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i >= pos1 && i < pos2)
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp1[i] == temp2[j])
                        {
                            temp3[i] = j;
                            break;
                        }
                    }   
                }
            }

            Array.Sort(temp3);

            // check mother's subtour is reasonable or not
            bool result = true;
            for (int i = 0; i < numberOfGenes-1; i++)
            {
                if (temp3[i] != -1)
                {
                    if (temp3[i+1] != (temp3[i] + 1))
                    {
                        result = false;
                        break;
                    }
                }
            }

            int startIndex = -1;
            if (result == true)
            {
                // find startIndex in mother
                for (int i = 0; i < numberOfGenes; i++)
                {
                    if (temp3[i] != -1)
                    {
                        startIndex = temp3[i];
                        break;
                    }
                }

                // prepare child 1
                for (int i = 0; i < numberOfGenes; i++)
                {
                    if (i >= pos1 && i < pos2)
                    {
                        chromosomes[child1Idx][i] = chromosomes[motherIdx][startIndex];
                        startIndex++;
                    }
                    else
                    {
                        chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                    }
                }

                // find startIndex in mother again
                for (int i = 0; i < numberOfGenes; i++)
                {
                    if (temp3[i] != -1)
                    {
                        startIndex = temp3[i];
                        break;
                    }
                }

                int pos3 = pos1;
                // prepare child 2
                for (int i = 0; i < numberOfGenes; i++)
                {
                    if (i >= startIndex && i < startIndex+subLength)
                    {
                        chromosomes[child2Idx][i] = chromosomes[fatherIdx][pos3];
                        pos3++;
                    }
                    else
                    {
                        chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < numberOfGenes; i++)
                {
                    chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                    chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
                }
            } 
        }

        // cycle crossover
        private void CX(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            // copy parent to proto-child
            for (int i = 0; i < numberOfGenes; i++)
            {
                temp1[i] = chromosomes[fatherIdx][i];
                temp2[i] = chromosomes[motherIdx][i];
                temp5[i] = -1;
                temp6[i] = -1;
            }
            temp5[0] = 0; // cycle1 index container
            temp6[0] = temp1[0]; // cycle1 container
            temp6[1] = temp2[0];
            // find cycle1 in parents
            for (int i = 1; i < numberOfGenes; i++)
            {
                for (int j = 0; j < numberOfGenes; j++)
                {
                    if (temp6[i] == temp1[j])
                    {
                        temp6[i + 1] = temp2[j];
                        temp5[i] = j;
                        break;
                    }
                }
                // check cycle is completed or not
                if (temp6[i + 1] == temp6[0])
                {
                    break;
                }
            }
            // prepare child 1
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (IsContain2(i, temp5))
                {
                    chromosomes[child1Idx][i] = chromosomes[fatherIdx][i];
                }
                else
                {
                    chromosomes[child1Idx][i] = chromosomes[motherIdx][i];
                }
            }
            // prepare child 2
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (IsContain2(i, temp5))
                {
                    chromosomes[child2Idx][i] = chromosomes[motherIdx][i];
                }
                else
                {
                    chromosomes[child2Idx][i] = chromosomes[fatherIdx][i];
                }
            }
        }

        // order-based crossover
        private void OBX(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            // copy parent to proto-child
            for (int i = 0; i < numberOfGenes; i++)
            {
                temp1[i] = chromosomes[fatherIdx][i];
                temp2[i] = chromosomes[motherIdx][i];
                temp3[i] = chromosomes[fatherIdx][i];
                temp4[i] = chromosomes[motherIdx][i];
            }
            // determine number of selected genes
            int numOfSelectedGenes = randomizer.Next(numberOfGenes / 3);
            int[] arrayPos = new int[numOfSelectedGenes];
            int[] arrayPos2 = new int[numOfSelectedGenes];
            for (int i = 0; i < numOfSelectedGenes; i++)
            {
                arrayPos[i] = -1;
                arrayPos2[i] = -1;
            }
            for (int i = 0; i < numOfSelectedGenes; i++)
            {
                int pos1 = randomizer.Next(numberOfGenes);
                if (!IsContain2(pos1, arrayPos))
                {
                    arrayPos[i] = pos1;

                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp1[pos1] == temp2[j])
                        {
                            temp2[j] = -1; // turn off this number
                            arrayPos2[i] = j;
                        }
                        if (temp4[j] == temp3[pos1])
                        {
                            temp3[pos1] = -1; // turn off this number
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            Array.Sort(arrayPos);
            Array.Sort(arrayPos2);

            int count = 0;
            for (int i = 0; i < numOfSelectedGenes; i++)
            {
                if (arrayPos[i] != -1)
                {
                    count = i;
                    break;
                }
            }

            int count2 = 0;
            for (int i = 0; i < numOfSelectedGenes; i++)
            {
                if (arrayPos2[i] != -1)
                {
                    count2 = i;
                    break;
                }
            }

            // prepare child 1
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (IsContain2(i, arrayPos2))
                {
                    chromosomes[child1Idx][i] = temp1[arrayPos[count]];
                    count++;
                }
                else
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp2[j] != -1)
                        {
                            chromosomes[child1Idx][i] = temp2[j];
                            temp2[j] = -1;
                            break;
                        }
                    }
                }
            }

            // prepare child 2
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (IsContain2(i, arrayPos))
                {
                    chromosomes[child2Idx][i] = temp4[arrayPos2[count2]];
                    count2++;
                }
                else
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp3[j] != -1)
                        {
                            chromosomes[child2Idx][i] = temp3[j];
                            temp3[j] = -1;
                            break;
                        }
                    }
                }
            }
        }

        // position-based crossover
        private void PBX(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            // copy parent to proto-child
            for (int i = 0; i < numberOfGenes; i++)
            {
                temp1[i] = chromosomes[fatherIdx][i];
                temp2[i] = chromosomes[motherIdx][i];
                temp3[i] = chromosomes[fatherIdx][i];
                temp4[i] = chromosomes[motherIdx][i];
            }
            // determine number of selected genes
            int numOfSelectedGenes = randomizer.Next(numberOfGenes/3);
            int[] arrayPos = new int[numOfSelectedGenes];
            for (int i = 0; i < numOfSelectedGenes; i++)
            {
                arrayPos[i] = -1;
            }
            for (int i = 0; i < numOfSelectedGenes; i++)
            {
                int pos1 = randomizer.Next(numberOfGenes);
                if (!IsContain2(pos1, arrayPos)) 
                {
                    arrayPos[i] = pos1;
                }
                else
                {
                    continue;
                }
                for (int j = 0; j < numberOfGenes; j++)
                {
                    if (temp1[pos1] == temp2[j]) temp2[j] = -1; // turn off this number
                    if (temp4[pos1] == temp3[j]) temp3[j] = -1; // turn off this number
                }
            }
            // prepare child 1
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (IsContain2(i, arrayPos))
                {
                    chromosomes[child1Idx][i] = temp1[i];
                }
                else
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp2[j] != -1)
                        {
                            chromosomes[child1Idx][i] = temp2[j];
                            temp2[j] = -1;
                            break;
                        }
                    }
                }
            }
            // prepare child 2
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (IsContain2(i, arrayPos))
                {
                    chromosomes[child2Idx][i] = temp4[i];
                }
                else
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp3[j] != -1)
                        {
                            chromosomes[child2Idx][i] = temp3[j];
                            temp3[j] = -1;
                            break;
                        }
                    }
                }
            }
        }

        private bool IsContain2(int k, int[] arrayPos)
        {
            bool result = false;
            for (int i = 0; i < arrayPos.Length; i++)
            {
                if (k == arrayPos[i])
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        // order crossover 
        private void OX(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            int pos1 = randomizer.Next(numberOfGenes);
            int pos2 = randomizer.Next(numberOfGenes);
            // make sure pos1 is less then pos2
            if (pos1 > pos2)
            {
                temp1[0] = pos2;
                pos2 = pos1;
                pos1 = temp1[0];
            }
            // copy parent to proto-child
            for (int i = 0; i < numberOfGenes; i++)
            {
                temp1[i] = chromosomes[fatherIdx][i];
                temp2[i] = chromosomes[motherIdx][i];
            }
            // tag father's gene position with respect to mother's gene (by setting num = -1)
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i >= pos1 && i < pos2)
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp1[i] == temp2[j]) temp2[j] = -1;
                    }
                }
            }
            // prepare child 1
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i < pos1)
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp2[j] != -1)
                        {
                            chromosomes[child1Idx][i] = temp2[j]; // copy to child 1
                            temp2[j] = -1; // turn off this number
                            break;
                        }
                    }
                }else if (i >= pos1 && i < pos2)
                {
                    chromosomes[child1Idx][i] = temp1[i];
                }else
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp2[j] != -1)
                        {
                            chromosomes[child1Idx][i] = temp2[j];
                            temp2[j] = -1;
                            break;
                        }
                    }
                }
            }
            // copy parent to proto-child again
            for (int i = 0; i < numberOfGenes; i++)
            {
                temp1[i] = chromosomes[fatherIdx][i];
                temp2[i] = chromosomes[motherIdx][i];
            }
            // tag mother's gene position with respect to father's gene (by setting num = -1)
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i >= pos1 && i < pos2)
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp2[i] == temp1[j]) temp1[j] = -1;
                    }
                }
            }
            // prepare child 2
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i < pos1)
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp1[j] != -1)
                        {
                            chromosomes[child2Idx][i] = temp1[j]; // copy to child 2
                            temp1[j] = -1; // turn off this number
                            break;
                        }
                    }
                }
                else if (i >= pos1 && i < pos2)
                {
                    chromosomes[child2Idx][i] = temp2[i];
                }
                else
                {
                    for (int j = 0; j < numberOfGenes; j++)
                    {
                        if (temp1[j] != -1)
                        {
                            chromosomes[child2Idx][i] = temp1[j];
                            temp1[j] = -1;
                            break;
                        }
                    }
                }
            }
        }

        // partial-mapped crossover
        private void PMX(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            int pos1 = randomizer.Next(numberOfGenes);
            int pos2 = randomizer.Next(numberOfGenes);
            // make sure pos1 is less then pos2
            if (pos1 > pos2)
            {
                temp1[0] = pos2;
                pos2 = pos1;
                pos1 = temp1[0];
            }
            // prepare proto-child
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i >= pos1 && i < pos2)
                {
                    temp1[i] = chromosomes[motherIdx][i];
                    temp2[i] = chromosomes[fatherIdx][i];
                }
                else
                {
                    temp1[i] = chromosomes[fatherIdx][i];
                    temp2[i] = chromosomes[motherIdx][i];
                }
            }
            // prepare map
            int cutLength = pos2 - pos1;
            int[][] map = new int[cutLength][];
            for (int i = 0; i < cutLength; i++)
            {
                map[i] = new int[2];
                for (int j = 0; j < 2; j++)
                {
                    map[i][j] = -1;
                }
            }
            for (int i = 0; i < cutLength; i++)
            {
                map[i][0] = temp1[i+pos1];
                map[i][1] = temp2[i+pos1];
            }
            for (int i = 0; i < cutLength; i++)
            {
                for (int j = i+1; j < cutLength; j++)
                {
                    if (map[i][0] == map[j][1])
                    {
                        map[j][1] = map[i][1];
                        map[i][0] = map[i][1] = -1;
                    }
                    if (map[i][1] == map[j][0])
                    {
                        map[j][0] = map[i][0];
                        map[i][0] = map[i][1] = -1;
                    }
                }
            }
            // prepare child
            for (int i = 0; i < numberOfGenes; i++)
            {
                if (i >= pos1 && i < pos2)
                {
                    chromosomes[child1Idx][i] = temp1[i];
                    chromosomes[child2Idx][i] = temp2[i];
                }
                else
                {
                    // prepare child1
                    if (IsContain(temp1[i], map))
                    {
                        for (int j = 0; j < cutLength; j++)
                        {
                            if (temp1[i] == map[j][0])
                            {
                                chromosomes[child1Idx][i] = map[j][1];
                                break;
                            }
                        }
                    }
                    else
                    {
                        chromosomes[child1Idx][i] = temp1[i];
                    }
                    // prepare child2
                    if (IsContain(temp2[i], map))
                    {
                        for (int j = 0; j < cutLength; j++)
                        {
                            if (temp2[i] == map[j][1])
                            {
                                chromosomes[child2Idx][i] = map[j][0];
                                break;
                            }
                        }
                    }
                    else
                    {
                        chromosomes[child2Idx][i] = temp2[i];
                    }
                }
            }
        }

        private bool IsContain(int v, int[][] map)
        {
            bool result = false;
            for (int i = 0; i < map.Length; i++)
            {
                if (v == map[i][0]) result = true;
                if (v == map[i][1]) result = true;
            }
            return result;
        }
        #endregion
    }
}