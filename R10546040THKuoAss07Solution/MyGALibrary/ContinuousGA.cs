using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGALibrary
{
    public class ContinuousGA : GenericGASolver<double>
    {
        public ContinuousGA(int numberOfVariables, OptimizationType optimizationType, ObjectiveFunction<double> objectiveEvaluationFunction) : 
            base(numberOfVariables, optimizationType, objectiveEvaluationFunction)
        {
        }
    }
}