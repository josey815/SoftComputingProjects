using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class GaussianFuzzySet : FuzzySet
    {
        static int count = 1;

        // properties
        [Category("Parameters")]
        [Description("Center of a gaussian function.")]
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
        [Description("Standard deviation of a gaussian function. Value must be positive.")]
        public double StandardDeviation
        {
            get => parameters[1];
            set
            {
                if (value > 0.0) parameters[1] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        public override double MaxDegree => 1.0;

        public GaussianFuzzySet( Universe theUniverse) : base(theUniverse)
        {
            title = $"Gaussian{count++}";
            double c = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) + theUniverse.LowerBound;
            double std = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) / 5.0;
            parameters = new double[2] { c, std }; // mean & std
        }

        public override double GetMemberShipDegree(double x)
        {
            return Math.Exp(-0.5 * (x - parameters[0]) * (x - parameters[0]) / parameters[1] / parameters[1]);
        }
    }
}
