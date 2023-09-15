using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGALibrary
{
    public class GenericGASolver<T>
    {
        #region DATA FIELDS
        OptimizationType optimizationMode = OptimizationType.Maximization;
        MutationMode mutationType = MutationMode.PopulationSizeBased;
        SelectionMode selectionType = SelectionMode.Deterministic;
        CutMode crossOverCut = CutMode.OnePointCut;

        ObjectiveFunction<T> theObjectiveFunction;
        protected int populationSize = 10;
        protected int numberOfGenes;
        protected T[][] chromosomes;
        protected double[] objectiveValues;
        protected double[] fitnessValues;

        protected T[] soFarTheBestSolution;
        protected double soFarTheBestObjective;

        protected double iterationObjectiveAverage;
        protected double iterationBestObjective;

        protected int numberOfCrossoveredChildren;
        protected int numberOfMutatedChildren;

        protected double crossoverRate = 0.8;
        protected double mutationRate = 0.3; // population-size based ; 0.05 for gene-number based
        protected double penaltyFactor = 200;

        GAControl<T> theControl = null;

        protected int[] indices;
        protected bool[] cutPositionFlags;
        protected T[,] selectedChromosomes;
        protected double[] selectedObjectives;
        protected double leastFitnessFraction = 0.3;

        protected int iterationLimit = 100;
        protected int iterationCount = 0;

        protected bool[][] mutatedFlags; // to set mutated gene in gene-number based mutation
        protected Random randomizer = new Random();
        #endregion

        #region PROPERTIES
        // user-defined properties
        [Category("Type Selection")]
        public virtual OptimizationType OptimizationMode 
        { 
            get => optimizationMode;
            set
            {
                optimizationMode = value;
            }
        }
        [Category("Type Selection")]
        public virtual CutMode CrossOverCut
        {
            set
            {
                crossOverCut = value;
            }
            get => crossOverCut;
        }
        [Category("Type Selection")]
        public virtual SelectionMode SelectionType
        {
            set
            {
                selectionType = value;
            }
            get => selectionType;
        }
        [Category("Type Selection")]
        public virtual MutationMode MutationType
        {
            set
            {
                mutationType = value;
                if (mutationType == MutationMode.GeneNumberBased)
                {
                    mutationRate = 0.05;
                }
                else
                {
                    mutationRate = 0.3;
                }
            }
            get => mutationType; 
        }
        [Category("Parameters")]
        public int PopulationSize 
        { get => populationSize;
            set
            {
                if (value > 0) populationSize = value;
            }
        }
        [Category("Parameters")]
        public double CrossoverRate
        {
            get => crossoverRate;
            set
            {
                if (value < 1 && value > 0) crossoverRate = value;
            }
        }
        [Category("Parameters")]
        public double MutationRate
        {
            get => mutationRate;
            set
            {
                if (value < 1 && value > 0) mutationRate = value;
            }
        }

        [Category("Parameters")]
        public int IterationLimit { get => iterationLimit; set { if (value > 10) iterationLimit = value; } }
        [Category("Parameters")]
        public double PenaltyFactor { get => penaltyFactor; set { if (value > 150) penaltyFactor = value; } }

        // non-browsable properties
        [Browsable(false)]
        public GAControl<T> TheControl { get => theControl; }
        [Browsable(false)]
        public int NumberOfGenes { get => numberOfGenes; set { if (value > 0) numberOfGenes = value; } }
        [Browsable(false)]
        public double[] FitnessValues { get => fitnessValues; }
        [Browsable(false)]
        public double[] ObjectiveValues { get => objectiveValues; }
        [Browsable(false)]
        public int IterationCount { get => iterationCount; }
        [Browsable(false)]
        public T[][] Chromosomes { get => chromosomes; }
        [Browsable(false)]
        public T[] SoFarTheBestSolution { get => soFarTheBestSolution; }
        [Browsable(false)]
        public double SoFarTheBestObjective { get => soFarTheBestObjective; }

        [Browsable(false)]
        public double IterationObjectiveAverage { get => iterationObjectiveAverage; }

        [Browsable(false)]
        public double IterationBestObjective { get => iterationBestObjective; }
        #endregion

        #region PUBLIC EVENTS
        public event EventHandler AfterReset;
        public event EventHandler SoFarTheBestSolutionUpdated;
        public event EventHandler OneIterationCompleted;
        
        protected void FireAfterResetEvent()
        {
            if (AfterReset != null) AfterReset(this, null);
        }

        private void FireOneIterationCompleteEvent()
        {
            if (OneIterationCompleted != null) OneIterationCompleted(this, null);
        }

        private void FireSoFarTheBestSolutionUpdateEvent()
        {
            if (SoFarTheBestSolutionUpdated != null) SoFarTheBestSolutionUpdated(this, null);
        }
        #endregion

        #region CTOR
        public GenericGASolver(int numberOfVariables, OptimizationType optimizationType, 
            ObjectiveFunction<T> objectiveEvaluationFunction, Panel hostPanel = null)
        {
            numberOfGenes = numberOfVariables;
            soFarTheBestSolution = new T[numberOfGenes];
            this.OptimizationMode = OptimizationMode;
            OptimizationMode = optimizationType;
            theObjectiveFunction = objectiveEvaluationFunction;

            cutPositionFlags = new bool[numberOfGenes];
            if (hostPanel != null)
            {
                theControl = new GAControl<T>(this);
                hostPanel.Controls.Clear();
                hostPanel.Controls.Add(theControl);
                theControl.Dock = DockStyle.Fill;
            }
        }
        #endregion

        #region METHODS
        void setFitnessFromObjectives()
        {
            int numberAll = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;
            double minFitness = 0;

            // max objective value = IterationBestObjective
            // calculate min objective value
            double minObjective = Double.MaxValue;
            for (int i = 0; i < numberAll; i++)
            {
                if (objectiveValues[i] < minObjective)
                minObjective = objectiveValues[i];
            }

            double range = leastFitnessFraction * (IterationBestObjective - minObjective);
            if (range > Math.Pow(10, -5))
            {
                minFitness = range;
            }
            else
            {
                minFitness = Math.Pow(10, -5);
            }

            if (OptimizationMode == OptimizationType.Maximization)
            {
                // fitness = minFitness + (obj - obj_min)
                for (int i = 0; i < numberAll; i++)
                {
                    fitnessValues[i] = minFitness + (objectiveValues[i] - minObjective);
                }
            }
            else // Minimization
            {
                // fitness = minFitness + (obj_max - obj)
                for (int i = 0; i < numberAll; i++)
                {
                    fitnessValues[i] = minFitness + (IterationBestObjective - objectiveValues[i]);
                }
            }
        }

        void UpdateIterationBestAverageAndSoFarTheBest()
        {
            int numberAll = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;
            int iterationBestIdx = -1;

            double sumOfObjectiveValues = 0;
            if (optimizationMode == OptimizationType.Maximization)
            {
                iterationBestObjective = Double.MinValue;
                for (int i = 0; i < numberAll; i++)
                {
                    sumOfObjectiveValues += objectiveValues[i];
                    if (objectiveValues[i] > iterationBestObjective)
                    {
                        iterationBestObjective = objectiveValues[i];
                        iterationBestIdx = i;
                    }
                }
                // check if iteration best is better than so-far-the-best
                if (iterationBestObjective > soFarTheBestObjective)
                {
                    //update so-far-the-best objective and solution
                    soFarTheBestObjective = iterationBestObjective;
                    // copy gene by gene
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        soFarTheBestSolution[i] = chromosomes[iterationBestIdx][i];
                    }
                }
            }
            else // Minimization
            {
                iterationBestObjective = Double.MaxValue;
                for (int i = 0; i < numberAll; i++)
                {
                    sumOfObjectiveValues += objectiveValues[i];
                    if (objectiveValues[i] < iterationBestObjective)
                    {
                        iterationBestObjective = objectiveValues[i];
                        iterationBestIdx = i;
                    }
                }
                // check if iteration best is better than so-far-the-best
                if (iterationBestObjective < soFarTheBestObjective)
                {
                    //update so-far-the-best objective and solution
                    soFarTheBestObjective = iterationBestObjective;
                    // copy gene by gene
                    for (int i = 0; i < numberOfGenes; i++)
                    {
                        soFarTheBestSolution[i] = chromosomes[iterationBestIdx][i];
                    }
                }
            }
            iterationObjectiveAverage = sumOfObjectiveValues / numberAll;
        }

        void PerformSelectionOperation()
        {
            int numberAll = populationSize + numberOfCrossoveredChildren + numberOfMutatedChildren;
            UpdateIterationBestAverageAndSoFarTheBest();

            // calculate fitness
            setFitnessFromObjectives();

            switch (SelectionType)
            {
                case SelectionMode.Deterministic:
                    for (int i = 0; i < numberAll; i++) indices[i] = i;
                    Array.Sort(fitnessValues, indices, 0, numberAll); // small to large
                    Array.Reverse(indices, 0, numberAll);
                    break;
                case SelectionMode.Stochastic:
                    double wholeRange = 0;
                    double[] cumulatedFitness = new double[numberAll];
                    for (int i = 0; i < numberAll; i++)
                    {
                        wholeRange += fitnessValues[i];
                        // cumulate fitness assignment
                        cumulatedFitness[i] = wholeRange;
                    }
                    // perform populationSize stochastic selection
                    for (int i = 0; i < populationSize; i++)
                    {
                        // example
                        // 5 16 22 47 67 100
                        // 40
                        int HitIdx = -1;
                        int HitPos = randomizer.Next((int)wholeRange);
                        for (int j = 0; j < numberAll; j++)
                        {
                            if (HitPos > cumulatedFitness[j])
                            {
                                HitIdx = j;
                            }
                            else
                            {
                                break;
                            }
                        }
                        HitIdx += 1;
                        indices[i] = HitIdx;
                    }
                    break;
            }

            // Gene-wisely copy the selected chromosomes to selectedChromosome and their objective values
            // selected indexes are store in the front of the indices array
            for (int r = 0; r < populationSize; r++)
            {
                for(int c = 0; c < numberOfGenes; c++)
                {
                    selectedChromosomes[r, c] = chromosomes[indices[r]][c];
                }
                // copy objective values to selected objective value
                selectedObjectives[r] = objectiveValues[indices[r]];
            }

            // copy back to chromosomes
            for (int r = 0; r < populationSize; r++)
            {
                for (int c = 0; c < numberOfGenes; c++)
                {
                    chromosomes[r][c] = selectedChromosomes[r, c];
                    objectiveValues[r] = selectedObjectives[r];
                }
            }
        }

        public void Reset()
        {
            // Reallocate memory if populationSize is changed
            int ThreeSizes = 3 * populationSize;
            chromosomes = new T[ThreeSizes][];
            for (int i = 0; i < ThreeSizes; i++)
            {
                chromosomes[i] = new T[numberOfGenes];
            }

            //...
            objectiveValues = new double[ThreeSizes];
            fitnessValues = new double[ThreeSizes];
            mutatedFlags = new bool[populationSize][];
            cutPositionFlags = new bool[numberOfGenes];
            for (int i = 0; i < populationSize; i++)
            {
                mutatedFlags[i] = new bool[numberOfGenes];
            }

            indices = new int[ThreeSizes];
            iterationCount = 0;
            soFarTheBestObjective = (optimizationMode == OptimizationType.Maximization) ? double.MinValue : double.MaxValue;

            selectedChromosomes = new T[populationSize, numberOfGenes];
            selectedObjectives = new double[populationSize];

            // initialize initial population
            InitializePopulation();
            // evaluate initial population
            for (int i = 0; i < populationSize; i++)
            {
                objectiveValues[i] = theObjectiveFunction(chromosomes[i]);
            }

            FireAfterResetEvent();
        }

        protected virtual void InitializePopulation()
        {
            throw new NotImplementedException();
        }

        public void RunOneIteration()
        {
            PerformCrossoverOperation();
            PerformMutationOperation();
            PerformSelectionOperation();
            iterationCount++;

            FireOneIterationCompleteEvent();
        }

        private void PerformMutationOperation()
        {
            int childIdx = populationSize + numberOfCrossoveredChildren;
            switch (mutationType)
            {
                case MutationMode.PopulationSizeBased:
                    numberOfMutatedChildren = (int)(mutationRate * populationSize);
                    ShuffleIndices(PopulationSize);
                    for (int i = 0; i < numberOfMutatedChildren; i++)
                    {
                        GenerateAMutatedChild(indices[i], childIdx);
                        //compute objective values of mutated child
                        objectiveValues[childIdx] = theObjectiveFunction(chromosomes[childIdx]);
                        childIdx++;
                    }
                    break;
                case MutationMode.GeneNumberBased:
                    numberOfMutatedChildren = 0;
                    int limit = numberOfGenes * populationSize;
                    int numberOfMutatedGenes = (int)(mutationRate * limit);
                    for (int p = 0; p < populationSize; p++)
                    {
                        for (int q = 0; q < numberOfGenes; q++)
                        {
                            mutatedFlags[p][q] = false;
                        }
                    }
                    for (int i = 0; i < numberOfMutatedGenes; i++)
                    {
                        int sequIndex = randomizer.Next(limit);
                        int rowIdx = sequIndex / numberOfGenes;
                        int colIdx = sequIndex % numberOfGenes;
                        mutatedFlags[rowIdx][colIdx] = true;
                    }
                    for (int r = 0; r < populationSize; r++)
                    {
                        bool hit = false;
                        for( int c = 0; c < numberOfGenes; c++)
                        {
                            if (mutatedFlags[r][c])
                            {
                                hit = true;
                                break;
                            }
                        }
                        if (hit)
                        {
                            // ask the parent to mutate
                            GenerateAGeneBasedMutatedChild(r, childIdx);
                            objectiveValues[childIdx] = theObjectiveFunction(chromosomes[childIdx]);
                            childIdx++;
                            numberOfMutatedChildren++;
                        }
                    }
                    break;
            }
        }

        public virtual void GenerateAGeneBasedMutatedChild(int parentIdx, int childIdx)
        {
            // refer to mutatedFlag for gene value mutation
            throw new NotImplementedException();
        }

        public virtual void GenerateAMutatedChild(int parentIdx, int childIdx)
        {
            throw new NotImplementedException();
        }

        private void PerformCrossoverOperation()
        {
            // Shuffle indices array to arrange parent IDs
            ShuffleIndices(PopulationSize);
            numberOfCrossoveredChildren = (int)(crossoverRate * populationSize);
            if (numberOfCrossoveredChildren > populationSize)
            {
                numberOfCrossoveredChildren = populationSize;
            }
            if (numberOfCrossoveredChildren % 2 == 1)
            {
                numberOfCrossoveredChildren++;
            }
            for (int i = 0; i < numberOfCrossoveredChildren; i+=2)
            {
                int child1Idx = populationSize + i;
                int child2Idx = child1Idx + 1;
                GenerateAPairOfCrossoveredChildren(indices[i], indices[i+1], child1Idx, child2Idx);
                //compute objective values of child 1 and 2
                objectiveValues[child1Idx] = theObjectiveFunction(chromosomes[child1Idx]);
                objectiveValues[child2Idx] = theObjectiveFunction(chromosomes[child2Idx]);
            }
        }

        public virtual void GenerateAPairOfCrossoveredChildren(int fatherIdx, int motherIdx, int child1Idx, int child2Idx)
        {
            throw new NotImplementedException();
        }

        public void RunToEnd()
        {
            do
            {
                RunOneIteration();
            } while (iterationCount < iterationLimit);

        }

        protected void ShuffleIndices(int upIdx)
        {
            for (int i = 0; i < upIdx; i++)
            {
                indices[i] = i;
            }
            for (int j = upIdx; j > 0; j--)
            {
                int pos = randomizer.Next(j + 1);
                int temp = indices[pos];
                indices[pos] = indices[j];
                indices[j] = temp;
            }
        }
        #endregion
    }
}
