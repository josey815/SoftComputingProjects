using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class BellFuzzySet : FuzzySet
    {
        static int count = 1;

        // properties

        [Category("Parameters")]
        [Description("Width of a bell function. Value must be positive.")]
        public double Width
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
        [Description("Slope of a bell function. Value must be positive.")]
        public double Slope
        {
            get => parameters[1];
            set
            {
                if (value > 0.0) parameters[1] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        [Category("Parameters")]
        [Description("Center of a bell function.")]
        public double Center
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
        public override double COACrispValue => parameters[2];
        public override double BOACrispValue => parameters[2];
        public override double MOMCrispValue => parameters[2];
        public override double SOMCrispValue => parameters[2];
        public override double LOMCrispValue => parameters[2];

        public BellFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            title = $"Bell{count++}";
            double center = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) + theUniverse.LowerBound;
            double width = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            double slope = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            parameters = new double[3] { width, slope, center }; // width, slope, center
        }

        public override double GetMemberShipDegree(double x)
        {
            //double width = parameters[0];
            //double slope = parameters[1];
            //double center = parameters[2];
            //double y;
            //y =

            return 1 / (1 + Math.Pow(Math.Abs((x - parameters[2]) / parameters[0]), 2 * parameters[1]));
        }
    }
}
