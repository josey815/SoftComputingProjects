using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGALibrary
{
    public class PermutationGA : GenericGASolver<int>
    {
        public PermutationGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<int> objectiveEvaluationFunction) : 
            base(numberOfVariables, optimizationType, objectiveEvaluationFunction)
        {
        }
    }
}