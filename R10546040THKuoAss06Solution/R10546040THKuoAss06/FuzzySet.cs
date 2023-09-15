using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace R10546040FuzzySetNamespace
{
    public class FuzzySet
    {
        #region OPERATOR OVERLOADING

        // Negate Operation
        static public FuzzySet operator! (FuzzySet operand)
        {
            return new UnaryOperatedFS(new Negate(), operand);
        }

        // Value-Cut Operation
        static public FuzzySet operator -(double value, FuzzySet operand)
        {
            return new UnaryOperatedFS(new ValueCut(value), operand);
        }

        // Intersection Operation
        static public FuzzySet operator& (FuzzySet operand1, FuzzySet operand2)
        {
            return new BinaryOperatedFS(new Intersection(), operand1, operand2);
        }

        // Union Operation
        static public FuzzySet operator| (FuzzySet operand1, FuzzySet operand2)
        {
            return new BinaryOperatedFS(new Union(), operand1, operand2);
        }

        // Sum Operation
        static public FuzzySet operator+ (FuzzySet operand1, FuzzySet operand2)
        {
            return new BinaryOperatedFS(new AlgebraicSum(), operand1, operand2);
        }

        // Product Operation
        static public FuzzySet operator* (FuzzySet operand1, FuzzySet operand2)
        {
            return new BinaryOperatedFS(new AlgebraicProduct(), operand1, operand2);
        }

        // Scale Operation
        static public FuzzySet operator *(double value, FuzzySet operand)
        {
            return new UnaryOperatedFS(new Scale(value), operand);
        }

        #endregion

        #region DATA FIELDS
        protected Random randomizer = new Random();
        protected double[] parameters;
        protected string title;
        protected Series theSeries;
        protected Universe theUniverse;
        protected TreeNode theNode;
        protected bool visualDisplay = false;
        protected bool visualDisplay_infer = false;
        #endregion

        #region EVENTS & PROPERTIES
        public event EventHandler ShapeChanged;

        public virtual double GetUniverseValueForADegree(double degree)
        {
            throw new Exception("");
        }

        public virtual bool IsMonotonic { get; set; } = false;

        [Browsable(false)]
        public virtual double LOMCrispValue
        {
            get
            {
                int i = 0;
                double LOM = 0;
                double maxValue = 0;
                double[] zValue = new double[(int)((theUniverse.UpperBound - theUniverse.LowerBound) / theUniverse.Increment)];

                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    if (GetMemberShipDegree(x) > maxValue)
                    {
                        maxValue = GetMemberShipDegree(x);
                    }
                }
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    if (GetMemberShipDegree(x) == maxValue)
                    {
                        zValue[i] = x;
                        i++;
                    }
                }

                LOM = zValue[i-1];
                return LOM;
            }
        }

        [Browsable(false)]
        public virtual double SOMCrispValue
        {
            get
            {
                int i = 0;
                double SOM = 0;
                double maxValue = 0;
                double[] zValue = new double[(int)((theUniverse.UpperBound - theUniverse.LowerBound) / theUniverse.Increment)];

                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    if (GetMemberShipDegree(x) > maxValue)
                    {
                        maxValue = GetMemberShipDegree(x);
                    }
                }
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    if (GetMemberShipDegree(x) == maxValue)
                    {
                        zValue[i] = x;
                        i++;
                        break;
                    }
                }

                SOM = zValue[0];
                return SOM;
            }
        }

        [Browsable(false)]
        public virtual double MOMCrispValue
        {
            get
            {
                int i = 0;
                double MOM = 0;
                double maxValue = 0;
                double[] zValue = new double[(int)((theUniverse.UpperBound-theUniverse.LowerBound)/ theUniverse.Increment)];

                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    if (GetMemberShipDegree(x) > maxValue)
                    {
                        maxValue = GetMemberShipDegree(x);
                    }
                }
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    if (GetMemberShipDegree(x) == maxValue)
                    {
                        zValue[i] = x;
                        i++;
                    }
                }

                MOM = (zValue[0] + zValue[i - 1]) / 2;
                return MOM;
            }
        }

        [Browsable(false)]
        public virtual double BOACrispValue
        {
            get
            {
                double area1 = 0;
                double areaTotal = 0;
                double BOA = 0;
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    double deltaArea = GetMemberShipDegree(x) * theUniverse.Increment;
                    areaTotal += deltaArea;
                }
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    double deltaArea = GetMemberShipDegree(x) * theUniverse.Increment;
                    area1 += deltaArea;
                    if (area1 == (areaTotal * 0.5))
                    {
                        BOA = x;
                    }
                }
                return BOA;
            }
        }

        [Browsable(false)]
        public virtual double COACrispValue
        {
            get
            {
                double area = 0;
                double sumOfxTimesDeltaArea = 0;
                double COA = 0;
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    double deltaArea = GetMemberShipDegree(x) * theUniverse.Increment;
                    area += deltaArea;
                    sumOfxTimesDeltaArea += x * deltaArea;
                }

                if (area > 0)
                {
                    COA =  sumOfxTimesDeltaArea / area;
                }
                else
                {
                    COA = (theUniverse.UpperBound + theUniverse.LowerBound) / 2;
                }
                return COA;
            }
        }

        public virtual double MaxDegree
        {
            get
            {
                // if the series exists, find the maximal value of y
                double maxDegree = double.MinValue;
                if (theSeries == null)
                {
                    for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                    {
                        double y = GetMemberShipDegree(x);
                        if (maxDegree < y) maxDegree = y;
                    }
                }
                else
                {
                    // traverse datapoints of the series
                    foreach( DataPoint dp in theSeries.Points)
                    {
                        double y = dp.YValues[0];
                        if (maxDegree < y) maxDegree = y;
                    }

                }
                return maxDegree;
            }
        }

        // properties
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Browsable(false)]
        public Universe TheUniverse
        {
            get => theUniverse;
        }

        public TreeNode TheNode
        {
            get => this.theNode;
            //set
            //{
            //    theNode = value;
            //    if (theSeries != null)
            //    {
            //        theNode.Text = theSeries.Name;
            //    }
            //}
        }

        public string Title
        {
            get => title;
           
            set
            {
                title = value;
                theSeries.Name = value;
                theNode.Text = value;
                ExecuteShapeChangedEvent();
            }
        }

        [Browsable(false)]
        public Series TheSeries { get => theSeries; }

        public bool VisualDisplay 
        {
            get => visualDisplay;
            set
            {
                if (value && !visualDisplay)
                {
                    visualDisplay = value;
                    // instantiate series and treenode objects
                    if (theSeries == null)
                    {
                        theSeries = new Series();
                        theSeries.ChartType = SeriesChartType.Line;
                        theSeries.BorderWidth = 2;
                        theSeries.Name = title;
                        theSeries.ChartArea = theUniverse.TheArea.Name;
                        theSeries.Legend = theUniverse.TheLegend.Name;
                        UpdateSeries(); 
                    }
                    if (theNode == null)
                    {
                        theNode = new TreeNode();
                        theNode.Tag = this;
                        theNode.Text = title;
                        TheUniverse.TheNode.Nodes.Add(TheNode);
                    }

                }
            }
        }

        public bool VisualDisplayInfer
        {
            get => visualDisplay_infer;
            set
            {
                if (value && !visualDisplay_infer)
                {
                    visualDisplay_infer = value;
                    // instantiate series and treenode objects
                    if (theSeries == null)
                    {
                        theSeries = new Series();
                        theSeries.ChartType = SeriesChartType.Line;
                        theSeries.BorderWidth = 2;
                        theSeries.Name = title;
                        theSeries.ChartArea = theUniverse.TheArea.Name;
                        theSeries.Legend = theUniverse.TheLegend.Name;
                        UpdateSeries();
                    }
                }
            }
        }
        #endregion

        #region CTOR

        public FuzzySet(Universe theUniverse)
        {
            this.theUniverse = theUniverse;
            //theSeries = new Series();
            //theSeries.ChartType = SeriesChartType.Line;
            //theSeries.Name = "FS";
            //theSeries.ChartArea = theUniverse.TheArea.Name;

            //subscribe bound changed event of the universe
            this.theUniverse.BoundChanged += TheUniverse_BoundChanged;
        }
        #endregion

        #region PUBLIC (INTERFACE) FUNCTIONS

        public override string ToString()
        {
            return title;
        }

        protected void ExecuteShapeChangedEvent()
        {
            UpdateSeries();
            if (ShapeChanged != null)
            {
                ShapeChanged(this, null);
            }
        }
        private void TheUniverse_BoundChanged(object sender, EventArgs e)
        {
            UpdateSeries();
        }

        public void UpdateSeries()
        {
            if (theUniverse == null) return;
                theSeries.Points.Clear();
                for (double x = theUniverse.LowerBound; x <= theUniverse.UpperBound; x += theUniverse.Increment)
                {
                    double y = GetMemberShipDegree(x);
                    theSeries.Points.AddXY(x, y);
                }
        }

        public virtual double GetMemberShipDegree(double x)
        {
            throw new NotImplementedException();
        }

        public virtual void ExtraOpen(StreamReader sr)
        {

        }

        public virtual void ExtraSave(StreamWriter sw)
        {

        }

        public virtual void RebuildFuzzySetReferences(List<FuzzySet> newFSs)
        {

        }

        public void Open(StreamReader sr)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            SavedHashCode = Convert.ToInt32(items[1]);
            items = sr.ReadLine().Split(':');
            title = items[1];
            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32(items[1]);
            parameters = new double[num];
            for (int i = 0; i < num; i++)
            {
                items = sr.ReadLine().Split(':');
                parameters[i] = Convert.ToDouble(items[1]);
            }
            Title = title;

            //items = sr.ReadLine().Split(':');
            //VisualDisplay = Convert.ToBoolean(items[1]);
            ////items = sr.ReadLine().Split(':');
            ////VisualDisplayInfer = Convert.ToBoolean(items[1]);
            //items = sr.ReadLine().Split(':');
            //IsMonotonic = Convert.ToBoolean(items[1]);
            //items = sr.ReadLine().Split(':');
            //MaxDegree = Convert.ToBoolean(items[1]);

            // invoke derived extra data
            ExtraOpen(sr);
        }

        [Browsable(false)]
        public int SavedHashCode { set; get; }

        public void Save(StreamWriter sw)
        {
            sw.WriteLine($"*OriginHashCode:{this.GetHashCode()}");
            sw.WriteLine($"Title:{title}");
            int numberOfParameters = 0;
            if (parameters != null)
            {
                numberOfParameters = parameters.Length;
            }
            sw.WriteLine($"NumberOfParameters:{numberOfParameters}");
            for( int i = 0; i < numberOfParameters; i++)
            {
                sw.WriteLine($"Par{i}:{parameters[i]}");
            }
            //sw.WriteLine($"VisualDisplay:{visualDisplay}");
            ////sw.WriteLine($"VisualDisplay_infer:{visualDisplay_infer}");
            //sw.WriteLine($"IsMonotonic:{IsMonotonic}");
            ////sw.WriteLine($"MaxDegree:{MaxDegree}");

            // invoke extra data save
            ExtraSave(sw);
        }
        #endregion
    }
}
