using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class SigmoidalFuzzySet : FuzzySet
    {
        static int count = 1;

        // properties

        [Category("Parameters")]
        [Description("Slope of a Sigmoidal function.")]
        public double Slope
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
        [Description("Center of a Sigmoidal function.")]
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

        public SigmoidalFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            title = $"Sigmoidal{count++}";
            double center = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) + theUniverse.LowerBound;
            double slope = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            parameters = new double[2] { slope, center }; // slope, center
        }

        public override double GetMemberShipDegree(double x)
        {
            //double slope = parameters[0];
            //double center = parameters[1];
            //double y;
            //y =

            return 1 / (1 + Math.Exp(-parameters[0] * (x - parameters[1])));
        }
    }
}
