using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;


namespace SortVisualiser
{
    abstract class Sorter
    {
        protected List<int> A;
        protected PictureBox Sender;
        protected int speed;
        protected Graphics g;



        public Sorter(List<int> A, PictureBox Sender, int speed)
        {
            this.A = A;
            this.Sender = Sender;
            this.speed = speed;
            g = Sender.CreateGraphics();

            DrawBase();

        }

        public abstract void Sort(IList<int> a);
        public abstract void Sort(IList<int> a,int l, int h);
        public int Speed
        {
            set
            {
                if (value > 0)
                    speed = value;
                else
                    speed = 0;
}
        }

        public void reDraw(int ind)
        {
                int x = (int)(((double)Sender.Width / A.Count) * ind);
                g.DrawLine(new Pen(Color.White, 3), new Point(x, 0), new Point(x, Sender.Height));
                g.DrawLine(new Pen(Color.Black, 3), new Point(x, Sender.Height), new Point(x, (int)(Sender.Height - (int)A[ind])));


        }
        public void DrawBase()
        {
            g.Clear(Color.White);

            for (int i = 0; i < A.Count; i++)
            {
                int x = (int)(((double)Sender.Width / A.Count) * i);

                Pen pen = new Pen(Color.Black, 3);
                g.DrawLine(pen, new Point(x, Sender.Height), new Point(x, (int)(Sender.Height - (int)A[i])));
            }
        }








  

        public static void swap(IList<int> list, int x, int y)
    {
        int temp = list[x];
        list[x] = list[y];
        list[y] = temp;

    }


}
}
