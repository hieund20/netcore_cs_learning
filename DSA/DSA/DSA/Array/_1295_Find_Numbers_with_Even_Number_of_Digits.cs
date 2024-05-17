
namespace DSA.Array
{
    public class _1295_Find_Numbers_with_Even_Number_of_Digits
    {
        public _1295_Find_Numbers_with_Even_Number_of_Digits()
        {
            
        }

        public int FindNumbers(int[] nums)
        {
            int bienDem = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (tinhSoChuSo(nums[i]) % 2 == 0)
                {
                    bienDem++;
                }
            }

            return bienDem;
        }

        private static int tinhSoChuSo(int a)
        {
            int kq = a;
            int soChuSo = 0;

            while (kq != 0)
            {
                kq = a / 10;
                a = kq;
                soChuSo++;
            }

            return soChuSo;
        }
    }
}
