using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class BinaryOperatedFS : FuzzySet
    {
        BinaryFSOperator theOperator;
        FuzzySet theOperand_1;
        FuzzySet theOperand_2;

        public int Operand1HashCode { get; set; }
        public int Operand2HashCode { get; set; }
        //static int count = 1;

        /// <summary>
        /// Constructor of a generic binary operator operated fuzzy set.
        /// </summary>
        /// <param name="theOperator"></param>
        /// <param name="theOperand_1"></param>
        /// <param name="theOperand_2></param>

        public override void ExtraSave(StreamWriter sw)
        {
            // Save the hash code of the operand_1
            sw.WriteLine($"*Operand1FSHashCode:{theOperand_1.GetHashCode()}");
            sw.WriteLine($"*Operand2FSHashCode:{theOperand_2.GetHashCode()}");

            // Save the information of the operator
            sw.WriteLine($"*OperatorType:{theOperator.GetType().Name}");
            theOperator.Save(sw);
        }

        public override void ExtraOpen(StreamReader sr)
        {
            // read in the operand
            string[] items;
            items = sr.ReadLine().Split(':');
            Operand1HashCode = Convert.ToInt32(items[1]);
            items = sr.ReadLine().Split(':');
            Operand2HashCode = Convert.ToInt32(items[1]);
            // read in type of the operator
            items = sr.ReadLine().Split(':');
            Type opType = Type.GetType($"R10546040FuzzySetNamespace.{items[1]}");
            theOperator = (BinaryFSOperator)Activator.CreateInstance(opType);
            theOperator.Open(sr);
        }

        public override void RebuildFuzzySetReferences(List<FuzzySet> newFSs)
        {
            foreach (FuzzySet fs in newFSs)
            {
                if (fs.SavedHashCode == Operand1HashCode)
                {
                    theOperand_1 = fs;
                    break;
                }else if (fs.SavedHashCode == Operand2HashCode)
                {
                    theOperand_2 = fs;
                    break;
                }
                else
                {
                    return;
                }
            }
        }

        public BinaryOperatedFS(BinaryFSOperator theOperator, FuzzySet theOperand_1, FuzzySet theOperand_2) : base(theOperand_1.TheUniverse)
        {
            this.theOperator = theOperator;
            this.theOperand_1 = theOperand_1;
            this.theOperand_2 = theOperand_2;
            title = $"{theOperand_1.Title}{theOperator.Title}{theOperand_2.Title}";

            //if (theOperator.Parameters == 10000)
            //{
            //    title = $"{theOperand_1.Title}{theOperator.Title}{count++}{theOperand_2.Title}";
            //}
            //else
            //{
            //    title = $"{theOperand_1.Title}{theOperator.Title}{theOperator.Parameters}_{count++}_{theOperand_2.Title}";
            //}

            //Subscribe shapechanged event of the referenced fuzzy set 
            theOperand_1.ShapeChanged += TheOperand_ShapeChanged;
            theOperand_2.ShapeChanged += TheOperand_ShapeChanged;
        }

        private void TheOperand_ShapeChanged(object sender, EventArgs e)
        {
            //if (theOperator.Parameters == 10000)
            //{
            //    Title = $"{theOperator.Title}{count++}{theOperand_1.Title}{theOperand_2.Title}";
            //}
            //else
            //{
            //    Title = $"{theOperator.Title}{theOperator.Parameters}_{count++}_{theOperand_1.Title}{theOperand_2.Title}";
            //}
            ExecuteShapeChangedEvent();
        }

        public override double GetMemberShipDegree(double x)
        {
            double originalDegree_1 = theOperand_1.GetMemberShipDegree(x);
            double originalDegree_2 = theOperand_2.GetMemberShipDegree(x);
            double degree = theOperator.GetValue(originalDegree_1, originalDegree_2);
            return degree;
        }
    }
}
