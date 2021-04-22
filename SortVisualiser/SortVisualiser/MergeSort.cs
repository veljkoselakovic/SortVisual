using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace SortVisualiser
{
    class MergeSort : Sorter
    {
        public MergeSort(List<int> A, PictureBox Sender, int speed) : base(A, Sender, speed)
        {

        }

        public override void Sort(IList<int> Ar) { return; }

        public override void Sort(IList<int> a, int low, int height)
        {
            int l = low;
            int h = height;

            if (l >= h)
            {
                return ;
            }

            int mid = (l + h) / 2;
            Thread.Sleep(speed);
            Sort(a, l, mid);
            Sort(a, mid + 1, h);

            int end_lo = mid;
            int start_hi = mid + 1;
            while ((l <= end_lo) && (start_hi <= h))
            {
                if (a[l]<a[start_hi])
                {
                    l++;
                }
                else
                {
                    int temp = a[start_hi];
                    for (int k = start_hi - 1; k >= l; k--)
                    {
                        a[k + 1] = a[k];
                        reDraw(k + 1);

                        Thread.Sleep(speed);
                    }
                    a[l] = temp;
                    reDraw(l);
                    l++;
                    end_lo++;
                    start_hi++;
                }
            }

        }

    }
}
