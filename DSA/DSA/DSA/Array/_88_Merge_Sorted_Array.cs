using System.Numerics;

namespace DSA.Array
{
    public class _88_Merge_Sorted_Array
    {
        #region Ctors
        public _88_Merge_Sorted_Array()
        {
            
        }
        #endregion

        #region Methods
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                chenPhanTuVaoMang(nums2[i], nums1, m);
                m++;
            }
        }

        private void chenPhanTuVaoMang(int x, int[] a, int m)
        {
            bool timDuocK = false;
            for (int k = 0; k < m; k++)
            {
                if (a[k] > x)
                {
                    timDuocK = true;

                    for (int i = m-1; i >= k; i--)
                    {
                        a[i + 1] = a[i];
                    }

                    a[k] = x;
                    break;
                }    
            }    

            if (timDuocK == false)
            {
                a[m] = x;
            }
        }
        #endregion
    }
}
