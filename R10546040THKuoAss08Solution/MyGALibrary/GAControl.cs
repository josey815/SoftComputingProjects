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

namespace MyGALibrary
{
    public partial class GAControl<T> : UserControl
    {
        GenericGASolver<T> gasolver;
        public GAControl(GenericGASolver<T> ga)
        {
            gasolver = ga;
            InitializeComponent();
            prgGA.SelectedObject = ga;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (gasolver != null)
            {
                gasolver.Reset();

                rtb.Clear();
                rtbSoFarTheBest.Clear();
                foreach (Series s in chtProgress.Series)
                {
                    s.Points.Clear();
                }

                for (int r = 0; r < gasolver.PopulationSize; r++)
                {
                    rtb.AppendText($" p{r}: ");
                    for (int c = 0; c < gasolver.NumberOfGenes; c++)
                    {
                        rtb.AppendText(gasolver.Chromosomes[r][c].ToString() + " ");
                    }
                    rtb.AppendText($" obj = {gasolver.ObjectiveValues[r]}\n");
                }
            }
        }

        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            if (gasolver != null)
            {
                gasolver.RunOneIteration();

                if (cbxAnimate.Checked)
                {
                    rtb.Clear();

                    for (int r = 0; r < gasolver.Chromosomes.Length; r++)
                    {
                        rtb.AppendText($" {r}: ");
                        for (int c = 0; c < gasolver.NumberOfGenes; c++)
                        {
                            rtb.AppendText(gasolver.Chromosomes[r][c].ToString() + " ");
                        }
                        rtb.AppendText($" obj = {gasolver.ObjectiveValues[r]}\n");
                    }

                    chtProgress.Series[0].Points.AddXY(gasolver.IterationCount, gasolver.IterationObjectiveAverage);
                    chtProgress.Series[1].Points.AddXY(gasolver.IterationCount, gasolver.IterationBestObjective);
                    chtProgress.Series[2].Points.AddXY(gasolver.IterationCount, gasolver.SoFarTheBestObjective);

                    chtProgress.Update();
                }
                else
                {
                    chtProgress.Series[0].Points.AddXY(gasolver.IterationCount, gasolver.IterationObjectiveAverage);
                    chtProgress.Series[1].Points.AddXY(gasolver.IterationCount, gasolver.IterationBestObjective);
                    chtProgress.Series[2].Points.AddXY(gasolver.IterationCount, gasolver.SoFarTheBestObjective);
                }
            }
        }

        private void btnRunToEnd_Click(object sender, EventArgs e)
        {
            if (gasolver != null)
            {
                // in hide animation mode
                // myBinaryGASolver.RunToEnd();

                // in show animation mode
                while (gasolver.IterationCount < gasolver.IterationLimit)
                {
                    btnRunOneIteration_Click(null, null);
                }

                // show final results on rich text box
                rtbSoFarTheBest.Clear();
                rtbSoFarTheBest.AppendText($"The Best Objective = {gasolver.SoFarTheBestObjective} \nThe Best Solution = ");
                for (int i = 0; i < gasolver.SoFarTheBestSolution.Length; i++)
                {
                    rtbSoFarTheBest.AppendText($"{gasolver.SoFarTheBestSolution[i]} ");
                }
            }
        }
    }
}
