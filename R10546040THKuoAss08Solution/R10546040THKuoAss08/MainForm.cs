using MyGALibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace R10546040THKuoAss07
{
    public partial class MainForm : Form
    {
        BinaryGA myBinaryGASolver;
        PermutationGA myPermutationGASolver;
        int numOfJobAndMachine;
        double[,] timeMatrix;

        public MainForm()
        {
            InitializeComponent();
        }

        private void tsbCreateBinaryGA_Click(object sender, EventArgs e)
        {
            myBinaryGASolver = new BinaryGA(10, OptimizationType.Maximization, mySimpleObjFunction, panel1);
            myBinaryGASolver.SoFarTheBestSolutionUpdated += MyBinaryGASolver_SoFarTheBestSolutionUpdated;
            myBinaryGASolver.OneIterationCompleted += MyBinaryGASolver_OneIterationCompleted;
        }

        private void MyBinaryGASolver_OneIterationCompleted(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void MyBinaryGASolver_SoFarTheBestSolutionUpdated(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void tsbCreatePermutationGA_Click(object sender, EventArgs e)
        {
            myPermutationGASolver = new PermutationGA(10, OptimizationType.Maximization, SequenceObjFunction, panel1);

            myPermutationGASolver.SoFarTheBestSolutionUpdated += MyPermutationGASolver_SoFarTheBestSolutionUpdated;

            myPermutationGASolver.TheControl.btnReset.Click += BtnReset_Click;
            myPermutationGASolver.TheControl.btnRunOneIteration.Click += BtnRunOneIteration_Click;
        }

        // int count = 0;
        private void MyPermutationGASolver_SoFarTheBestSolutionUpdated(object sender, EventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void BtnRunOneIteration_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("GA Run One Iteration Button is clicked.");
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("GA Reset Button is clicked.");
        }

        // Testing optimization problem global best solution is 9876543210...
        private double SequenceObjFunction(int[] chromosome)
        {
            double obj = 0;
            for (int i = 0; i < chromosome.Length; i++)
            {
                if (chromosome[i] == chromosome.Length - i - 1) obj++;
            }
            return obj;
        }

        // Job-Assignment problem for permutation GA
        private double jobAssignmentSequenceObjFunction(int[] chromosome)
        {
            double obj = 0;
            double[] timeMatrix2 = new double[(myPermutationGASolver.NumberOfGenes)*(myPermutationGASolver.NumberOfGenes)];
            for (int r = 0; r < numOfJobAndMachine; r++)
            {
                for (int c = 0; c < numOfJobAndMachine; c++)
                {
                    timeMatrix2[(r * numOfJobAndMachine) + c] = timeMatrix[r, c];
                }
            }
            for (int c = 0; c < chromosome.Length; c++)
            {
                obj += timeMatrix2[c * numOfJobAndMachine + chromosome[c]]; 
            }
            return obj;
        }

        // Testing optimization problem global best solution is 0101010101...
        private double mySimpleObjFunction(byte[] chromosome)
        {
            double obj = 0;
            for( int i = 0; i < chromosome.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (chromosome[i] == 0) obj++;
                }
                else
                {
                    if (chromosome[i] == 1) obj++;
                }
            }
            return obj;
        }

        // Job-Assignment problem
        private double jobAssignmentObjFunction(byte[] chromosome)
        {
            double obj = 0;
            int penaltyCount = 0;
            double[] timeMatrix2 = new double[myBinaryGASolver.NumberOfGenes];
            for (int r = 0; r < numOfJobAndMachine; r++)
            {
                for (int c = 0; c < numOfJobAndMachine; c++)
                {
                    timeMatrix2[(r * numOfJobAndMachine) + c] = timeMatrix[r, c];
                }
            }
            for (int c = 0; c < chromosome.Length; c++)
            {
                obj += chromosome[c] * timeMatrix2[c]; // original objective value without penalty
            }
            // row penalty count
            for (int r = 0; r < numOfJobAndMachine; r++)
            {
                int sumOfRow = 0;
                for (int c = 0; c < numOfJobAndMachine; c++)
                {
                    sumOfRow += chromosome[r*numOfJobAndMachine+c];
                }
                if (sumOfRow > 1) penaltyCount += (sumOfRow - 1);
                if (sumOfRow == 0) penaltyCount += 1;
            }
            // column penalty count
            for (int r = 0; r < numOfJobAndMachine; r++)
            {
                int sumOfCol = 0;
                for (int c = 0; c < chromosome.Length; c+= numOfJobAndMachine)
                {
                    sumOfCol += chromosome[r + c];
                }
                if (sumOfCol > 1) penaltyCount += (sumOfCol - 1);
                if (sumOfCol == 0) penaltyCount += 1;
            }
            // calculate new objective value with penalty value
            obj += penaltyCount * myBinaryGASolver.PenaltyFactor;
            return obj;
        }

        private void tsbOpenFile_Click(object sender, EventArgs e)
        {
            //rtbTimeMatrix.Clear();

            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(dlgOpen.FileName);

            string str;
            string[] items;
            str = sr.ReadLine();
            numOfJobAndMachine = Convert.ToInt32(str);
            timeMatrix = new double[numOfJobAndMachine, numOfJobAndMachine];
            //rtbTimeMatrix.AppendText($"Number Of Jobs/Machines: {numOfJobAndMachine}");

            //timeMatrix = new int[numOfJobAndMachine][];
            for (int i = 0; i < numOfJobAndMachine; i++)
            {
                //rtbTimeMatrix.AppendText($"\nRow{i}: ");
                str = sr.ReadLine();
                items = str.Split(' ');
                for (int j = 0; j < numOfJobAndMachine; j++)
                {
                    timeMatrix[i,j] = Convert.ToDouble(items[j]);
                    //rtbTimeMatrix.AppendText($"{timeMatrix[i,j]} ");
                }
            }

            myPermutationGASolver = new PermutationGA(numOfJobAndMachine, OptimizationType.Minimization, jobAssignmentSequenceObjFunction, panel1);
            myPermutationGASolver.PopulationSize = 20;
            myPermutationGASolver.NumberOfGenes = numOfJobAndMachine;
        }

        private void tsbOpenFileBi_Click(object sender, EventArgs e)
        {
            //rtbTimeMatrix.Clear();

            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(dlgOpen.FileName);

            string str;
            string[] items;
            str = sr.ReadLine();
            numOfJobAndMachine = Convert.ToInt32(str);
            timeMatrix = new double[numOfJobAndMachine, numOfJobAndMachine];
            //rtbTimeMatrix.AppendText($"Number Of Jobs/Machines: {numOfJobAndMachine}");

            //timeMatrix = new int[numOfJobAndMachine][];
            for (int i = 0; i < numOfJobAndMachine; i++)
            {
                //rtbTimeMatrix.AppendText($"\nRow{i}: ");
                str = sr.ReadLine();
                items = str.Split(' ');
                for (int j = 0; j < numOfJobAndMachine; j++)
                {
                    timeMatrix[i, j] = Convert.ToDouble(items[j]);
                    //rtbTimeMatrix.AppendText($"{timeMatrix[i,j]} ");
                }
            }

            myBinaryGASolver = new BinaryGA(numOfJobAndMachine* numOfJobAndMachine, OptimizationType.Minimization, jobAssignmentObjFunction, panel1);
            myBinaryGASolver.PopulationSize = 20;
            myBinaryGASolver.NumberOfGenes = numOfJobAndMachine* numOfJobAndMachine;
        }

        private void neToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbCreateBinaryGA_Click(null, null);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbOpenFile_Click(null, null);
        }

        private void newPermutationGAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbCreatePermutationGA_Click(null, null);
        }
    }
}
