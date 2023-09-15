using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class StepUpFuzzySet : FuzzySet
    {
        static int count = 1;

        // properties
        [Category("Parameters")]
        [Description("Left of a step-up function.")]
        public double Left
        {
            get => parameters[0];
            set
            {
                if (value < parameters[1])
                {
                    parameters[0] = value;
                }
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        [Category("Parameters")]
        [Description("Right of a step-up function.")]
        public double Right
        {
            get => parameters[1];
            set
            {
                if (value > parameters[0]) parameters[1] = value;
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        public override double MaxDegree => 1.0;

        public override bool IsMonotonic => true;

        public override double GetUniverseValueForADegree(double degree)
        {
            //if (degree == 0)
            //{
            //    return (parameters[0] - theUniverse.LowerBound) / 2;
            //}
            //else if (degree > 0 && degree < 1)
            //{
                return degree * (parameters[1] - parameters[0]) + parameters[0];
        //}
        //    else
        //    {
        //        return (theUniverse.UpperBound - parameters[1]) / 2;
        //    }
}

        public StepUpFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            title = $"StepUp{count++}";
            double left = 0.3 * randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound) + theUniverse.LowerBound;
            double right = left + 0.5 * randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            parameters = new double[2] { left, right }; // left & right
        }

        public override double GetMemberShipDegree(double x)
        {
            if (x <= parameters[0])
            {
                return 0;
            }
            else if (x > parameters[0] && x < parameters[1])
            {
                return (x - parameters[0])/ (parameters[1] - parameters[0]);
            }
            else
            {
                return 1;
            }
        }
    }
}
