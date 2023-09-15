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
        ParticleSwarmOptimizer PSOSolver;
        WildHorseOptimizer WHOSolver;

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
                PSOSolver = new ParticleSwarmOptimizer(theProblem.Dimension, theProblem.LowerBound,
                    theProblem.UpperBound, opMode, theProblem.GetObjectiveValue);
                propertyGrid1.SelectedObject = PSOSolver;
                WHOSolver = null;
            } 
        }

        private void tsbNewWHOSolver_Click(object sender, EventArgs e)
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
                WHOSolver = new WildHorseOptimizer(theProblem.Dimension, theProblem.LowerBound,
                    theProblem.UpperBound, opMode, theProblem.GetObjectiveValue);
                propertyGrid1.SelectedObject = WHOSolver;
                PSOSolver = null;
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e) // show particles on graph
        {
            if (PSOSolver != null)
            {
                theProblem.DisplaySolutionsOnGraphics(PSOSolver.Solutions);
            }
            else if (WHOSolver != null)
            {
                theProblem.DisplaySolutionsOnGraphics(WHOSolver.Solutions);
            }
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
            if (PSOSolver != null)
            {
                PSOSolver.Reset(theProblem);

                rtbSolutions.Clear();
                rtbSoFarTheBest.Clear();
                foreach (Series s in chtProgress.Series)
                {
                    s.Points.Clear();
                }

                if (ckbShowSolutions.Checked)
                {
                    for (int r = 0; r < PSOSolver.NumberOfParticles; r++)
                    {
                        rtbSolutions.AppendText($" solution {r}: ");
                        for (int c = 0; c < theProblem.Dimension; c++)
                        {
                            rtbSolutions.AppendText(PSOSolver.Solutions[r][c].ToString() + " ");
                        }
                        rtbSolutions.AppendText($" individual best: ");
                        for (int c = 0; c < theProblem.Dimension; c++)
                        {
                            rtbSolutions.AppendText(PSOSolver.SelfBestSolutions[r][c].ToString() + " ");
                        }
                        rtbSolutions.AppendText($"\n");
                    }
                }
                // update 3-D graph
                theProblem.DisplaySolutionsOnGraphics(PSOSolver.Solutions);
            }else if (WHOSolver != null)
            {
                WHOSolver.Reset(theProblem);

                rtbSolutions.Clear();
                rtbSoFarTheBest.Clear();
                foreach (Series s in chtProgress.Series)
                {
                    s.Points.Clear();
                }

                if (ckbShowSolutions.Checked)
                {
                    for (int r = 0; r < WHOSolver.NumOfPopulation; r++)
                    {
                        rtbSolutions.AppendText($" solution {r}: ");
                        for (int c = 0; c < theProblem.Dimension; c++)
                        {
                            rtbSolutions.AppendText(WHOSolver.Solutions[r][c].ToString() + " ");
                        }
                        //rtbSolutions.AppendText($" individual best: ");
                        //for (int c = 0; c < theProblem.Dimension; c++)
                        //{
                        //    rtbSolutions.AppendText(WHOSolver.SelfBestSolutions[r][c].ToString() + " ");
                        //}
                        rtbSolutions.AppendText($"\n");
                    }
                }
                // update 3-D graph
                theProblem.DisplaySolutionsOnGraphics(WHOSolver.Solutions);
            }
        }

        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            if (PSOSolver != null)
            {
                PSOSolver.RunOneIteration(theProblem);

                if (ckbAnimation.Checked)
                {
                    chtProgress.Series[0].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationAverage);
                    chtProgress.Series[1].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationBestObjective);
                    chtProgress.Series[2].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjective);

                    chtProgress.Update();
                    theProblem.DisplaySolutionsOnGraphics(PSOSolver.Solutions);
                }
                else
                {
                    chtProgress.Series[0].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationAverage);
                    chtProgress.Series[1].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationBestObjective);
                    chtProgress.Series[2].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjective);

                    theProblem.DisplaySolutionsOnGraphics(PSOSolver.Solutions);
                }

                chtProgress.Update();

                if (ckbShowSolutions.Checked)
                {
                    rtbSolutions.Clear();
                    for (int r = 0; r < PSOSolver.NumberOfParticles; r++)
                    {
                        rtbSolutions.AppendText($" solution {r}: ");
                        for (int c = 0; c < theProblem.Dimension; c++)
                        {
                            rtbSolutions.AppendText(PSOSolver.Solutions[r][c].ToString() + " ");
                        }
                        rtbSolutions.AppendText($" individual best: ");
                        for (int c = 0; c < theProblem.Dimension; c++)
                        {
                            rtbSolutions.AppendText(PSOSolver.SelfBestSolutions[r][c].ToString() + " ");
                        }
                        rtbSolutions.AppendText($"\n");
                    }
                }
            }else if (WHOSolver != null)
            {
                WHOSolver.RunOneIteration(theProblem);

                if (ckbAnimation.Checked)
                {
                    chtProgress.Series[0].Points.AddXY(WHOSolver.IterationCount, WHOSolver.IterationAverage);
                    chtProgress.Series[1].Points.AddXY(WHOSolver.IterationCount, WHOSolver.IterationBestObjective);
                    chtProgress.Series[2].Points.AddXY(WHOSolver.IterationCount, WHOSolver.SoFarTheBestObjective);

                    chtProgress.Update();
                    theProblem.DisplaySolutionsOnGraphics(WHOSolver.Solutions);
                }
                else
                {
                    chtProgress.Series[0].Points.AddXY(WHOSolver.IterationCount, WHOSolver.IterationAverage);
                    chtProgress.Series[1].Points.AddXY(WHOSolver.IterationCount, WHOSolver.IterationBestObjective);
                    chtProgress.Series[2].Points.AddXY(WHOSolver.IterationCount, WHOSolver.SoFarTheBestObjective);

                    theProblem.DisplaySolutionsOnGraphics(WHOSolver.Solutions);
                }

                chtProgress.Update();

                if (ckbShowSolutions.Checked)
                {
                    rtbSolutions.Clear();
                    for (int r = 0; r < WHOSolver.NumOfPopulation; r++)
                    {
                        rtbSolutions.AppendText($" solution {r}: ");
                        for (int c = 0; c < theProblem.Dimension; c++)
                        {
                            rtbSolutions.AppendText(WHOSolver.Solutions[r][c].ToString() + " ");
                        }
                        //rtbSolutions.AppendText($" individual best: ");
                        //for (int c = 0; c < theProblem.Dimension; c++)
                        //{
                        //    rtbSolutions.AppendText(WHOSolver.SelfBestSolutions[r][c].ToString() + " ");
                        //}
                        rtbSolutions.AppendText($"\n");
                    }
                }
            }
        }

        private void btnRunToEnd_Click(object sender, EventArgs e)
        {
            if (PSOSolver != null)
            {
                // in show animation mode
                while (PSOSolver.IterationCount < PSOSolver.IterationLimit)
                {
                    btnRunOneIteration_Click(null, null);
                }
                chtProgress.Update();
                // show final results on rich text box
                rtbSoFarTheBest.Clear();
                rtbSoFarTheBest.AppendText($"The Best Objective = {Math.Round(PSOSolver.SoFarTheBestObjective, 4)} \nThe Best Solution = ");
                for (int i = 0; i < PSOSolver.SoFarTheBestSolution.Length; i++)
                {
                    rtbSoFarTheBest.AppendText($"{Math.Round(PSOSolver.SoFarTheBestSolution[i],4)} ");
                }
                theProblem.DisplaySolutionsOnGraphics(PSOSolver.Solutions);
            }else if (WHOSolver != null)
            {
                // in show animation mode
                while (WHOSolver.IterationCount < WHOSolver.IterationLimit)
                {
                    btnRunOneIteration_Click(null, null);
                }
                chtProgress.Update();
                // show final results on rich text box
                rtbSoFarTheBest.Clear();
                rtbSoFarTheBest.AppendText($"The Best Objective = {Math.Round(WHOSolver.SoFarTheBestObjective,4)} \nThe Best Solution = ");
                for (int i = 0; i < WHOSolver.SoFarTheBestSolution.Length; i++)
                {
                    rtbSoFarTheBest.AppendText($"{Math.Round(WHOSolver.SoFarTheBestSolution[i],4)} ");
                }
                theProblem.DisplaySolutionsOnGraphics(WHOSolver.Solutions);
            }
        }
    }
}
