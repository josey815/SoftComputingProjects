using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class twoSidePiFuzzySet : FuzzySet
    {
        static int count = 1;

        // properties
        [Category("Parameters")]
        [Description("Leftbottom of a two-sided Pi function. Value must be less than lefttop.")]
        public double LeftBottom
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
        [Description("Lefttop of a Pi function. Value must be larger than leftbottom and less than righttop.")]
        public double LeftTop
        {
            get => parameters[1];
            set
            {
                if (value > parameters[0])
                {
                    if (value < parameters[2])
                        parameters[1] = value;
                }
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        [Category("Parameters")]
        [Description("Righttop of a Pi function. Value must be larger than lefttop and less than rightbottom.")]
        public double RightTop
        {
            get => parameters[2];
            set
            {
                if (value > parameters[1])
                {
                    if (value < parameters[3])
                        parameters[2] = value;
                }
                ExecuteShapeChangedEvent();
                //UpdateSeries();
            }
        }

        [Category("Parameters")]
        [Description("Rightbottom of a Pi function. Value must be larger than righttop.")]
        public double RightBottom
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

        public twoSidePiFuzzySet(Universe theUniverse) : base(theUniverse)
        {
            title = $"twoSidePi{count++}";
            double lb = randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            double lt = lb + 0.3 * randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            double rt = lt + 0.3 * randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            double rb = rt + 0.3 * randomizer.NextDouble() * (theUniverse.UpperBound - theUniverse.LowerBound);
            parameters = new double[4] { lb, lt, rt, rb };
        }

        public override double GetMemberShipDegree(double x)
        {

            if (x <= parameters[0]) // x <= a
            {
                return 0;
            }
            else if ((x > parameters[0]) && (x < parameters[1])) // a < x < b
            {
                //S(a,b)
                //l=a, r=b
                //l=parameters[0]
                //r=parameters[1]
                if ((x > parameters[0]) && (x <= ((parameters[1] + parameters[0]) / 2))) //l<x<=(l+r)/2
                {
                    return 2 * Math.Pow(((x - parameters[0]) / (parameters[1] - parameters[0])), 2);
                }
                else if ((x > ((parameters[1] + parameters[0]) / 2)) && (x <= parameters[1])) //(l+r)/2<x<=r
                {
                    return 1 - 2 * Math.Pow(((parameters[1] - x) / (parameters[1] - parameters[0])), 2);
                }
                else if (x > parameters[1]) // r<x
                {
                    return 1;
                }
                else
                {
                    return 1;
                }
            }
            else if ((x >= parameters[1]) && (x <= parameters[2])) // b <= x
            {
                return 1;
            } else if ((x > parameters[2]) && (x < parameters[3])) // c < x < d
            {
                // z = 1 - s(c, d)
                //l=c, r=d
                //l=parameters[2]
                //r=parameters[3]
                if ((x > parameters[2]) && (x <= ((parameters[2] + parameters[3]) / 2))) //l<x<=(l+r)/2
                {
                    return 1 - 2 * Math.Pow(((x - parameters[2]) / (parameters[3] - parameters[2])), 2);
                }
                else if ((x > ((parameters[2] + parameters[3]) / 2)) && (x <= parameters[3])) //(l+r)/2<x<=r
                {
                    return 2 * Math.Pow(((parameters[3] - x) / (parameters[3] - parameters[2])), 2);
                }
                else if ((x > parameters[3])) // r<x
                {
                    return 0;
                }
                else
                {
                    return 0;
                }
            }
            else // d <= x
            {
                return 0;
            }
        }
    }
}
