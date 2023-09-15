using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class UnaryOperatedFS : FuzzySet
    {
        UnaryFSOperator theOperator;
        FuzzySet theOperand;
        static int count = 1;

        /// <summary>
        /// Constructor of a generic unary operator operated fuzzy set.
        /// </summary>
        /// <param name="theOperator"></param>
        /// <param name="theOperand"></param>

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
            double originalDegree = theOperand.GetMemberShipDegree(x);
            double degree = theOperator.GetValue(originalDegree);
            return degree;
        }
    }
}
