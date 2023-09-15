using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGALibrary
{
    public enum OptimizationType
    {
        Maximization,
        Minimization
    }

    public enum SelectionMode
    {
        Stochastic,
        Deterministic
    }

    public enum MutationMode
    {
        GeneNumberBased,
        PopulationSizeBased
    }

    public enum CutMode
    {
        OnePointCut,
        TwoPointCut,
        NPointCut
    }

    public enum PermutationCrossoverOperator
    {
        PartialMappedCrossover,
        OrderCrossover,
        PositionBasedCrossover,
        OrderBasedCrossover,
        CycleCrossover,
        SubtourExchangeCrossover
    }

    public enum PermutationMutationOperator
    {
        InversionMutation,
        InsertionMutation,
        DisplacementMutation,
        ReciprocalExchangeMutation,
        SwappedMutation
    }

}