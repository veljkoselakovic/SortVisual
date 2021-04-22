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
    class InsertionSort : Sorter
    {
        public InsertionSort(List<int> A, PictureBox Sender, int speed) : base(A, Sender, speed)
        {

        }

        public override void Sort(IList<int> Ar)
        {
            for (int i = 1; i < Ar.Count; i++)
            {
                int val = Ar[i];
                int j = i - 1;
                bool done = false;
                do
                {
                    if (Ar[j] > val)
                    {
                        Ar[j + 1] = Ar[j];
                        reDraw(j + 1);
                        j--;
                        if (j < 0)
                        {
                            done = true;
                        }
                    }
                    else
                    {
                        done = true;
                    }
                    Thread.Sleep(speed);
                } while (!done);
                int x = (int)((double)Sender.Width / A.Count * (j + 1));
                g.DrawLine(new Pen(Color.White, 3), new Point(x, 0), new Point(x, Sender.Height));
                g.DrawLine(new Pen(Color.Red, 3), new Point(x, Sender.Height), new Point(x, (int)(Sender.Height - (int)A[j + 1])));
                Thread.Sleep(speed * 5);
                Ar[j + 1] = val;

                reDraw(j + 1);
                Thread.Sleep(speed);
            }
        }

        public override void Sort(IList<int> Ar, int l, int h) { return; }

    }
}
