using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class LeftRightFuzzySet : FuzzySet
    {
        static int count = 1;

        // properties
        [Category("Parameters")]
        [Description("Center of a left-right function.")]
        public double Center
        {
            get => parameters[0];
            set
            {
                parameters[0] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        [Category("Parameters")]
        [Description("Alpha of a left-right function.")]
        public double Alpha
        {
            get => parameters[1];
            set
            {
                parameters[1] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        [Category("Parameters")]
        [Description("Beta of a left-right function.")]
        public double Beta
        {
            get => parameters[2];
            set
            {
                parameters[2] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        public override double MaxDegree => 1.0;
        public override double MOMCrispValue => parameters[0];
        public override double SOMCrispValue => parameters[0];
        public override double LOMCrispValue => parameters[0];
        public LeftRightFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            title = $"LeftRight{count++}";
            double center = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) + theUniverse.LowerBound;
            double alpha = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            double beta = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            parameters = new double[3] { center, alpha, beta }; // center, alpha, beta
        }

        public override double GetMemberShipDegree(double x)
        {
            //double center = parameters[0];
            //double alpha = parameters[1];
            //double beta = parameters[2];
            //double y;
            //y =

            if (x <= parameters[0])
            {
                return Math.Sqrt(Math.Max(0, 1 - ((parameters[0] - x) / parameters[1]) * ((parameters[0] - x) / parameters[1])));
            }
            else if (x >= parameters[0])
            {
                return Math.Exp(-Math.Pow(Math.Abs((x - parameters[0]) / parameters[2]), 3));
            }
            else
            {
                return 0;
            }
        }
    }
}
