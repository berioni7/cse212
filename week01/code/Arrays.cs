using System;
using System.Collections.Generic;

public static class ArraysExercises
{
    // ------------------------------
    // Part 1: MultiplesOf
    // ------------------------------
    // Plan (comments before implementation):
    // 1) Check if 'count' is less than or equal to 0 -> return an empty array.
    // 2) Create a double array with size equal to 'count'.
    // 3) For i from 0 to count-1:
    //      - calculate the multiple: value = start * (i + 1)
    //      - store in result[i] = value
    // 4) Return the result array.
    public static double[] MultiplesOf(double start, int count)
    {
        // Implementation following the plan above:
        if (count <= 0)
        {
            return new double[0]; // empty array
        }

        double[] result = new double[count];
        for (int i = 0; i < count; i++)
        {
            result[i] = start * (i + 1);
        }

        return result;
    }

    // ------------------------------
    // Part 2: RotateListRight
    // ------------------------------
    // Plan (comments before implementation):
    // 1) If the list is null or has 0 or 1 elements, do nothing (already "rotated").
    // 2) Normalize amount: amount = amount % data.Count (rotating a full size doesn’t change anything).
    // 3) Take the last 'amount' items (the "tail") and the rest from the beginning (the "head").
    // 4) Clear the original list and add first the tail and then the head (tail + head).
    // 5) Done — the original list is now rotated to the right.
    public static void RotateListRight<T>(List<T> data, int amount)
    {
        if (data == null || data.Count <= 1)
            return; // nothing to do

        int n = data.Count;
        // normalize the amount to avoid unnecessary full rotations
        amount = amount % n;
        if (amount == 0)
            return; // nothing changes

        // take the last 'amount' elements
        List<T> tail = data.GetRange(n - amount, amount);    // last 'amount'
        List<T> head = data.GetRange(0, n - amount);        // from the beginning until before the tail

        data.Clear();           // clear the original list
        data.AddRange(tail);    // add the tail first
        data.AddRange(head);    // then add the rest
    }

    // Helper method just to test visually (optional)
    public static void Demo()
    {
        // Test MultiplesOf
        var mult = MultiplesOf(3, 5); // expects {3,6,9,12,15}
        Console.WriteLine("MultiplesOf(3,5) -> " + string.Join(", ", mult));

        // Test RotateListRight
        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine("Original list -> " + string.Join(", ", list));

        RotateListRight(list, 3); // expects {7,8,9,1,2,3,4,5,6}
        Console.WriteLine("After RotateListRight(..., 3) -> " + string.Join(", ", list));

        // Another test
        var list2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(list2, 5); // expects {5,6,7,8,9,1,2,3,4}
        Console.WriteLine("After RotateListRight(..., 5) -> " + string.Join(", ", list2));
    }
}
