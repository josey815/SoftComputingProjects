using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class BinaryFSOperator
    {
        public double[] parameters;
        protected string title;

        public string Title
        {
            get { return title; }
        }

        public double Parameters
        {
            get
            {
                if (parameters != null)
                {
                    return parameters[0];
                }
                else
                {
                    return 10000;
                }
            }
        }

        public virtual double GetValue(double degree_1, double degree_2)
        {
            throw new NotImplementedException();
        }
    }

    public class Intersection : BinaryFSOperator
    {
        public Intersection()
        {
            title = "Intersection";
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return Math.Min(degree_1, degree_2);
        }

        public override string ToString()
        {
            return "Intersection Operator";
        }
    }

    public class Union : BinaryFSOperator
    {
        public Union()
        {
            title = "Union";
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return Math.Max(degree_1, degree_2);
        }

        public override string ToString()
        {
            return "Union Operator";
        }
    }

    public class AlgebraicSum : BinaryFSOperator
    {
        public AlgebraicSum()
        {
            title = "AlgebraicSum";
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return degree_1 + degree_2 - degree_1 * degree_2;
        }

        public override string ToString()
        {
            return "AlgebraicSum Operator";
        }
    }

    public class BoundedSum : BinaryFSOperator
    {
        public BoundedSum()
        {
            title = "BoundedSum";
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return Math.Min(1, degree_1 + degree_2);
        }

        public override string ToString()
        {
            return "BoundedSum Operator";
        }
    }

    public class DrasticSum : BinaryFSOperator
    {
        public DrasticSum()
        {
            title = "DrasticSum";
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            if (degree_1 == 0)
            {
                return degree_2;
            } else if (degree_2 == 0)
            {
                return degree_1;
            }
            else if (degree_1 > 0 & degree_2 > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return "DrasticSum Operator";
        }
    }

    public class AlgebraicProduct : BinaryFSOperator
    {
        public AlgebraicProduct()
        {
            title = "AlgebraicProduct";
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return degree_1 * degree_2;
        }

        public override string ToString()
        {
            return "AlgebraicProduct Operator";
        }
    }

    public class BoundedProduct : BinaryFSOperator
    {
        public BoundedProduct()
        {
            title = "BoundedProduct";
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return Math.Max(0, degree_1 + degree_2 - 1);
        }

        public override string ToString()
        {
            return "BoundedProduct Operator";
        }
    }

    public class DrasticProduct : BinaryFSOperator
    {
        public DrasticProduct()
        {
            title = "DrasticProduct";
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            if (degree_1 == 1)
            {
                return degree_2;
            } else if (degree_2 == 1)
            {
                return degree_1;
            }
            else if (degree_1 < 1 & degree_2 < 1)
            {
                return 0;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return "DrasticProduct Operator";
        }
    }

    public class SchweizerSklarTnorm : BinaryFSOperator
    {
        public SchweizerSklarTnorm(double p)
        {
            title = "SchweizerSklarTnorm";
            if (p > 0)
            {
                parameters = new double[1] { p };
            }
            else
            {

                parameters = new double[1] { 1 };
            }
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return Math.Pow(Math.Max(0, Math.Pow(degree_1, -parameters[0]) + Math.Pow(degree_2, -parameters[0]) - 1), -(1 / parameters[0]));
        }

        public override string ToString()
        {
            return "SchweizerSklarTnorm Operator";
        }
    }

    public class YagerTnorm : BinaryFSOperator
    {
        public YagerTnorm(double q)
        {
            title = "YagerTnorm";
            if (q > 0)
            {
                parameters = new double[1] { q };
            }
            else
            {

                parameters = new double[1] { 1 };
            }
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return 1 - Math.Min(1, Math.Pow(Math.Pow(1 - degree_1, parameters[0]) + Math.Pow(1 - degree_2, parameters[0]), 1 / parameters[0]));
        }

        public override string ToString()
        {
            return "YagerTnorm Operator";
        }
    }

    public class DuboisPradeTnorm : BinaryFSOperator
    {
        public DuboisPradeTnorm(double alpha)
        {
            title = "DuboisPradeTnorm";
            if (alpha >= 0 & alpha <= 1)
            {
                parameters = new double[1] { alpha };
            }
            else
            {

                parameters = new double[1] { 0.5 };
            }
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            double a = Math.Max(degree_1, degree_2);
            double b = Math.Max(a, parameters[0]);
            return degree_1 * degree_2 / b;
        }

        public override string ToString()
        {
            return "DuboisPradeTnorm Operator";
        }
    }

    public class HamacherTnorm : BinaryFSOperator
    {
        public HamacherTnorm(double gamma)
        {
            title = "HamacherTnorm";
            if (gamma > 0)
            {
                parameters = new double[1] { gamma };
            }
            else
            {

                parameters = new double[1] { 1 };
            }
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return degree_1 * degree_2 / (parameters[0] + (1 - parameters[0]) * (degree_1 + degree_2 - degree_1 * degree_2));
        }

        public override string ToString()
        {
            return "HamacherTnorm Operator";
        }
    }

    public class FrankTnorm : BinaryFSOperator
    {
        public FrankTnorm(double s)
        {
            title = "FrankTnorm";
            if (s > 0)
            {
                parameters = new double[1] { s };
            }
            else
            {

                parameters = new double[1] { 1 };
            }
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return Math.Log(1 + (Math.Pow(parameters[0], degree_1) - 1) * (Math.Pow(parameters[0], degree_2) - 1) / (parameters[0] -1) ,parameters[0]);
        }

        public override string ToString()
        {
            return "FrankTnorm Operator";
        }
    }

    public class SugenoTnorm : BinaryFSOperator
    {
        public SugenoTnorm(double lambda)
        {
            title = "SugenoTnorm";
            if (lambda >= -1)
            {
                parameters = new double[1] { lambda };
            }
            else
            {

                parameters = new double[1] { -1 };
            }
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return Math.Max(0, (parameters[0] + 1) * (degree_1 + degree_2 - 1) - parameters[0] * degree_1 * degree_2);
        }

        public override string ToString()
        {
            return "SugenoTnorm Operator";
        }
    }

    public class DombiTnorm : BinaryFSOperator
    {
        public DombiTnorm(double lambda)
        {
            title = "DombiTnorm";
            if (lambda > 0)
            {
                parameters = new double[1] { lambda };
            }
            else
            {

                parameters = new double[1] { 1 };
            }
        }
        public override double GetValue(double degree_1, double degree_2)
        {
            return 1 / (1 + Math.Pow(Math.Pow(Math.Pow(degree_1, -1)-1, parameters[0]) + Math.Pow(Math.Pow(degree_2, -1)-1, parameters[0]), 1 / parameters[0]));
        }

        public override string ToString()
        {
            return "DombiTnorm Operator";
        }
    }
}
