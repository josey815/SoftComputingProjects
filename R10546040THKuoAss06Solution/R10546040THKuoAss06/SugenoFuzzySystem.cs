using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace R10546040FuzzySetNamespace
{
    public class SugenoFuzzySystem : IFuzzySystem
    {
        int ruleNum;
        int antNum;
        SugenoRule[] rules;
        public bool IsWeightedAverage { get; set; } = true;
        public String SystemType { get => typeof(SugenoFuzzySystem).Name; }

        public void ConstructRules(DataGridView dgv)
        {
            rules = new SugenoRule[dgv.RowCount];
            for (int r = 0; r < dgv.RowCount; r++)
            {
                List<FuzzySet> ant = new List<FuzzySet>();
                for (int i = 0; i < dgv.ColumnCount - 1; i++)
                {
                    ant.Add((FuzzySet)dgv.Rows[r].Cells[i].Value);
                }
                int conclusion = (int)dgv.Rows[r].Cells[dgv.ColumnCount - 1].Value;
                rules[r] = new SugenoRule(ant, conclusion);
            }
        }

        public double CrispInCrispOutInferencing(double[] conditions)
        {
            //double result = 0;
            //double weightSum = 0;
            //double[] ruleOutput = new double[rules.Length];
            //double[] strengthList = new double[rules.Length];
            //for (int i = 0; i < rules.Length; i++)
            //{
            //    double strength = 0;
            //    ruleOutput[i] = rules[i].CrispInCrispOutInferencing(conditions, out strength);
            //    strengthList[i] = strength;
            //}
            //if (IsWeightedAverage)
            //{
            //    for(int i = 0; i < ruleOutput.Length; i++)
            //    {
            //        result += ruleOutput[i];
            //        weightSum += strengthList[i];
            //    }
            //    return result / weightSum;
            //}
            //else
            //{
            //    for (int i = 0; i < ruleOutput.Length; i++)
            //    {
            //        result += ruleOutput[i];
            //    }
            //    return result;
            //}

            double numerator = 0;
            double denominator = 0;

            for (int i = 0; i < rules.Length; i++)
            {
                numerator = numerator + rules[i].CrispInCrispOutInferencing(conditions);
                denominator = denominator + rules[i].CrispInCrispOutInferencingWeight(conditions);
            }

            if (IsWeightedAverage && (denominator != 0))
            {
                return numerator / denominator;
            }
            else
            {
                return numerator;
            }
        }

        public int RulesCount()
        {
            return rules.Length;
        }

        public FuzzySet[] Rule_antecedents(int x)
        {
            FuzzySet[] antRule = new FuzzySet[antNum - 1];
            for (int i = 0; i < antNum - 1; i++)
            {

                antRule[i] = (rules[x].GetRuleAntecedents())[i];
            }
            return antRule;
        }

        public FuzzySet[] Rule_conclusion(int x)
        {
            FuzzySet[] conRule = new FuzzySet[1];
            conRule[0] = (rules[x].GetRuleAntecedents())[antNum - 1];
            return conRule;
        }

        public int[] Rule_conclusion2(int x)
        {
            int[] conRule = new int[1];
            conRule[0] = rules[x].GetRuleConclusion();
            return conRule;
        }

        public void Open(StreamReader sr, List<FuzzySet> allFSs)
        {
            string[] items;
            //items = sr.ReadLine().Split(':');
            //IsWeightedAverage = Convert.ToBoolean(items[1]);

            items = sr.ReadLine().Split(':');
            ruleNum = Convert.ToInt32(items[1]);
            rules = new SugenoRule[ruleNum];
            items = sr.ReadLine().Split(':');
            antNum = Convert.ToInt32(items[1]);

            for (int i = 0; i < ruleNum; i++)
            {
                rules[i] = new SugenoRule();
                rules[i].Open(sr, allFSs);
            }
        }

        public void Save(StreamWriter sw)
        {
            //sw.WriteLine($"IsWeightedAverage:{IsWeightedAverage}");
            //sw.WriteLine($"RuleNumber:{rules.Length}");
            for (int i = 0; i < rules.Length; i++)
            {
                rules[i].Save(sw);
            }
        }
    }
}