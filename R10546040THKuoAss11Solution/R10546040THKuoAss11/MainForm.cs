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

namespace R10546040THKuoAss11
{
    public partial class MainForm : Form
    {
        MLP theMLP;
        public MainForm()
        {
            InitializeComponent();
            theMLP = new MLP();
            propertyGrid1.SelectedObject = theMLP;
        }

        private void OpenCALFile(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() != DialogResult.OK) return;
            StreamReader sr = new StreamReader(dlgOpen.FileName);
            string str;
            string[] items;
            str = dlgOpen.FileName;
            items = str.Split('\\');
            label2.Text = "Data Set : " + items[items.Length - 1];
            theMLP.ReadInDataSet(sr, theMLP.TrainingRatio);
            sr.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (Series s in chtProgress.Series)
            {
                s.Points.Clear();
            }

            int[] numbers;
            numbers = new int[rtbHiddenLayerNeuronNumbers.Lines.Length];
            int id = 0;
            foreach (string line in rtbHiddenLayerNeuronNumbers.Lines)
            {
                numbers[id++] = Convert.ToInt32(line);
            }
            theMLP.ConfigureNeuralNetwork(numbers);
            theMLP.ResetWeightsAndInitialCondition();

            splitContainer3.Panel2.Refresh();
            labelRMSE.Text = ($"RMSE = ");
        }

        private void btnTrainAnEpoch_Click(object sender, EventArgs e)
        {
            theMLP.TrainAnEpoch();
            if (ckbAnimate.Checked)
            {
                chtProgress.Series[0].Points.AddXY(theMLP.EpochCount, theMLP.RootMeanSquareError);
                chtProgress.Update();
                labelRMSE.Text = ($"RMSE = " + theMLP.RootMeanSquareError);
            }
            splitContainer3.Panel2.Refresh();
        }

        private void btnTrainToEnd_Click(object sender, EventArgs e)
        {
            do
            {
                btnTrainAnEpoch_Click(null, null);
            } while (theMLP.EpochCount < theMLP.EpochLimit);
            labelRMSE.Text = ($"RMSE = " + theMLP.RootMeanSquareError);
        }

        private void btnClassificationTest_Click(object sender, EventArgs e)
        {
            labelCorrectness.Text = ($"Correctness = ");
        }

        void drawContent(Graphics g, Rectangle space)
        {
            Rectangle rect = Rectangle.Empty;
            rect.Width = (int)(space.Width * 0.8); // 500;
            rect.Height = (int)(space.Height * 0.8); //300;
            rect.X = 10;
            rect.Y = 5;
            Pen myPen = new Pen(Color.FromArgb(127, Color.Blue));
            myPen.Width = 5.0f;
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            myPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            g.FillRectangle(Brushes.DarkBlue, rect);
            g.DrawRectangle(Pens.AliceBlue, rect);
            g.FillEllipse(Brushes.Pink, rect);
            g.DrawEllipse(Pens.DarkBlue, rect);
            Point p1 = new Point(rect.X, rect.Y);
            Point p2 = new Point(rect.Right, rect.Bottom);

            //g.DrawLine(Pens.White, p1, p2);
            g.DrawLine(myPen, p1, p2);
            g.DrawString("Josey", this.Font, Brushes.LightPink, p1);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            Font myFont = new Font("微軟正黑體", 40);
            g.DrawString("Shuo", myFont, Brushes.Black, rect, sf);
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {
            // drawContent(e.Graphics, e.ClipRectangle);
            theMLP.DrawTheMLP(e.Graphics, e.ClipRectangle);
        }

        private void docMLP_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            theMLP.DrawTheMLP(e.Graphics, e.PageBounds);
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            dlgPrintPreview.ShowDialog();
        }
    }
}
