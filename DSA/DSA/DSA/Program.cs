using DSA.Array;

public class Program { 
    public static void Main(string[] args)
    {
        #region 1295 Find Numbers with Even Number of Digits
        int[] nums = { 12, 345, 67, 4 };

        _1295_Find_Numbers_with_Even_Number_of_Digits find_Numbers_With_Even_Number_Of_Digits = 
            new _1295_Find_Numbers_with_Even_Number_of_Digits();

        int counter = find_Numbers_With_Even_Number_Of_Digits.FindNumbers(nums);
        Console.WriteLine(counter);
        #endregion

        #region 88 Merge Sorted Array

        #endregion
    }
}