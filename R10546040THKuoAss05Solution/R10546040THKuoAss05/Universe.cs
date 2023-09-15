using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;

namespace R10546040FuzzySetNamespace
{
    // delegate definition
    public delegate void MyFunction(int i);

    public class Universe
    {
        static int count = 1;
        //public string title;
        double lowerBound = 0;
        double upperBound = 10;
        double increment = 0.05;
        ChartArea theArea;
        TreeNode theNode;
        Legend theLegend;

        public event EventHandler BoundChanged;

        // C# Property definition

        public string Title
        {
            get
            {
                return theArea.AxisX.Title;
            }
            set
            {
                theArea.AxisX.Title = value;
                theNode.Text = value;
            }
        }

        public double LowerBound
        {
            // Lumbda operator
            get => lowerBound;
            set
            {
                if (value <= upperBound)
                {
                    lowerBound = value;
                    theArea.AxisX.Minimum = lowerBound;
                    // Trigger bound changed event
                    if(BoundChanged != null)
                    {
                        // executed the linked method
                        BoundChanged(this, null);
                    }
                }
            }
        }

        public double UpperBound 
        {
            get => upperBound;
            set
            {
                if (value >= lowerBound)
                {
                    upperBound = value;
                    theArea.AxisX.Maximum = upperBound;
                    increment = (upperBound - lowerBound) / 200; // resolution setting
                    // Trigger bound changed event
                    if (BoundChanged != null)
                    {
                        // executed the linked method
                        BoundChanged(this, null);
                    }
                }
            }
        }

        public double Increment
        {
            get => increment;
            set
            {
                increment = (upperBound - lowerBound) / 200;
            }
        }

        [Browsable(false)]
        public ChartArea TheArea { get => theArea; }
        
        [Browsable(false)]
        public Legend TheLegend { get => theLegend; }
        
        [Browsable(false)]
        public TreeNode TheNode { get => theNode; }


        public Universe()
        {
            theArea = new ChartArea();
            theArea.AxisX.Enabled = theArea.AxisY.Enabled = AxisEnabled.True;
            theArea.AxisY.Title = "Degree";
            theArea.Name = theArea.AxisX.Title = $"Universe{count++}";
            theArea.AxisX.Minimum = lowerBound;
            theArea.AxisX.Maximum = upperBound;

            theLegend = new Legend();
            theLegend.Name = theArea.AxisX.Title;
            theLegend.Docking = Docking.Bottom;
            theLegend.IsDockedInsideChartArea = false;
            theLegend.Alignment = System.Drawing.StringAlignment.Center;
            theLegend.DockedToChartArea = theArea.Name;

            theNode = new TreeNode();
            theNode.Tag = this;
            theNode.Text = theArea.AxisX.Title;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
