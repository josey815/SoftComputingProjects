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
using TSPBenchmark;

namespace R10546040THKuoAss09
{
    public partial class MainForm : Form
    {
        int[] greedySolution = null;
        double greedyLength;
        AntColonyOptimizer mySolver;
        double[,] heuristicMatrix;

        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int result = TSPBenchmarkProblem.ImportATSPFile(true, true);
            if (result < 0) return;
            greedySolution = TSPBenchmarkProblem.GetGreedyShortestRoute();
            splitContainer3.Panel2.Refresh();
            greedyLength = TSPBenchmarkProblem.ComputeObjectiveValue(greedySolution);

            // Prepare heuristic matrix
            heuristicMatrix = new double[TSPBenchmarkProblem.NumberOfCities, TSPBenchmarkProblem.NumberOfCities];
            for (int i = 0; i < TSPBenchmarkProblem.NumberOfCities; i++)
            {
                for (int j = 0; j < TSPBenchmarkProblem.NumberOfCities; j++)
                {
                    heuristicMatrix[i, j] = 1.0 / TSPBenchmarkProblem.FromToDistanceMatrix[i,j];
                }
            }

            labMessage.Text = $"Problem {Path.GetFileName(TSPBenchmarkProblem.TspFilePath)} greedy length = {greedyLength}";
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {
            if (greedySolution == null) 
            {
                return;
            }else if (mySolver == null || mySolver.IterationCount == 0)
            {
                TSPBenchmarkProblem.DrawCitiesOptimalRouteAndARoute(e.Graphics, e.ClipRectangle.Width, e.ClipRectangle.Height, greedySolution);

            }
            else
            {
                TSPBenchmarkProblem.DrawCitiesOptimalRouteAndARoute(e.Graphics, e.ClipRectangle.Width, e.ClipRectangle.Height, mySolver.SoFarTheBestSolution);
            }
        }

        private void btnCreateACO_Click(object sender, EventArgs e)
        {
            if (rdbACS.Checked) mySolver = new AntColonySystem(TSPBenchmarkProblem.NumberOfCities, OptimizationType.Minimization,
                TSPBenchmarkProblem.ComputeObjectiveValue, heuristicMatrix);
            else if (rdbAS.Checked)
                mySolver = new AntSystem(TSPBenchmarkProblem.NumberOfCities, OptimizationType.Minimization,
                    TSPBenchmarkProblem.ComputeObjectiveValue, heuristicMatrix);

            prgACO.SelectedObject = mySolver;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            if (mySolver != null)
            {
                mySolver.Reset();
                splitContainer3.Panel2.Refresh();

                rtbPheromone.Clear();
                rtbSolutions.Clear();
                rtbSoFarTheBest.Clear();
                foreach (Series s in chtProgress.Series)
                {
                    s.Points.Clear();
                }

                if (ckbShowSolutions.Checked)
                {
                    for (int r = 0; r < mySolver.NumberOfAnts; r++)
                    {
                        rtbSolutions.AppendText($" solution {r}: ");
                        for (int c = 0; c < mySolver.NumberOfVariables; c++)
                        {
                            rtbSolutions.AppendText(mySolver.Solutions[r][c].ToString() + " ");
                        }
                        rtbSolutions.AppendText($" obj = {mySolver.Objectives[r]}\n");
                    }
                }

                if (ckbShowPheromone.Checked)
                {
                    for (int r = 0; r < mySolver.NumberOfVariables; r++)
                    {
                        for (int c = 0; c < mySolver.NumberOfVariables; c++)
                        {
                            rtbPheromone.AppendText(mySolver.PheromoneMatrix[r, c].ToString() + " ");
                        }
                        rtbPheromone.AppendText($"\n");
                    }
                }
            }
        }

        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            if (mySolver != null)
            {
                mySolver.RunOneIteration();

                if (cbxAnimation.Checked)
                {
                    chtProgress.Series[0].Points.AddXY(mySolver.IterationCount, mySolver.IterationObjectiveAverage);
                    chtProgress.Series[1].Points.AddXY(mySolver.IterationCount, mySolver.IterationBestObjective);
                    chtProgress.Series[2].Points.AddXY(mySolver.IterationCount, mySolver.SoFarTheBestObjective);

                    chtProgress.Update();
                    splitContainer3.Panel2.Refresh();
                }
                else
                {
                    chtProgress.Series[0].Points.AddXY(mySolver.IterationCount, mySolver.IterationObjectiveAverage);
                    chtProgress.Series[1].Points.AddXY(mySolver.IterationCount, mySolver.IterationBestObjective);
                    chtProgress.Series[2].Points.AddXY(mySolver.IterationCount, mySolver.SoFarTheBestObjective);

                    splitContainer3.Panel2.Refresh();
                }

                if (ckbShowSolutions.Checked)
                {
                    rtbSolutions.Clear();
                    for (int r = 0; r < mySolver.NumberOfAnts; r++)
                    {
                        rtbSolutions.AppendText($" solution {r}: ");
                        for (int c = 0; c < mySolver.NumberOfVariables; c++)
                        {
                            rtbSolutions.AppendText(mySolver.Solutions[r][c].ToString() + " ");
                        }
                        rtbSolutions.AppendText($" obj = {mySolver.Objectives[r]}\n");
                    }
                }

                if (ckbShowPheromone.Checked)
                {
                    rtbPheromone.Clear();
                    for (int r = 0; r < mySolver.NumberOfVariables; r++)
                    {
                        for (int c = 0; c < mySolver.NumberOfVariables; c++)
                        {
                            rtbPheromone.AppendText(mySolver.PheromoneMatrix[r, c].ToString() + " ");
                        }
                        rtbPheromone.AppendText($"\n");
                    }
                }
            }
        }

        private void btnRunToEnd_Click(object sender, EventArgs e)
        {
            // btnRunOneIteration_Click
            //mySolver.RunToEnd();

            if (mySolver != null)
            {
                // in show animation mode
                while (mySolver.IterationCount < mySolver.IterationLimit)
                {
                    btnRunOneIteration_Click(null, null);
                }

                splitContainer3.Panel2.Refresh();
                // show final results on rich text box
                rtbSoFarTheBest.Clear();
                rtbSoFarTheBest.AppendText($"The Best Objective = {mySolver.SoFarTheBestObjective} \nThe Best Solution = ");
                for (int i = 0; i < mySolver.SoFarTheBestSolution.Length; i++)
                {
                    rtbSoFarTheBest.AppendText($"{mySolver.SoFarTheBestSolution[i]} ");
                }
            }
            splitContainer3.Panel2.Refresh();
        }
    }
}
