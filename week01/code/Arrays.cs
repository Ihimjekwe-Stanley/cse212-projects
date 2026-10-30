public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        
        // PLAN:
        // 1. Create a new double array with the requested length.
        // 2. Use a for loop to visit each position in the array.
        // 3. Multiply the starting number by the current index plus one.
        // 4. Store the calculated multiple in the current array position.
        // 5. Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        
         // PLAN:
        // 1. Determine the total number of elements in the list.
        // 2. Calculate the starting index of the elements that need to move
        //    to the beginning by subtracting the rotation amount from the list count.
        // 3. Use GetRange to make a temporary copy of the elements
        //    that will be moved to the beginning.
        // 4. Remove those elements from their original positions using RemoveRange.
        // 5. Insert the saved elements at index zero using InsertRange.
        // 6. The original list is now rotated to the right by the requested amount.

        int startIndex = data.Count - amount;

        List<int> elementsToMove = data.GetRange(startIndex, amount);

        data.RemoveRange(startIndex, amount);

        data.InsertRange(0, elementsToMove);
    }
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
