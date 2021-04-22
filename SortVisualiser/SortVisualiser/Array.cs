using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SortVisualiser
{
    class Array
    {
        List<int> start;

        public Array()
        {
            start = new List<int>();
        }
        public Array(IList<int> l)
        {
            start = new List<int>(l);
        }
        public Array(Array A)
        {
            this.start = A.start;
        }

        public void Add(int x)
        {
            start.Add(x);
        }
        
        public void Draw(Graphics G)
        {
            PointF x = new PointF(10, 0);
            Pen P = new Pen(Color.Black, 5);
            for(int i = 0; i< start.Count; i++)
            {
                PointF temp = new PointF(x.X, x.Y + start[i] * 10);
                G.DrawLine(P, x, temp);
                x.X += 10;
            }
        }
        public Array Sort()
        {
            List<int> temp = new List<int>(start);
            temp.Sort();
            return new Array(temp);

        }



        public int Count
        {
            get { return start.Count; }
        }

        public int this[int key]
        {
            get
            {
                return start[key];
            }
            set
            {
                start[key] = value;
            }
        }

    }
}
