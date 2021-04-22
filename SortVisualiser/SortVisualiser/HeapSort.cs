using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace SortVisualiser
{
    class HeapSort : Sorter
    {
        public HeapSort(List<int> A, PictureBox Sender, int speed) : base(A, Sender, speed)
        {

        }
        public void Uskladi(IList<int> Ar, int i, int m)
        {
            int Temp = Ar[i];
            int j = i * 2 + 1;
            while (j <= m)
            {
                if (j < m)
                    if (Ar[j]<Ar[j+1])
                        j = j + 1;

                if (Temp<Ar[j])
                {
                    Ar[i] = Ar[j];
                    reDraw(i);
                    i = j;
                    j = 2 * i + 1;
                }
                else
                {
                    j = m + 1;
                }
                Thread.Sleep(speed);
            }
            Ar[i] = Temp;
            reDraw(i);
            Thread.Sleep(speed);
        }
        public override void Sort(IList<int> Ar, int l, int h) { return; }

        public override void Sort(IList<int> Ar)
        {
            for (int i = (Ar.Count - 1) / 2; i >= 0; i--)
            {
                Uskladi(Ar, i, Ar.Count - 1);
                Thread.Sleep(speed);
            }

            for (int i = Ar.Count - 1; i >= 1; i--)
            {
                swap(Ar, 0, i);
                reDraw(0);
                reDraw(i);
                Uskladi(Ar, 0, i - 1);
                Thread.Sleep(speed);
            }

        }
    }
}
