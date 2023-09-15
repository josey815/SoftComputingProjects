using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace R10546040FuzzySetNamespace
{
    public class TsukamotoRule
    {
        // Data Fields : data members
        private FuzzySet[] antecedents;
        private FuzzySet conclusion;

        public TsukamotoRule()
        {

        }

        public TsukamotoRule(List<FuzzySet> antecedents, FuzzySet conclusion)
        {
            this.antecedents = new FuzzySet[antecedents.Count];
            for (int i = 0; i < this.antecedents.Length; i++)
            {
                this.antecedents[i] = antecedents[i];
            }
            this.conclusion = conclusion;
        }

        public double CrispInCrispOutInferencing(double[] conditions, out double strength)
        {
            strength = double.MaxValue;
            double weight = 1.0;
            if (antecedents.Length != conditions.Length)
            {
                throw new Exception("Numbers of condition FSs are not consistent with antecedents.");
            }
            for (int i = 0; i < antecedents.Length; i++)
            {
                weight *= antecedents[i].GetMemberShipDegree(conditions[i]);
            }

            // determine strength
            // evaluate and return output value
            strength = weight * conclusion.GetUniverseValueForADegree(weight);

            return weight;
        }

        public FuzzySet[] GetRuleAntecedents()
        {
            return antecedents;
        }

        public FuzzySet GetRuleConclusion()
        {
            return conclusion;
        }

        internal void Open(StreamReader sr, List<FuzzySet> allFSs)
        {
            string[] items = sr.ReadLine().Split(':');
            int num = Convert.ToInt32(items[1]);
            antecedents = new FuzzySet[num];
            for (int i = 0; i < num; i++)
            {
                items = sr.ReadLine().Split(':');
                int fsCode = Convert.ToInt32(items[1]);
                foreach (FuzzySet fs in allFSs)
                {
                    if (fs.SavedHashCode == fsCode)
                    {
                        antecedents[i] = fs;
                        break;
                    }
                }
            }
            items = sr.ReadLine().Split(':');
            int conclusionCode = Convert.ToInt32(items[1]);
            foreach (FuzzySet fs in allFSs)
            {
                if (fs.SavedHashCode == conclusionCode)
                {
                    conclusion = fs;
                    break;
                }
            }
        }

        internal void Save(StreamWriter sw)
        {
            sw.WriteLine($"NumberOfAntecedents:{antecedents.Length}");
            for (int i = 0; i < antecedents.Length; i++)
            {
                sw.WriteLine($"FuzzySetHash:{antecedents[i].GetHashCode()}");
            }
            sw.WriteLine($"FuzzySetHash:{conclusion.GetHashCode()}");
        }
    }

    public class SugenoRule
    {
        // Data Fields : data members
        private FuzzySet[] antecedents;
        private int conclusionEQid;

        public SugenoRule()
        {

        }

        public SugenoRule(List<FuzzySet> antecedents, int conclusionEQid)
        {
            this.antecedents = new FuzzySet[antecedents.Count];
            for (int i = 0; i < this.antecedents.Length; i++)
            {
                this.antecedents[i] = antecedents[i];
            }
            this.conclusionEQid = conclusionEQid;
        }
        
        public double CrispInCrispOutInferencing(double[] conditions)
        {
            //double fireStrength = double.MaxValue;
            //double[] weight = new double[conditions.Length];
            //if (antecedents.Length != conditions.Length)
            //{
            //    throw new Exception("Numbers of condition FSs are not consistent with antecedents.");
            //}
            //for (int i = 0; i < antecedents.Length; i++)
            //{
            //    weight[i] = antecedents[i].GetMemberShipDegree(conditions[i]);
            //    if (fireStrength > weight[i])
            //    {
            //        fireStrength = weight[i];
            //    }
            //}
            //if (weighted)
            //{
            //    return (int) (fireStrength * GetOutputValue(conditions, conclusionEQid));
            //}
            //else
            //{
            //    return (int) GetOutputValue(conditions, conclusionEQid);
            //}

            double weightX = antecedents[0].GetMemberShipDegree(conditions[0]);
            double weightY = antecedents[1].GetMemberShipDegree(conditions[1]);
            return weightX * weightY * GetOutputValue(conditions, conclusionEQid);

        }

        public double CrispInCrispOutInferencingWeight(double[] conditions)
        {
            //strength = double.MaxValue;
            //double[] weight = new double[conditions.Length];
            //if (antecedents.Length != conditions.Length)
            //{
            //    throw new Exception("Numbers of condition FSs are not consistent with antecedents.");
            //}
            //for (int i = 0; i < antecedents.Length; i++)
            //{
            //    weight[i] = antecedents[i].GetMemberShipDegree(conditions[i]);
            //    // determine firing strength
            //    if (strength > weight[i])
            //    {
            //        strength = weight[i];
            //    }
            //}

            //// evaluate output value
            //// return weighted (strengthed) output value and strength
            //return (int)(strength * GetOutputValue(conditions, conclusionEQid));


            double weightX = antecedents[0].GetMemberShipDegree(conditions[0]);
            double weightY = antecedents[1].GetMemberShipDegree(conditions[1]);
            return weightX * weightY;
        }


        public static double GetOutputValue(double[] inputs, int equationID)
        {
            switch (equationID)
            {
                case 0: // Y=0.1X+6.4
                    return 0.1 * inputs[0] + 6.4;
                case 1: // Y=-0.5X+4
                    return -0.5 * inputs[0] + 4;
                case 2: // Y=X-2
                    return inputs[0] - 2;
                case 3: // Z=-X+Y+1
                    return -inputs[0] + inputs[1] + 1;
                case 4: // Z=-Y+3
                    return -inputs[1] + 3;
                case 5: // Z=-X+3
                    return -inputs[0] + 3;
                case 6: // Z=X+Y+2
                    return inputs[0] + inputs[1] + 2;
            }
            return 0;
        }

        internal void Save(StreamWriter sw)
        {
            sw.WriteLine($"NumberOfAntecedents:{antecedents.Length}");
            for (int i = 0; i < antecedents.Length; i++)
            {
                sw.WriteLine($"FuzzySetHash:{antecedents[i].GetHashCode()}");
            }
            sw.WriteLine($"EquationID:{conclusionEQid}");
        }

        internal void Open(StreamReader sr, List<FuzzySet> allFSs)
        {
            string[] items = sr.ReadLine().Split(':');
            int num = Convert.ToInt32(items[1]);
            antecedents = new FuzzySet[num];
            for (int i = 0; i < num; i++)
            {
                items = sr.ReadLine().Split(':');
                int fsCode = Convert.ToInt32(items[1]);
                foreach (FuzzySet fs in allFSs)
                {
                    if (fs.SavedHashCode == fsCode)
                    {
                        antecedents[i] = fs;
                        break;
                    }
                }
            }
            items = sr.ReadLine().Split(':');
            conclusionEQid = Convert.ToInt32(items[1]);
        }

        public FuzzySet[] GetRuleAntecedents()
        {
            return antecedents;
        }

        public int GetRuleConclusion()
        {
            return conclusionEQid;
        }
    }
    public class MamdaniRule
    {
        // Data Fields : data members
        private FuzzySet[] antecedents;
        private FuzzySet conclusion;

        public MamdaniRule()
        {

        }

        public MamdaniRule(List<FuzzySet> antecedents, FuzzySet conclusion)
        {
            this.antecedents = new FuzzySet[antecedents.Count];
            for (int i = 0; i < this.antecedents.Length; i++)
            {
                this.antecedents[i] = antecedents[i];
            }
            this.conclusion = conclusion;
        }

        // member functions (methods)
        public FuzzySet FuzzyInFuzzyOutInferencing( FuzzySet[] conditions, bool isCut = true)
        {
            FuzzySet result;
            if (antecedents.Length != conditions.Length)
            {
                throw new Exception("Numbers of condition FSs are not consistent with antecedents.");
            }
            double fireStrength = double.MaxValue;
            for (int i = 0; i < antecedents.Length; i++)
            {
                FuzzySet fs = antecedents[i] & conditions[i];
                fs.VisualDisplayInfer = true;
                double strength = (fs).MaxDegree;
                if (fireStrength > strength)
                {
                    fireStrength = strength;
                }
            }
            if (isCut)
            {
                result = fireStrength - conclusion;
                result.VisualDisplayInfer = true;
                return result;
            }
            else
            {
                result = fireStrength * conclusion;
                result.VisualDisplayInfer = true;
                return result;
            }
        }

        public FuzzySet CrispInFuzzyOutInferencing(double[] conditions, bool cutInferencing)
        {
            FuzzySet result;
            if (antecedents.Length != conditions.Length)
            {
                throw new Exception("Numbers of conditions are not consistent with antecedents.");
            }
            double fireStrength = 1.0;
            for (int i = 0; i < antecedents.Length; i++)
            {
                double antValue = antecedents[i].GetMemberShipDegree(conditions[i]);
                if (fireStrength > antValue)
                {
                    fireStrength = antValue;
                }
            }
            if (cutInferencing)
            {
                result = fireStrength - conclusion;
                result.VisualDisplayInfer = true;
                return result;
            }
            else
            {
                result = fireStrength * conclusion;
                result.VisualDisplayInfer = true;
                return result;
            }
        }

        public FuzzySet[] GetRuleAntecedents()
        {
            return antecedents;
        }

        public FuzzySet GetRuleConclusion()
        {
            return conclusion;
        }

        internal void Open(StreamReader sr, List<FuzzySet> newFSs)
        {
            string[] items = sr.ReadLine().Split(':');
            int num = Convert.ToInt32(items[1]);
            antecedents = new FuzzySet[num];
            for (int i = 0; i < antecedents.Length; i++)
            {
                items = sr.ReadLine().Split(':');
                int fsCode = Convert.ToInt32(items[1]);
                foreach (FuzzySet fs in newFSs)
                {
                    if (fs.SavedHashCode == fsCode)
                    {
                        antecedents[i] = fs;
                        break;
                    }
                }
            }
            items = sr.ReadLine().Split(':');
            int conclusionCode = Convert.ToInt32(items[1]);
            foreach (FuzzySet fs in newFSs)
            {
                if (fs.SavedHashCode == conclusionCode)
                {
                    conclusion = fs;
                    break;
                }
            }
        }

        internal void Save(StreamWriter sw)
        {
            sw.WriteLine($"NumberOfAntecedents:{antecedents.Length}");
            for (int i = 0; i < antecedents.Length; i++)
            {
                sw.WriteLine($"FuzzySetHash:{antecedents[i].GetHashCode()}");
            }
            sw.WriteLine($"*FuzzySetHash:{conclusion.GetHashCode()}");
        }
    }
}