using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace SortVisualiser
{
    class BubbleSort : Sorter
    {
        public BubbleSort(List<int> A, PictureBox Sender, int speed) : base(A, Sender, speed)
        {

        }

        public override void Sort(IList<int> Ar)
        {
            int n = Ar.Count - 1;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n - i; j++)
                {
                    if (Ar[j] > Ar[j + 1])
                    {
                        Thread.Sleep(speed);

                        swap(Ar, j, j + 1);

                        base.reDraw(j);
                        base.reDraw(j + 1);


                    }
                }
            }

        }

        public override void Sort(IList<int> Ar, int l, int h) {return; }
        public IList<int> BiSort(IList<int> Ar)
        {

            int limit = Ar.Count;
            int st = -1;
            bool swapped = false;
            do
            {
                swapped = false;
                st++;
                limit--;

                for (int j = st; j < limit; j++)
                {
                    if (Ar[j] > Ar[j+1])
                    {
                        swap(Ar, j, j + 1);
                        swapped = true;
                        reDraw(j);
                        reDraw(j + 1);
                        

                    }
                    Thread.Sleep(speed);

                }
                for (int j = limit - 1; j >= st; j--)
                {
                    if (Ar[j]>Ar[j+1])
                    {
                        swap(Ar, j, j + 1);
                        swapped = true;
                        reDraw(j);
                        reDraw(j + 1);

                        

                    }
                    Thread.Sleep(speed);

                }

            } while (st < limit && swapped);

            return Ar;
        }
    }
}