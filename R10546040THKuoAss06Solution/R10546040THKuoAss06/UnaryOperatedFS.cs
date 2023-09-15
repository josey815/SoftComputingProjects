using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class UnaryOperatedFS : FuzzySet
    {
        UnaryFSOperator theOperator;
        FuzzySet theOperand;

        public int OperandHashCode { get; set; }
        public FuzzySet TheOperand 
        { 
            get => theOperand; 
            set
            {
                if (theOperand != value)
                {
                    theOperand = value;
                    if (TheSeries != null)
                    {
                        UpdateSeries();
                    }
                    //describe shape changed event
                    theOperand.ShapeChanged += TheOperand_ShapeChanged;
                }
            } 
        }

        //static int count = 1;

        /// <summary>
        /// Constructor of a generic unary operator operated fuzzy set.
        /// </summary>
        /// <param name="theOperator"></param>
        /// <param name="theOperand"></param>

        public override void ExtraSave(StreamWriter sw)
        {
            // Save the hash code of the operand
            sw.WriteLine($"*OperandFSHashCode:{theOperand.GetHashCode()}");

            // Save the information of the operator
            sw.WriteLine($"*OperatorType:{theOperator.GetType().Name}");
            theOperator.Save(sw);
        }

        public override void ExtraOpen(StreamReader sr)
        {
            // read in the operand
            string[] items;
            items = sr.ReadLine().Split(':');
            OperandHashCode = Convert.ToInt32(items[1]);
            // read in type of the operator
            items = sr.ReadLine().Split(':');
            Type opType = Type.GetType($"R10546040FuzzySetNamespace.{items[1]}");
            theOperator = (UnaryFSOperator)Activator.CreateInstance(opType);
            theOperator.Open(sr);
        }

        public override void RebuildFuzzySetReferences(List<FuzzySet> newFSs)
        {
            foreach(FuzzySet fs in newFSs)
            {
                if (fs.SavedHashCode == OperandHashCode)
                {
                    TheOperand = fs;
                    break;
                }
            }
        }

        public UnaryOperatedFS(Universe u) : base(u)
        {

        }

        public UnaryOperatedFS(UnaryFSOperator theOperator, FuzzySet theOperand) : base(theOperand.TheUniverse)
        {
            this.theOperator = theOperator;
            this.theOperand = theOperand;
            title = $"{theOperator.Title}{theOperand.Title}";


            //if (theOperator.Parameters == 10000)
            //{
            //    title = $"{theOperator.Title}{count++}{theOperand.Title}";
            //}
            //else
            //{
            //    title = $"{theOperator.Title}{theOperator.Parameters}_{count++}_{theOperand.Title}";
            //}

            //Subscribe shapechanged event of the referenced fuzzy set
            theOperand.ShapeChanged += TheOperand_ShapeChanged;
        }

        private void TheOperand_ShapeChanged(object sender, EventArgs e)
        {
            //if (theOperator.Parameters == 10000)
            //{
            //    Title = $"{theOperator.Title}{count++}{theOperand.Title}";
            //}
            //else
            //{
            //    Title = $"{theOperator.Title}{theOperator.Parameters}_{count++}_{theOperand.Title}";
            //}
            ExecuteShapeChangedEvent();
        }

        public override double GetMemberShipDegree(double x)
        {
            if (theOperand == null || theOperator == null) return 0;
            double originalDegree = theOperand.GetMemberShipDegree(x);
            double degree = theOperator.GetValue(originalDegree);
            return degree;
        }
    }
}
