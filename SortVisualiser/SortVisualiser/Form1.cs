using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SortVisualiser
{
    public partial class Form1 : Form
    {
        Graphics g = null;
        public Form1()
        {
            InitializeComponent();
        }
        static Random R = new Random();
        List<int> Q;
        Sorter S;
        Thread t;


        private void Form1_Load(object sender, EventArgs e)
        {
            S = null;
            comboBox1.SelectedIndex = 0;
            Q = new List<int>();


        }
        private void DrawBase()
        {
            g.Clear(Color.White);

            for (int i = 0; i < elNumber.Value; i++)
            {
                int x = (int)(((double)pictureBox1.Width / elNumber.Value) * i);

                Pen pen = new Pen(Color.Black, 3);
                g.DrawLine(pen, new Point(x, pictureBox1.Height), new Point(x, (int)(pictureBox1.Height - (int)Q[i])));
            }
        }

      
        private void Gen(IList<int> list)
        {
            for (int i = 0; i < elNumber.Value; i++)
            {
                int ind = R.Next(elNumber.Value);
                if(ind != i)
                {
                    int temp = list[ind];
                    list[ind] = list[i];
                    list[i] = temp;
                }

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int speed = 100 - spBar.Value;

            string algSort = "";
            if (comboBox1.SelectedItem != null)
            {
                algSort = comboBox1.SelectedItem.ToString();
            }

            ThreadStart TS = delegate ()
            {
                try
                {
                    if(algSort == "BubbleSort")
                    {
                        S = new BubbleSort(Q, pictureBox1, speed);
                        S.Sort(Q);
                    }
                    else if (algSort == "InsertionSort")
                    {
                        S = new InsertionSort(Q, pictureBox1, speed);
                        S.Sort(Q);
                    }
                    else if(algSort == "QuickSort")
                    {
                        S = new QuickSort(Q, pictureBox1, speed);
                        S.Sort(Q,  0, Q.Count-1);
                    }
                    else if(algSort == "SelectionSort")
                    {
                        S = new SelectionSort(Q, pictureBox1, speed);
                        S.Sort(Q);
                    }
                    else if (algSort == "MergeSort")
                    {
                        S = new MergeSort(Q, pictureBox1, speed);
                        S.Sort(Q, 0, Q.Count-1);

                    }
                    else if (algSort == "CocktailSort")
                    {
                        S = new CocktailSort(Q, pictureBox1, speed);
                        S.Sort(Q);
                    }
                    else if (algSort == "HeapSort")
                    {
                        S = new HeapSort(Q, pictureBox1, speed);
                        S.Sort(Q);
                    }
                    MessageBox.Show("Finished");

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            };
            if (algSort != "")
            {
                if((t == null) || (t != null && t.IsAlive == false))
                {
                    t = new Thread(TS);
                    t.IsBackground = true;
                    t.Start();
                }
                
            }


        }
        private void DrawShuffle()
        {
            Q.Clear();
            for (int i = 0; i < elNumber.Value; i++)
            {
                int y = (int)((double)i / elNumber.Value * (pictureBox1.Height+1)) ;
                Q.Add(y);

            }
            Gen(Q);

            DrawBase();
        }
        private void shuffleB_Click(object sender, EventArgs e)
        {
            DrawShuffle();


        }

        private void spBar_ValueChanged(object sender, EventArgs e)
        {
            int speed = 100 - spBar.Value;
            if (S != null) S.Speed = speed;
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();

            this.Refresh();
            DrawShuffle();
        }
        
    }
}
