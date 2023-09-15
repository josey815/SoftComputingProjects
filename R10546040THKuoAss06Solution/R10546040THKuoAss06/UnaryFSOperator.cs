using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R10546040FuzzySetNamespace
{
    public class UnaryFSOperator
    {
        public double[] parameters;
        protected string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
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

        public UnaryFSOperator()
        {
                
        }

        public virtual double GetValue(double degree)
        {
            throw new NotImplementedException();
        }

        public virtual void ExtraOpen(StreamReader sr)
        {
            
        }

        public virtual void ExtraSave(StreamWriter sw)
        {

        }

        public void Open(StreamReader sr)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            title = items[1];
            items = sr.ReadLine().Split(':');
            int num = Convert.ToInt32(items[1]);
            if (num != 0)
            {
                parameters = new double[num];
                for (int i = 0; i < num; i++)
                {
                    items = sr.ReadLine().Split(':');
                    parameters[i] = Convert.ToDouble(items[1]);
                }
            }
            Title = title;
            //ExtraOpen(sr);
        }

        public void Save(StreamWriter sw)
        {
            sw.WriteLine($"Title:{title}");
            int numberOfParameters = 0;
            if (parameters != null)
            {
                numberOfParameters = parameters.Length;
            }
            sw.WriteLine($"NumberOfParameters:{numberOfParameters}");
            for (int i = 0; i < numberOfParameters; i++)
            {
                sw.WriteLine($"Par{i}:{parameters[i]}");
            }
            //ExtraSave(sw);
        }
    }



    public class Negate : UnaryFSOperator
    {
        public Negate()
        {
            title = "Negate";
        }
        public override double GetValue(double degree)
        {
            return 1.0 - degree;
        }

        public override string ToString()
        {
            return "Negate Operator";
        }
    }

    public class ValueCut : UnaryFSOperator
    {
        public ValueCut()
        {

        }

        public ValueCut(double cut)
        {
            title = "ValueCut";
            if (cut < 1 & cut > 0)
            {
                parameters = new double[1] { cut };
            }
            else
            {
                parameters = new double[1] { 0.5 };
            }
        }

        public override double GetValue(double degree)
        { 
            if ( degree <= parameters[0])
            {
                return degree;
            }
            else
            {
                return parameters[0];
            }
        }

        public override string ToString()
        {
            return "ValueCut Operator";
        }

        public override void ExtraOpen(StreamReader sr)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            title = items[1];
            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32(items[1]);
            parameters = new double[num];
            for (int i = 0; i < num; i++)
            {
                items = sr.ReadLine().Split(':');
                parameters[i] = Convert.ToDouble(items[1]);
            }
            Title = title;
        }

        public override void ExtraSave(StreamWriter sw)
        {
            sw.WriteLine($"Operator:{title}");
            int numberOfParameters = 0;
            if (parameters != null)
            {
                numberOfParameters = parameters.Length;
            }
            sw.WriteLine($"NumberOfParameters:{numberOfParameters}");
            for (int i = 0; i < numberOfParameters; i++)
            {
                sw.WriteLine($"Par{i}:{parameters[i]}");
            }
        }
    }

    public class Very : UnaryFSOperator
    {
        public Very()
        {
            title = "Very";
        }
        public override double GetValue(double degree)
        {
            return Math.Pow(degree, 2);
        }

        public override string ToString()
        {
            return "Very Operator";
        }
    }

    public class MoreOrLess : UnaryFSOperator
    {
        public MoreOrLess()
        {
            title = "MoreOrLess";
        }
        public override double GetValue(double degree)
        {
            return Math.Pow(degree, 0.5);
        }

        public override string ToString()
        {
            return "MoreOrLess Operator";
        }
    }

    public class Extremely : UnaryFSOperator
    {
        public Extremely()
        {
            title = "Extremely";
        }
        public override double GetValue(double degree)
        {
            return Math.Pow(degree, 8);
        }

        public override string ToString()
        {
            return "Extremely Operator";
        }
    }

    public class Intensification : UnaryFSOperator
    {
        public Intensification()
        {
            title = "Intensification";
        }
        public override double GetValue(double degree)
        {
            if (degree >= 0.0 & degree <= 0.5)
            {
                return 2 * Math.Pow(degree, 2);
            }
            else if (degree >= 0.5 & degree <= 1.0)
            {
                return (1 -  2 * Math.Pow((1 - degree), 2));
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return "Intensification Operator";
        }
    }

    public class Diminisher : UnaryFSOperator
    {
        public Diminisher()
        {
            title = "Diminisher";
        }
        public override double GetValue(double degree)
        {
            if (degree >= 0.0 & degree <= 0.5)
            {
                return Math.Sqrt(0.5 * degree);
            }
            else if (degree >= 0.5 & degree <= 1.0)
            {
                return 1 - Math.Sqrt(0.5 * (1 - degree));
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return "Diminisher Operator";
        }
    }

    public class Scale : UnaryFSOperator
    {
        public Scale(double value)
        {
            title = "Scale";
            if (value <= 1 & value > 0)
            {
                parameters = new double[1] { value };
            }
            else
            {
                parameters = new double[1] { 0.5 };
            }

        }
        public override double GetValue(double degree)
        {
            return parameters[0] * degree;
        }

        public override string ToString()
        {
            return "Scale Operator";
        }

        public override void ExtraOpen(StreamReader sr)
        {
            string[] items;
            items = sr.ReadLine().Split(':');
            title = items[1];
            int num;
            items = sr.ReadLine().Split(':');
            num = Convert.ToInt32(items[1]);
            parameters = new double[num];
            for (int i = 0; i < num; i++)
            {
                items = sr.ReadLine().Split(':');
                parameters[i] = Convert.ToDouble(items[1]);
            }
            Title = title;
        }

        public override void ExtraSave(StreamWriter sw)
        {
            sw.WriteLine($"Operator:{title}");
            int numberOfParameters = 0;
            if (parameters != null)
            {
                numberOfParameters = parameters.Length;
            }
            sw.WriteLine($"NumberOfParameters:{numberOfParameters}");
            for (int i = 0; i < numberOfParameters; i++)
            {
                sw.WriteLine($"Par{i}:{parameters[i]}");
            }
        }
    }

}
