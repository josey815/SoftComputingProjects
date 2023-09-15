using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace R10546040FuzzySetNamespace
{
    public interface IFuzzySystem
    {
        String SystemType { get;}
        void ConstructRules(DataGridView dgv);
        double CrispInCrispOutInferencing(double[] conditions);
        void Open(StreamReader sr, List<FuzzySet> allFSs);
        void Save(StreamWriter sw);
        int RulesCount();
        FuzzySet[] Rule_antecedents(int x);
        FuzzySet[] Rule_conclusion(int x);
        int[] Rule_conclusion2(int x);
    }
}