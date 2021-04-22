using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace SortVisualiser
{
    class SelectionSort : Sorter
    {
        public SelectionSort(List<int> A, PictureBox Sender, int speed) : base(A, Sender, speed)
        {

        }

        public override void Sort(IList<int> Ar, int l, int h) { return; }

        public override void Sort(IList<int> Ar)
        {
            int min;
            for (int i = 0; i < Ar.Count; i++)
            {

                min = i;
                for (int j = i + 1; j < Ar.Count; j++)
                {
                    if (Ar[j] < Ar[min])
                    {
                        min = j;
                    }
                    Thread.Sleep(speed);
                }
                int x = (int)(((double)Sender.Width / A.Count) * min);

                g.DrawLine(new Pen(Color.White, 3), new Point(x, 0), new Point(x, Sender.Height));
                g.DrawLine(new Pen(Color.Red, 3), new Point(x, Sender.Height), new Point(x, (int)(Sender.Height - (int)A[min])));
                Thread.Sleep(speed*10);

                swap(Ar, i, min);

                reDraw(i);
                reDraw(min);
                

                Thread.Sleep(speed);
            }

            
        }

    }
}
