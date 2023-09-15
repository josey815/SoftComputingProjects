using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace R10546040FuzzySetNamespace
{
    public class MamdaniRule
    {
        // Data Fields : data members
        private List<FuzzySet> antecedents;
        private FuzzySet conclusion;

        public MamdaniRule(List<FuzzySet> antecedents, FuzzySet conclusion)
        {
            this.antecedents = antecedents;
            this.conclusion = conclusion;
        }

        // member functions (methods)
        public FuzzySet FuzzyInFuzzyOutInferencing( List<FuzzySet> conditions, bool isCut = true)
        {
            FuzzySet result;
            if (antecedents.Count != conditions.Count)
            {
                throw new Exception("Numbers of condition FSs are not consistent with antecedents.");
            }
            double fireStrength = double.MaxValue;
            for (int i = 0; i < antecedents.Count; i++)
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
    }
}