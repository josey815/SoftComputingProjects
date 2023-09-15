using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class PiFuzzySet : FuzzySet
    {
        static int count = 1;

        // properties
        [Category("Parameters")]
        [Description("Spread of a Pi function. Value must be positive.")]
        public double Spread
        {
            get => parameters[0];
            set
            {
                if (value > 0.0) parameters[0] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        [Category("Parameters")]
        [Description("Center of a Pi function.")]
        public double Center
        {
            get => parameters[1];
            set
            {
                parameters[1] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        public override double MaxDegree => 1.0;
        public override double COACrispValue => parameters[1];
        public override double BOACrispValue => parameters[1];
        public override double MOMCrispValue => parameters[1];
        public override double SOMCrispValue => parameters[1];
        public override double LOMCrispValue => parameters[1];

        public PiFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            title = $"Pi{count++}";
            double spread = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            double center = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            parameters = new double[2] {spread, center}; // spread, center
        }

        public override double GetMemberShipDegree(double x)
        {
            //double spread = parameters[0];
            //double center = parameters[1];
            //double y;
            //y =

            if (x <= parameters[1])
            {
                // l=c-a, r=c
                // l=(parameters[1]-parameters[0])
                // r=parameters[1]
                if (x <= (parameters[1] - parameters[0]))
                {
                    return 0;
                }
                else if (x > (parameters[1] - parameters[0]) & x <= (((parameters[1] - parameters[0]) + parameters[1]) / 2))
                {
                    return 2 * Math.Pow(((x - (parameters[1] - parameters[0])) / parameters[0]), 2);
                }
                else if (x > (((parameters[1] - parameters[0]) + parameters[1]) / 2) & x <= parameters[1])
                {
                    return 1 - 2 * Math.Pow(((parameters[1] - x) / parameters[0]), 2);
                }
                else
                {
                    return 1;
                }
            }
            else if (x > parameters[1])
            {
                //l=c, r=c+a
                //l=parameters[1]
                //r=parameters[1]+parameters[0]
                if (x > parameters[1] & x <= ((parameters[1] + parameters[0] + parameters[1]) / 2)) //l<x<=(l+r)/2
                {
                    return 1 - 2 * Math.Pow(((x - parameters[1]) / parameters[0]), 2);
                }
                else if (x > ((parameters[1] + parameters[0] + parameters[1]) / 2) & x <= (parameters[1] + parameters[0])) //(l+r)/2<x<=r
                {
                    return 2 * Math.Pow(((parameters[1] + parameters[0] - x) / parameters[0]), 2);
                }
                else if (x > (parameters[1] + parameters[0])) // r<x
                {
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
