using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace R10546040FuzzySetNamespace
{
    public class TsukamotoFuzzySystem : IFuzzySystem
    {
        int ruleNum;
        int antNum;
        TsukamotoRule[] rules;
        public bool IsWeightedAverage { get; set; } = true;
        public String SystemType { get => typeof(TsukamotoFuzzySystem).Name; }

        public void ConstructRules(DataGridView dgv)
        {
            rules = new TsukamotoRule[dgv.RowCount];

            for (int r = 0; r < dgv.RowCount; r++)
            {
                List<FuzzySet> ant = new List<FuzzySet>();
                for (int i = 0; i < dgv.ColumnCount - 1; i++)
                {
                    ant.Add((FuzzySet)dgv.Rows[r].Cells[i].Value);
                }
                FuzzySet conclusion = (FuzzySet)dgv.Rows[r].Cells[dgv.ColumnCount - 1].Value;
                rules[r] = new TsukamotoRule(ant, conclusion);
            }
        }

        public double CrispInCrispOutInferencing(double[] conditions)
        {
            double result = 0;
            double fireStrength = 0;
            for (int i = 0; i < rules.Length; i++)
            {
                double strength;
                result += rules[i].CrispInCrispOutInferencing(conditions, out strength);
                fireStrength += strength;
            }
            if (IsWeightedAverage)
            {
                return fireStrength / result;
            }
            else
            {
                return fireStrength;
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
            conRule[0] = rules[x].GetRuleConclusion();
            return conRule;
        }

        public int[] Rule_conclusion2(int x)
        {
            int[] conRule = new int[1];
            conRule[0] = 0;
            return conRule;
        }

        public void Open(StreamReader sr, List<FuzzySet> allFSs)
        {
            string[] items;
            //items = sr.ReadLine().Split(':');
            //IsWeightedAverage = Convert.ToBoolean(items[1]);

            items = sr.ReadLine().Split(':');
            ruleNum = Convert.ToInt32(items[1]);
            rules = new TsukamotoRule[ruleNum];
            items = sr.ReadLine().Split(':');
            antNum = Convert.ToInt32(items[1]);

            for (int i = 0; i < ruleNum; i++)
            {
                rules[i] = new TsukamotoRule();
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