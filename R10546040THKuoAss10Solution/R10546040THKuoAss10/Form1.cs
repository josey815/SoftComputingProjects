using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using COP;

namespace R10546040THKuoAss10
{
    public partial class Form1 : Form
    {
        // data fields
        public COPBenchmark theProblem;
        ParticleSwarmOptimizer theSolver;

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) // open benchmark problem
        {
            theProblem = COPBenchmark.LoadAProblemFromAFile();
            theProblem.DisplayOnPanel(splitContainer1.Panel1);
            theProblem.DisplayObjectiveGraphics(tabPage1);
        }

        private void tsbNewPSOSolver_Click(object sender, EventArgs e)
        {
            OptimizationMode opMode;
            if (theProblem != null)
            {
                if (theProblem.OptimizationGoal == OptimizationType.Maximization)
                {
                    opMode = OptimizationMode.Maximization;
                }
                else
                {
                    opMode = OptimizationMode.Minimization;
                }
                theSolver = new ParticleSwarmOptimizer(theProblem.Dimension, theProblem.LowerBound,
                    theProblem.UpperBound, opMode, theProblem.GetObjectiveValue);
                propertyGrid1.SelectedObject = theSolver;
            } 
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e) // show particles on graph
        {
            theProblem.DisplaySolutionsOnGraphics(theSolver.Solutions);
        }

        private void tsbShowEditor_Click(object sender, EventArgs e) // editor for benchmark
        {
            if (theProblem != null)
            {
                theProblem.ShowEditor();
            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            COPBenchmark.CreateANewProblemAndShowEditor();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (theSolver != null)
            {
                theSolver.Reset(theProblem);

                rtbSolutions.Clear();
                rtbSoFarTheBest.Clear();
                foreach (Series s in chtProgress.Series)
                {
                    s.Points.Clear();
                }

                if (ckbShowSolutions.Checked)
                {
                    for (int r = 0; r < theSolver.NumberOfParticles; r++)
                    {
                        rtbSolutions.AppendText($" solution {r}: ");
                        for (int c = 0; c < theProblem.Dimension; c++)
                        {
                            rtbSolutions.AppendText(theSolver.Solutions[r][c].ToString() + " ");
                        }
                        rtbSolutions.AppendText($" individual best: ");
                        for (int c = 0; c < theProblem.Dimension; c++)
                        {
                            rtbSolutions.AppendText(theSolver.SelfBestSolutions[r][c].ToString() + " ");
                        }
                        rtbSolutions.AppendText($"\n");
                    }
                }
                // update 3-D graph
                theProblem.DisplaySolutionsOnGraphics(theSolver.Solutions);
            }
        }

        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            if (theSolver != null)
            {
                theSolver.RunOneIteration(theProblem);

                if (ckbAnimation.Checked)
                {
                    chtProgress.Series[0].Points.AddXY(theSolver.IterationCount, theSolver.IterationAverage);
                    chtProgress.Series[1].Points.AddXY(theSolver.IterationCount, theSolver.IterationBestObjective);
                    chtProgress.Series[2].Points.AddXY(theSolver.IterationCount, theSolver.SoFarTheBestObjective);

                    chtProgress.Update();
                    theProblem.DisplaySolutionsOnGraphics(theSolver.Solutions);
                }
                else
                {
                    chtProgress.Series[0].Points.AddXY(theSolver.IterationCount, theSolver.IterationAverage);
                    chtProgress.Series[1].Points.AddXY(theSolver.IterationCount, theSolver.IterationBestObjective);
                    chtProgress.Series[2].Points.AddXY(theSolver.IterationCount, theSolver.SoFarTheBestObjective);

                    theProblem.DisplaySolutionsOnGraphics(theSolver.Solutions);
                }

                chtProgress.Update();

                if (ckbShowSolutions.Checked)
                {
                    rtbSolutions.Clear();
                    for (int r = 0; r < theSolver.NumberOfParticles; r++)
                    {
                        rtbSolutions.AppendText($" solution {r}: ");
                        for (int c = 0; c < theProblem.Dimension; c++)
                        {
                            rtbSolutions.AppendText(theSolver.Solutions[r][c].ToString() + " ");
                        }
                        rtbSolutions.AppendText($" individual best: ");
                        for (int c = 0; c < theProblem.Dimension; c++)
                        {
                            rtbSolutions.AppendText(theSolver.SelfBestSolutions[r][c].ToString() + " ");
                        }
                        rtbSolutions.AppendText($"\n");
                    }
                }
            }
        }

        private void btnRunToEnd_Click(object sender, EventArgs e)
        {
            if (theSolver != null)
            {
                // in show animation mode
                while (theSolver.IterationCount < theSolver.IterationLimit)
                {
                    btnRunOneIteration_Click(null, null);
                }
                chtProgress.Update();
                // show final results on rich text box
                rtbSoFarTheBest.Clear();
                rtbSoFarTheBest.AppendText($"The Best Objective = {theSolver.SoFarTheBestObjective} \nThe Best Solution = ");
                for (int i = 0; i < theSolver.SoFarTheBestSolution.Length; i++)
                {
                    rtbSoFarTheBest.AppendText($"{theSolver.SoFarTheBestSolution[i]} ");
                }
                theProblem.DisplaySolutionsOnGraphics(theSolver.Solutions);
            }
        }
    }
}
