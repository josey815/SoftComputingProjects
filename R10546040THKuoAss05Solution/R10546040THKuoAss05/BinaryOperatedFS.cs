using System;
using System.Collections.Generic;
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
        static int count = 1;

        /// <summary>
        /// Constructor of a generic binary operator operated fuzzy set.
        /// </summary>
        /// <param name="theOperator"></param>
        /// <param name="theOperand_1"></param>
        /// <param name="theOperand_2></param>

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
