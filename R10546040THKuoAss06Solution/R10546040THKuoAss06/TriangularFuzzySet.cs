using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R10546040FuzzySetNamespace
{
    public class TriangularFuzzySet : FuzzySet
    {
        static int count = 1;

        // properties
        [Category("Parameters")]
        [Description("Left of a Triangular function. Value must be less than peak.")]
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
        [Description("Peak of a Triangular function. Value must be less than right & larger than left.")]
        public double Peak
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
        [Description("Right of a Triangular function. Value must be larger than peak.")]
        public double Right
        {
            get => parameters[2];
            set
            {
                if (value > parameters[1]) parameters[2] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        public override double MaxDegree => 1.0;
        public override double MOMCrispValue => parameters[1];
        public override double SOMCrispValue => parameters[1];
        public override double LOMCrispValue => parameters[1];
        public TriangularFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            title = $"Triangular{count++}";
            double peak = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) + theUniverse.LowerBound;
            double right = peak + randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            double left = peak - randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            parameters = new double[3] { left, peak, right }; // left, peak, right
        }

        public override double GetMemberShipDegree(double x)
        {
            //double left = parameters[0];
            //double peak = parameters[1];
            //double right = parameters[2];
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
                return (parameters[2] - x) / (parameters[2] - parameters[1]);
            }
            else if (parameters[2] <= x)
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
