using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class TrapezoidalFuzzySet : FuzzySet
    {
        static int count = 1;

        // properties
        [Category("Parameters")]
        [Description("Left of a Trapezoidal function. Value must be less than left peak.")]
        public double Left
        {
            get => parameters[0];
            set
            {
                if (value < parameters[1]) parameters[0] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        [Category("Parameters")]
        [Description("Left peak of a Trapezoidal function. Value must be less than right peak & larger than left.")]
        public double Peak_L
        {
            get => parameters[1];
            set
            {
                if (value > parameters[0] & value < parameters[2]) parameters[1] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        [Category("Parameters")]
        [Description("Right peak of a Trapezoidal function. Value must be less than right & larger than left peak.")]
        public double Peak_R
        {
            get => parameters[2];
            set
            {
                if (value > parameters[1] & value < parameters[3]) parameters[2] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        [Category("Parameters")]
        [Description("Right of a Trapezoidal function. Value must be larger than right peak.")]
        public double Right
        {
            get => parameters[3];
            set
            {
                if (value > parameters[2]) parameters[3] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        public override double MaxDegree => 1.0;
        public override double MOMCrispValue => (parameters[1] + parameters[2]) / 2;
        public override double SOMCrispValue => parameters[1];
        public override double LOMCrispValue => parameters[2];

        public TrapezoidalFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            title = $"Trapezoidal{count++}";
            double peak_L = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) + theUniverse.LowerBound;
            double left = peak_L - randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) / 4;
            double peak_R = peak_L + randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) / 4;
            double right = peak_R + randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) / 4;
            parameters = new double[4] { left, peak_L, peak_R, right }; // left, peak_L, peak_R, right
        }

        public override double GetMemberShipDegree(double x)
        {
            //double left = parameters[0];
            //double peak_L = parameters[1];
            //double peak_R = parameters[2];
            //double right = parameters[3];
            //double y;
            //y =

            if (x <= parameters[0])
            {
                return 0;
            }
            else if (x <= parameters[1])
            {
                return (x - parameters[0]) / (parameters[1] - parameters[0]);
            }
            else if (x <= parameters[2])
            {
                return 1;
            }
            else if (x <= parameters[3])
            {
                return (parameters[3] - x)/(parameters[3] - parameters[2]);
            }
            else if (x >= parameters[3])
            {
                return 0;
            }
            else
            {
                return 0;
            }
        }
    }
}
