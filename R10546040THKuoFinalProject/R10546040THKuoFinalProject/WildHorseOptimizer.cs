using COP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040THKuoAss10
{
    public class WildHorseOptimizer
    {
        #region DATA FIELDS
        COPBenchmark cop;
        protected OptimizationMode optimizationMode = OptimizationMode.Minimization;
        Random rnd = new Random();

        protected int numOfPopulation = 30; // number of horses in total
        protected int numOfStallion; // numOfPopulation * PS; number of groups; number of leaders
        protected int numOfFoal; // numOfPopulation - numOfStallion
        protected int[] groupIndex; // each horse belongs to a group, where group number is equal to numOfStallion
        int[] groupNum;
        int[] leaderList;
        protected double crossoverRate = 0.13; // PC : puberty-probability : over means foal(not puberty), lower means puberty(ready to mate)
        protected double stallionRatio = 0.2; // PS : ratio of stallions in population

        protected int numOfVariables; // problem dimension
        double[] variableLowerBound;
        double[] variableUpperBound;

        protected int iterationCount = 0;
        protected int iterationLimit = 100;
        protected double[][] solutions; // position for all populations in each iteration, dimension = numOfPopulation * numOfVariables
        protected double iterationAverage;
        protected double iterationBestObjective;
        protected double[] soFarTheBestSolution;
        protected double soFarTheBestObjective;
        protected double[][] selfBestSolutions;
        double[] selfBestObjective;
        double[] selfObjective;
        #endregion

        #region PROPERTIES
        // WHO Parameters
        [Category("WHO Parameters")]
        public int NumOfPopulation 
        { 
            get => numOfPopulation; 
            set
            {
                if (value > 0)
                {
                    numOfPopulation = value;
                }
            }
        }
        [Browsable(false)]
        [Category("WHO Parameters")]
        public int NumOfStallion 
        { 
            get => numOfStallion; 
            set => numOfStallion = value; 
        }
        [Browsable(false)]
        [Category("WHO Parameters")]
        public int NumOfFoal 
        { 
            get => numOfFoal; 
            set => numOfFoal = value; 
        }
        [Category("WHO Parameters")]
        public double CrossoverRate 
        { 
            get => crossoverRate; 
            set
            {
                if (value >= 0.1 && value <= 0.3)
                {
                    crossoverRate = value;
                }
            }
        }
        [Category("WHO Parameters")]
        public double StallionRatio 
        { 
            get => stallionRatio; 
            set
            {
                if (value > 0 && value <= 0.3)
                {
                    stallionRatio = value;
                }
            }
        }
        [Browsable(false)]
        [Category("WHO Parameters")]
        public int[] GroupIndex { get => groupIndex; set => groupIndex = value; }
        // Execution Parameters
        [Category("Execution")]
        public int IterationLimit 
        { 
            get => iterationLimit; 
            set
            {
                if (value > 0)
                {
                    iterationLimit = value;
                }
            }
        }
        [Browsable(false)]
        [Category("Execution")]
        public int IterationCount { get => iterationCount; set => iterationCount = value; }
        [Browsable(false)]
        [Category("Execution")]
        public double[][] Solutions { get => solutions; set => solutions = value; }
        [Browsable(false)]
        [Category("Execution")]
        public double IterationAverage { get => iterationAverage; set => iterationAverage = value; }
        [Browsable(false)]
        [Category("Execution")]
        public double IterationBestObjective { get => iterationBestObjective; set => iterationBestObjective = value; }
        [Browsable(false)]
        [Category("Execution")]
        public double[] SoFarTheBestSolution { get => soFarTheBestSolution; set => soFarTheBestSolution = value; }
        [Browsable(false)]
        [Category("Execution")]
        public double SoFarTheBestObjective { get => soFarTheBestObjective; set => soFarTheBestObjective = value; }
        [Browsable(false)]
        [Category("Execution")]
        public double[][] SelfBestSolutions { get => selfBestSolutions; set => selfBestSolutions = value; }
        #endregion

        #region FUNCTIONS
        public WildHorseOptimizer(int numberOfVariables, double[] lowerBounds, double[] upperBounds, OptimizationMode opType, ObjectiveFunction objFun)
        {
            // memory allocation for data related to number of variables
            this.numOfVariables = numberOfVariables;
            variableLowerBound = new double[numOfVariables];
            variableUpperBound = new double[numOfVariables];
            for (int i = 0; i < numOfVariables; i++)
            {
                this.variableLowerBound[i] = lowerBounds[i];
                this.variableUpperBound[i] = upperBounds[i];
            }
        }

        public void Reset(COPBenchmark cop)
        {
            // memory reallocation for data related to number of population
            groupIndex = new int[numOfPopulation];
            solutions = new double[numOfPopulation][];
            selfObjective = new double[numOfPopulation];
            selfBestObjective = new double[numOfPopulation];
            selfBestSolutions = new double[numOfPopulation][];
            soFarTheBestSolution = new double[numOfVariables];
            numOfStallion = (int)(numOfPopulation * stallionRatio);
            leaderList = new int[numOfStallion];
            groupNum = new int[numOfStallion];
            numOfFoal = numOfPopulation - numOfStallion;
            soFarTheBestObjective = 0;
            iterationCount = 0;
            // assign initial position to each horse
            for (int i = 0; i < numOfPopulation; i++)
            {
                solutions[i] = new double[numOfVariables];
                selfBestSolutions[i] = new double[numOfVariables];
                // assign each horse to a group
                if (i < numOfStallion)
                {
                    groupIndex[i] = i; // ensure each group has at least one member
                    groupNum[i]++;
                }
                else
                {
                    int group = rnd.Next(numOfStallion); // randomly assign to each group
                    groupIndex[i] = group;
                    groupNum[group]++;
                }

                for (int j = 0; j < numOfVariables; j++)
                {
                    // fill in initial solution and assign to self best solution
                    solutions[i][j] = variableLowerBound[j] + (variableUpperBound[j] - variableLowerBound[j]) * rnd.NextDouble();
                    selfBestSolutions[i][j] = solutions[i][j];
                }
                // calculate horse objective value
                selfBestObjective[i] = cop.GetObjectiveValue(selfBestSolutions[i]);
            }
            //  pick a leader for each group
            if (optimizationMode == OptimizationMode.Maximization)
            {
                for (int i = 0; i < numOfStallion; i++)
                {
                    double bestObj = Double.MinValue;
                    int bestIdx = -1;
                    for (int j = 0; j < numOfPopulation; j++)
                    {
                        if (groupIndex[j] == i)
                        {
                            if (selfBestObjective[j] > bestObj)
                            {
                                bestObj = selfBestObjective[j];
                                bestIdx = j;
                            }
                        }
                    }
                    // assign best one as leader
                    leaderList[i] = bestIdx;
                }
                // pick the best leader as so-far-the-best leader
                double bestLeaderObj = Double.MinValue;
                int bestLeaderIdx = -1;
                for (int i = 0; i < numOfStallion; i++)
                {
                    if (selfBestObjective[leaderList[i]] > bestLeaderObj)
                    {
                        bestLeaderIdx = leaderList[i];
                        bestLeaderObj = selfBestObjective[leaderList[i]];
                    }
                }
                soFarTheBestObjective = bestLeaderObj;
                for (int i = 0; i < numOfVariables; i++)
                {
                    soFarTheBestSolution[i] = solutions[bestLeaderIdx][i];
                }
            }
            else // minimization
            {
                for (int i = 0; i < numOfStallion; i++)
                {
                    double bestObj = Double.MaxValue;
                    int bestIdx = -1;
                    for (int j = 0; j < numOfPopulation; j++)
                    {
                        if (groupIndex[j] == i)
                        {
                            if (selfBestObjective[j] < bestObj)
                            {
                                bestObj = selfBestObjective[j];
                                bestIdx = j;
                            }
                        }
                    }
                    // assign best one as leader
                    leaderList[i] = bestIdx;
                }
                // pick the best leader as so-far-the-best leader
                double bestLeaderObj = Double.MaxValue;
                int bestLeaderIdx = -1;
                for (int i = 0; i < numOfStallion; i++)
                {
                    if (selfBestObjective[leaderList[i]] < bestLeaderObj)
                    {
                        bestLeaderIdx = leaderList[i];
                        bestLeaderObj = selfBestObjective[leaderList[i]];
                    }
                }
                soFarTheBestObjective = bestLeaderObj;
                for (int i = 0; i < numOfVariables; i++)
                {
                    soFarTheBestSolution[i] = solutions[bestLeaderIdx][i];
                }
            }
        }

        public void RunOneIteration(COPBenchmark cop)
        {
            MembersGrazingAndMatingToNewPosition(cop);
            SelectNewLeaderAndUpdateSoFarTheBest(cop);
            iterationCount++;
        }

        public void RunToEnd()
        {
            do
            {
                RunOneIteration(cop);
            } while (iterationCount < iterationLimit);
        }

        double r3 = 0;
        public void MembersGrazingAndMatingToNewPosition(COPBenchmark cop)
        {
            // calculate TDR
            double TDR = 1 - iterationCount / iterationLimit; // change from 1 to 0

            for (int i = 0; i < numOfStallion; i++)
            {
                double[] vectorR1 = new double[numOfVariables];
                int[] vectorP = new int[numOfVariables];
                int[] vectorIDX = new int[numOfVariables];
                double[] theta = new double[numOfVariables];
                double r2 = rnd.NextDouble();
                r3 = rnd.NextDouble();
                double Z = 0;
                double temp1 = 0;
                double temp2 = 0;

                // fill in vector R1 & vector P & vector IDX & theta
                for (int v = 0; v < numOfVariables; v++)
                {
                    theta[v] = rnd.NextDouble() * 360;
                    vectorR1[v] = rnd.NextDouble();
                    if (vectorR1[v] < TDR)
                    {
                        vectorP[v] = 1; // 1 for true
                        vectorIDX[v] = 0; // p == 1 for false;
                    }
                    else
                    {
                        vectorP[v] = 0; // 0 for false
                        vectorIDX[v] = 1; // p == 0 for true
                    }
                }

                // calculate Z
                for (int v = 0; v < numOfVariables; v++)
                {
                    if (vectorIDX[v] == 1)
                    {
                        temp1 += theta[v] * vectorIDX[v];
                    }
                    else // vectorIDX[v] == 0
                    {
                        temp2 += theta[v] * vectorIDX[v];
                    }
                }
                Z = r2 * temp1 + r3 * temp2; // radius of group

                double R = rnd.NextDouble() * 4 - 2;
                for (int j = 0; j < numOfPopulation; j++)
                {
                    if ((groupIndex[j] == i) && (j != leaderList[i])) // ensure j is member of group i and not the leader
                    {
                        //double R = rnd.NextDouble() * 4 - 2;
                        double randomNum = rnd.NextDouble();
                        if (randomNum > crossoverRate) // foal should move around group leader
                        {
                            for (int k = 0; k < numOfVariables; k++)
                            {
                                // update position dimension by dimension
                                solutions[j][k] = 2 * Z * Math.Cos(2 * Math.PI * R * Z) * (solutions[leaderList[i]][k] - solutions[j][k]) + solutions[leaderList[i]][k];
                            }
                        }
                        else // mate with others and move
                        {
                            int newGroupNum = rnd.Next(numOfStallion);
                            if (newGroupNum != i && groupNum[i] > 1) // ensure different group and each group has at least one member
                            {
                                groupIndex[j] = newGroupNum; // join new group
                                groupNum[i]--;
                                groupNum[newGroupNum]++;
                                for (int k = 0; k < numOfVariables; k++)
                                {
                                    // update position dimension by dimension
                                    solutions[j][k] = 2 * Z * Math.Cos(2 * Math.PI * R * Z) * (solutions[leaderList[newGroupNum]][k] - solutions[j][k]) + solutions[leaderList[newGroupNum]][k];
                                }
                            }
                            else // stay in original group
                            {
                                for (int k = 0; k < numOfVariables; k++)
                                {
                                    // update position dimension by dimension
                                    solutions[j][k] = 2 * Z * Math.Cos(2 * Math.PI * R * Z) * (solutions[leaderList[newGroupNum]][k] - solutions[j][k]) + solutions[leaderList[newGroupNum]][k];
                                }
                            }                   
                        }
                    }
                }
                double[] tempSol = new double[numOfVariables];
                if (optimizationMode == OptimizationMode.Maximization)
                {
                    // move leader
                    if (r3 > 0.5)
                    {
                        for (int k = 0; k < numOfVariables; k++)
                        {
                            tempSol[k] = 2 * Z * Math.Cos(2 * Math.PI * R * Z) * (soFarTheBestSolution[k] - solutions[leaderList[i]][k]) + soFarTheBestSolution[k] + variableLowerBound[k] + (variableUpperBound[k] - variableLowerBound[k])* rnd.NextDouble();
                        }
                        // update leader's position if new position is better
                        if (cop.GetObjectiveValue(tempSol) > cop.GetObjectiveValue(solutions[leaderList[i]]))
                        {
                            for (int k = 0; k < numOfVariables; k++)
                            {
                                solutions[leaderList[i]][k] = tempSol[k];
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < numOfVariables; k++)
                        {
                            tempSol[k] = 2 * Z * Math.Cos(2 * Math.PI * R * Z) * (soFarTheBestSolution[k] - solutions[leaderList[i]][k]) - soFarTheBestSolution[k] + variableLowerBound[k] + (variableUpperBound[k] - variableLowerBound[k]) * rnd.NextDouble();
                        }
                        if (cop.GetObjectiveValue(tempSol) > cop.GetObjectiveValue(solutions[leaderList[i]]))
                        {
                            for (int k = 0; k < numOfVariables; k++)
                            {
                                solutions[leaderList[i]][k] = tempSol[k];
                            }
                        }
                    }
                }
                else
                {
                    // move leader
                    if (r3 > 0.5)
                    {
                        for (int k = 0; k < numOfVariables; k++)
                        {
                            tempSol[k] = 2 * Z * Math.Cos(2 * Math.PI * R * Z) * (soFarTheBestSolution[k] - solutions[leaderList[i]][k]) + soFarTheBestSolution[k] + variableLowerBound[k] + (variableUpperBound[k] - variableLowerBound[k]) * rnd.NextDouble() ;
                        }
                        // update leader's position if new position is better
                        if (cop.GetObjectiveValue(tempSol) < cop.GetObjectiveValue(solutions[leaderList[i]]))
                        {
                            for (int k = 0; k < numOfVariables; k++)
                            {
                                solutions[leaderList[i]][k] = tempSol[k];
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < numOfVariables; k++)
                        {
                            tempSol[k] = 2 * Z * Math.Cos(2 * Math.PI * R * Z) * (soFarTheBestSolution[k] - solutions[leaderList[i]][k]) - soFarTheBestSolution[k] + variableLowerBound[k] + (variableUpperBound[k] - variableLowerBound[k]) * rnd.NextDouble();
                        }
                        if (cop.GetObjectiveValue(tempSol) < cop.GetObjectiveValue(solutions[leaderList[i]]))
                        {
                            for (int k = 0; k < numOfVariables; k++)
                            {
                                solutions[leaderList[i]][k] = tempSol[k];
                            }
                        }
                    }
                }
                    
            }
        }

        public void SelectNewLeaderAndUpdateSoFarTheBest(COPBenchmark cop)
        {
            iterationBestObjective = 0;
            iterationAverage = 0;
            //  pick a leader for each group
            if (optimizationMode == OptimizationMode.Maximization)
            {
                double objSum = 0;
                for (int i = 0; i < numOfStallion; i++)
                {
                    double bestObj = Double.MinValue;
                    int bestIdx = -1;
                    for (int j = 0; j < numOfPopulation; j++)
                    {
                        if (groupIndex[j] == i)
                        {
                            double currentObj = cop.GetObjectiveValue(solutions[j]);
                            if (currentObj > bestObj)
                            {
                                bestObj = currentObj;
                                bestIdx = j;
                            }
                        }
                    }
                    // assign best one as leader
                    leaderList[i] = bestIdx;
                }
                // pick the best leader as so-far-the-best leader
                double bestLeaderObj = Double.MinValue;
                int bestLeaderIdx = -1;
                for (int i = 0; i < numOfStallion; i++)
                {
                    double currentObj = cop.GetObjectiveValue(solutions[leaderList[i]]);
                    if (currentObj > bestLeaderObj)
                    {
                        bestLeaderIdx = leaderList[i];
                        bestLeaderObj = currentObj;
                    }
                }
                soFarTheBestObjective = bestLeaderObj;
                for (int i = 0; i < numOfVariables; i++)
                {
                    soFarTheBestSolution[i] = solutions[bestLeaderIdx][i];
                }

                double iteBestObj = Double.MinValue;
                int iteBestIdx = -1;
                for (int i = 0; i < numOfPopulation; i++)
                {
                    selfObjective[i] = cop.GetObjectiveValue(solutions[i]);
                    objSum += selfObjective[i];
                    // check if current solution is better than iteration best
                    if (selfObjective[i] > iteBestObj)
                    {
                        iteBestObj = selfObjective[i];
                        iteBestIdx = i;
                    }
                }
                iterationBestObjective = iteBestObj;
                iterationAverage = objSum / numOfPopulation;
            }
            else // minimization
            {
                double objSum = 0;
                for (int i = 0; i < numOfStallion; i++)
                {
                    double bestObj = Double.MaxValue;
                    int bestIdx = -1;
                    for (int j = 0; j < numOfPopulation; j++)
                    {
                        if (groupIndex[j] == i)
                        {
                            double currentObj = cop.GetObjectiveValue(solutions[j]);
                            if (currentObj < bestObj)
                            {
                                bestObj = currentObj;
                                bestIdx = j;
                            }
                        }
                    }
                    // assign best one as leader
                    leaderList[i] = bestIdx;
                }
                // pick the best leader as so-far-the-best leader
                double bestLeaderObj = Double.MaxValue;
                int bestLeaderIdx = -1;
                for (int i = 0; i < numOfStallion; i++)
                {
                    double currentObj = cop.GetObjectiveValue(solutions[leaderList[i]]);
                    if (currentObj < bestLeaderObj)
                    {
                        bestLeaderIdx = leaderList[i];
                        bestLeaderObj = currentObj;
                    }
                }
                soFarTheBestObjective = bestLeaderObj;
                for (int i = 0; i < numOfVariables; i++)
                {
                    soFarTheBestSolution[i] = solutions[bestLeaderIdx][i];
                }

                double iteBestObj = Double.MaxValue;
                int iteBestIdx = -1;
                for (int i = 0; i < numOfPopulation; i++)
                {
                    selfObjective[i] = cop.GetObjectiveValue(solutions[i]);
                    objSum += selfObjective[i];
                    // check if current solution is better than iteration best
                    if (selfObjective[i] < iteBestObj)
                    {
                        iteBestObj = selfObjective[i];
                        iteBestIdx = i;
                    }
                }
                iterationBestObjective = iteBestObj;
                iterationAverage = objSum / numOfPopulation;
            }
        }
        #endregion
    }
}
