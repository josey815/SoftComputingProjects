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
        int[,] timeMatrix = new int[7,7];
        int numOfJobAndMachine;

        public MainForm()
        {
            InitializeComponent();
        }

        private void tsbCreateBinaryGA_Click(object sender, EventArgs e)
        {
            myBinaryGASolver = new BinaryGA(10, OptimizationType.Maximization, mySimpleObjFunction);
            propertyGrid1.SelectedObject = myBinaryGASolver;
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
            int[] timeMatrix2 = new int[myBinaryGASolver.NumberOfGenes];
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (myBinaryGASolver != null)
            {
                myBinaryGASolver.Reset();

                richTextBox1.Clear();
                rtbSoFarTheBest.Clear();
                foreach (Series s in chtProgress.Series)
                {
                    s.Points.Clear();
                }


                for (int r = 0; r < myBinaryGASolver.PopulationSize; r++)
                {
                    richTextBox1.AppendText($" p{r}: ");
                    for (int c = 0; c < myBinaryGASolver.NumberOfGenes; c++)
                    {
                        //if (c > 0 && (c % 7 == 0)) richTextBox1.AppendText(" ");
                        richTextBox1.AppendText(myBinaryGASolver.Chromosomes[r][c].ToString() + " ");
                    }
                    richTextBox1.AppendText($" obj = {myBinaryGASolver.ObjectiveValues[r]}\n");
                }
            }
        }

        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            if (myBinaryGASolver != null)
            {
                myBinaryGASolver.RunOneIteration();
                richTextBox1.Clear();

                //...

                for (int r = 0; r < myBinaryGASolver.Chromosomes.Length; r++)
                {
                    richTextBox1.AppendText($" {r}: ");
                    for (int c = 0; c < myBinaryGASolver.NumberOfGenes; c++)
                    {
                        richTextBox1.AppendText(myBinaryGASolver.Chromosomes[r][c].ToString() + " ");
                    }
                    richTextBox1.AppendText($" obj = {myBinaryGASolver.ObjectiveValues[r]}\n");
                }

                chtProgress.Series[0].Points.AddXY(myBinaryGASolver.IterationCount, myBinaryGASolver.IterationObjectiveAverage);
                chtProgress.Series[1].Points.AddXY(myBinaryGASolver.IterationCount, myBinaryGASolver.IterationBestObjective);
                chtProgress.Series[2].Points.AddXY(myBinaryGASolver.IterationCount, myBinaryGASolver.SoFarTheBestObjective);

                chtProgress.Update();
            }
        }

        private void btnRunToEnd_Click(object sender, EventArgs e)
        {
            if (myBinaryGASolver != null)
            {
                // in hide animation mode
                // myBinaryGASolver.RunToEnd();

                // in show animation mode
                while (myBinaryGASolver.IterationCount < myBinaryGASolver.IterationLimit)
                {
                    btnRunOneIteration_Click(null, null);
                }

                // show final results on rich text box
                rtbSoFarTheBest.Clear();
                rtbSoFarTheBest.AppendText($"The Best Objective = {myBinaryGASolver.SoFarTheBestObjective} \nThe Best Solution = ");
                for (int i = 0; i < myBinaryGASolver.SoFarTheBestSolution.Length; i++)
                {
                    rtbSoFarTheBest.AppendText($"{myBinaryGASolver.SoFarTheBestSolution[i]} ");
                }
            }     
        }

        private void tsbOpenFile_Click(object sender, EventArgs e)
        {
            rtbTimeMatrix.Clear();
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(dlgOpen.FileName);

            string str;
            string[] items;
            str = sr.ReadLine();
            numOfJobAndMachine = Convert.ToInt32(str);
            rtbTimeMatrix.AppendText($"Number Of Jobs/Machines: {numOfJobAndMachine}");

            //timeMatrix = new int[numOfJobAndMachine][];
            for (int i = 0; i < numOfJobAndMachine; i++)
            {
                rtbTimeMatrix.AppendText($"\nRow{i}: ");
                str = sr.ReadLine();
                items = str.Split(' ');
                for (int j = 0; j < numOfJobAndMachine; j++)
                {
                    timeMatrix[i,j] = Convert.ToInt32(items[j]);
                    rtbTimeMatrix.AppendText($"{timeMatrix[i,j]} ");
                }
            }

            myBinaryGASolver = new BinaryGA(49, OptimizationType.Minimization, jobAssignmentObjFunction);
            myBinaryGASolver.PopulationSize = 20;
            myBinaryGASolver.NumberOfGenes = numOfJobAndMachine * numOfJobAndMachine;
            propertyGrid1.SelectedObject = myBinaryGASolver;
        }

        private void neToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbCreateBinaryGA_Click(null, null);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbOpenFile_Click(null, null);
        }
    }
}
