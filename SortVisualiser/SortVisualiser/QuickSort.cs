using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace SortVisualiser
{
    class QuickSort : Sorter
    {
        public QuickSort(List<int> A, PictureBox Sender, int speed) : base(A, Sender, speed )
        {

        }
        public override void Sort(IList<int> Ar) { return; }

        public override void Sort(IList<int> a, int l, int h)
        {
            int i = l;
            int j = h;
            double pivotValue = ((l + h) / 2);
            int x = (int)a[int.Parse(pivotValue.ToString())];
            Thread.Sleep(speed);

            while (i <= j)
            {
                while (a[i] < x)
                {
                    i++;
                }
                while (x < a[j])
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = a[i];
                    a[i] = a[j];
                    reDraw(i);
                    i++;
                    a[j] = temp;
                    reDraw(j);
                    j--;
                }
                Thread.Sleep(speed);
            }
            if (l < j)
            {
                Sort(a, l, j);
            }
            if (i < h)
            {
                Sort(a, i, h);
            }
        }
    }
}
