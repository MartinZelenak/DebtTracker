﻿using KellermanSoftware.CompareNetObjects;

namespace DebtTracker.Common.Tests;

public static class DeepAssert
{
    public static void Equal<T>(T? expected, T? actual, params string[] propertiesToIgnore)
    {
        CompareLogic compareLogic = new()
        {
            Config =
            {
                MembersToIgnore = propertiesToIgnore.ToList(),
                IgnoreCollectionOrder = true,
                IgnoreObjectTypes = true,
                CompareStaticProperties = false,
                CompareStaticFields = false,
                DateTimeKindToUseWhenUnspecified = DateTimeKind.Local
            }
        };

        ComparisonResult comparisonResult = compareLogic.Compare(expected!, actual!);
        if (!comparisonResult.AreEqual)
        {
            throw new ObjectEqualException(expected!, actual!, comparisonResult.DifferencesString);
        }
    }
}
