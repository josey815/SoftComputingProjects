using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class SFuzzySet : FuzzySet
    {
        static int count = 1;

        // properties
        [Category("Parameters")]
        [Description("Left of a S function. Value must be less than right.")]
        public double Left
        {
            get => parameters[0];
            set
            {
                if (value < Right) parameters[0] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        [Category("Parameters")]
        [Description("Right of a S function. Value must be larger than left.")]
        public double Right
        {
            get => parameters[1];
            set
            {
                if (value > Left) parameters[1] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        public override double MaxDegree => 1.0;
        public override double MOMCrispValue => (parameters[1] + theUniverse.UpperBound) / 2;
        public override double SOMCrispValue => parameters[1];
        public override double LOMCrispValue => theUniverse.UpperBound;
        public override bool IsMonotonic => true;
        public override double GetUniverseValueForADegree(double degree)
        {
            if (degree == 0)
            {
                return (parameters[0] - theUniverse.LowerBound) / 2;
            }
            else if ( degree > 0 && degree < 2 * Math.Pow(((((parameters[0] + parameters[1]) / 2) - parameters[0]) / (parameters[1] - parameters[0])), 2))
            {
                return parameters[0] + (parameters[1] - parameters[0]) * Math.Pow(0.5 * degree, 0.5);
            }else if (degree > 2 * Math.Pow(((((parameters[0] + parameters[1]) / 2) - parameters[0]) / (parameters[1] - parameters[0])), 2) && degree < 1)
            {
                return parameters[1] - (parameters[1] - parameters[0]) * Math.Pow((1 - degree) / 2, 0.5);
            }
            else
            {
                return (theUniverse.UpperBound - parameters[1]) / 2;
            }
        }

        public SFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            title = $"S{count++}";
            double left = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            double right = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) / 4 + left;
            parameters = new double[2] { left, right }; // left, right
        }

        public override double GetMemberShipDegree(double x)
        {
            //double left = parameters[0];
            //double right = parameters[1];
            //double y;
            //y =

            if (x <= parameters[0])
            {
                return 0;
            }
            else if (x > parameters[0] && x <= ((parameters[0] + parameters[1])/2) )
            {
                return 2 *  Math.Pow(((x - parameters[0]) / (parameters[1] - parameters[0])), 2);
            }
            else if (x > ((parameters[0] + parameters[1]) / 2) && x < parameters[1])
            {
                return 1 - 2 * Math.Pow(((parameters[1] - x) / (parameters[1] - parameters[0])), 2);
            }
            else
            {
                return 1;
            }
        }
    }
}
