using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace R10546040FuzzySetNamespace
{
    public class MamdaniFuzzySystem : IFuzzySystem
    {
        int ruleNum;
        int ColNum;

        MamdaniRule[] rules;
        public bool CutInferencing { set; get; } = true;
        public DefuzzificationType Defuzzification { set; get; }
        public String SystemType { get => typeof(MamdaniFuzzySystem).Name; }

        public void ConstructRules (DataGridView dgv)
        {
            rules = new MamdaniRule[dgv.RowCount];
            for (int r = 0; r < dgv.RowCount; r++)
            {
                List<FuzzySet> ant = new List<FuzzySet>();
                for (int i = 0; i < dgv.ColumnCount - 1; i++)
                {
                    ant.Add((FuzzySet)dgv.Rows[r].Cells[i].Value);
                }
                FuzzySet conclusion = (FuzzySet)dgv.Rows[r].Cells[dgv.ColumnCount - 1].Value;
                rules[r] = new MamdaniRule(ant, conclusion);
            }
        }

        public FuzzySet FuzzyInFuzzyOutInferencing(FuzzySet[] conditions)
        {
            FuzzySet inferenceResult;
            inferenceResult = rules[0].FuzzyInFuzzyOutInferencing(conditions, CutInferencing);
            for (int i = 1; i < rules.Length; i++)
            {
                inferenceResult |= rules[i].FuzzyInFuzzyOutInferencing(conditions, CutInferencing);
            }
            return inferenceResult;
        }

        public double CrispInCrispOutInferencing(double[] conditions)
        {
            FuzzySet inferenceResult;
            inferenceResult = rules[0].CrispInFuzzyOutInferencing(conditions, CutInferencing);
            for (int i = 1; i < rules.Length; i++)
            {
                inferenceResult |= rules[i].CrispInFuzzyOutInferencing(conditions, CutInferencing);
            }
            switch (Defuzzification)
            {
                case DefuzzificationType.COA:
                    return inferenceResult.COACrispValue;
                case DefuzzificationType.BOA:
                    return inferenceResult.BOACrispValue;
                case DefuzzificationType.MOM:
                    return inferenceResult.MOMCrispValue;
                case DefuzzificationType.SOM:
                    return inferenceResult.SOMCrispValue;
                case DefuzzificationType.LOM:
                    return inferenceResult.LOMCrispValue;
                default:
                    return inferenceResult.COACrispValue;
            }
        }

        public int RulesCount()
        {
            return rules.Length;
        }

        public FuzzySet[] Rule_antecedents(int x)
        {
            FuzzySet[] antRule = new FuzzySet[ColNum-1];
            for (int i = 0; i < ColNum-1; i++)
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
            //CutInferencing = Convert.ToBoolean(items[1]);
            ////items = sr.ReadLine().Split(':');
            //Defuzzification = (DefuzzificationType)items[1];
            //Type defuzziType = Type.GetType($"R10546040FuzzySetNamespace.{items[1]}");
            //Defuzzification = (DefuzzificationType)Activator.CreateInstance(defuzziType);
            items = sr.ReadLine().Split(':');
            ruleNum = Convert.ToInt32(items[1]);
            rules = new MamdaniRule[ruleNum];
            items = sr.ReadLine().Split(':');
            ColNum = Convert.ToInt32(items[1]);

            for (int i = 0; i < ruleNum; i++)
            {
                rules[i] = new MamdaniRule();
                rules[i].Open(sr, allFSs);
            }
        }

        public void Save(StreamWriter sw)
        {
            //sw.WriteLine($"CutInferencing:{CutInferencing}");
            ////sw.WriteLine($"Defuzzification:{Defuzzification}");

            for (int i = 0; i < rules.Length; i++)
            {
                rules[i].Save(sw);
            }
        }
    }
}