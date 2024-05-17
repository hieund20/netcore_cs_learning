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
        int[] nums1 = { 2, 3, 4, 5, 0, 0, 0 };
        int[] nums2 = { 3, 0, 6 };

        _88_Merge_Sorted_Array merge_Sorted_Array = new _88_Merge_Sorted_Array();
        merge_Sorted_Array.Merge(nums1, 4, nums2, 3);
        #endregion
    }
}