using Activision_Mendeleyev_table.HelperClasses;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Activision_Mendeleyev_table.DrawingClasses
{
    class CollapseGraph
    {
        static Pen pen = Pens.Black;
        static Pen penExp = Pens.Red;
        static List<PointF> experiment = new List<PointF>();
        static bool experimetnIsPoints = true;

        static int upT = -1;
        static int downT = -1;

        Graphics g;
        BinSystem system;
        int a;

        Point[] right;
        Point[] left;

        public CollapseGraph(Graphics g, BinSystem system, int widht)
        {

            this.a = widht - 30;
            this.g = g;
            Collapse collapse = new Collapse(system);
            this.system = system;

            upT = upT == -1 ? (int)system.Tmax : upT;
            downT = downT == -1 ? (int)(0.20 * system.Tmax) : downT;

            right = new Point[collapse.right.Length];
            for (int i = 0; i < right.Length; i++)
            {
                int x = 30 + (int)(a * (1 - collapse.right[i].x));
                int y = a - (int)(a * ((collapse.right[i].t * system.Tmax - downT) / (upT - downT)));
                y = y > a ? a : y;

                right[i] = new Point(x, y);
            }

            left = new Point[collapse.left.Length];
            for (int i = 0; i < left.Length; i++)
            {
                int x = 30 + (int)(a * (collapse.left[i].x));
                int y = a - (int)(a * ((collapse.left[i].t * system.Tmax - downT) / (upT - downT)));
                y = y > a ? a : y;

                left[i] = new Point(x, y);
            }
        }

        static public Color Color
        {
            get { return pen.Color; }
            set { pen = new Pen(value); }
        }

        static public Color ExperimentColor
        {
            get { return penExp.Color; }
            set { penExp = new Pen(value); }
        }

        public void DrawCollapse()
        {
            g.DrawLines(pen, right);
            g.DrawLines(pen, left);
        }

        public void DrawAxes()
        {
            g.DrawString(string.Format("{0:f0}", upT), new Font("X", 8), Brushes.Black, new Point(0, 0));
            g.DrawString(string.Format("{0:f0}", downT), new Font("X", 8), Brushes.Black, new Point(0, a));

            g.DrawString(system.elementA, new Font("X", 14), Brushes.Black, new Point(30, a + 20));
            g.DrawString(system.elementB, new Font("X", 14), Brushes.Black, new Point(a, a + 20));

            g.DrawLine(Pens.Black, 30, 0, 30, a + 30);
            g.DrawLine(Pens.Black, 0, a, a + 30, a);

            for (double x = 0.1; x <= 0.5; x += 0.10)
            {
                g.DrawString(x.ToString(), new Font("X", 8), Brushes.Black, 20 + (float)(a * x), (float)a + 6);
                g.DrawString(x.ToString(), new Font("X", 8), Brushes.Black, 20 + (float)(a * (1 - x)), (float)a + 6);

                g.DrawLine(Pens.Black, 30 + (int)(a * x), a - 5, 30 + (int)(a * x), a + 5);
                g.DrawLine(Pens.Black, 30 + (int)(a * (1 - x)), a - 5, 30 + (int)(a * (1 - x)), a + 5);
            }

        }

        public void DrawExperiment()
        {
            List<Point> left = new List<Point>();
            List<Point> right = new List<Point>();

            foreach (var item in experiment)
            {

                int x = 30 + (int)(item.X * a);
                int y = a - (int)(((item.Y - downT) / (upT - downT)) * a);

                y = y > a ? a : y;

                if (item.X <= 0.5)
                    left.Add(new Point(x, y));
                else
                    right.Add(new Point(x, y));
            }

            if (!experimetnIsPoints)
            {
                Point[] arrLeft = left.ToArray();
                Point[] arrRight = right.ToArray();

                Array.Sort(arrLeft, (x, y) => (x.X.CompareTo(y.X)));
                Array.Sort(arrRight, (x, y) => (x.X.CompareTo(y.X)));

                if (left.Count > 1)
                    g.DrawLines(penExp, arrLeft);

                if (right.Count > 1)
                    g.DrawLines(penExp, arrRight);
            }
            else
            {
                foreach (var item in left)
                {
                    g.FillEllipse(penExp.Brush, item.X - 2, item.Y - 2, 4, 4);
                }
                foreach (var item in right)
                {
                    g.FillEllipse(penExp.Brush, item.X - 2, item.Y - 2, 4, 4);
                }
            }
        }

        static public bool ExperimentIsPoints
        {
            get { return experimetnIsPoints; }
            set { experimetnIsPoints = value; }
        }

        static public int UpTemp
        {
            get { return upT; }
            set { upT = value; }
        }

        static public int DownTemp
        {
            get { return downT; }
            set { downT = value; }
        }

        public static void addExperimentalPoint(double x1, double t)
        {
            experiment.Add(new PointF((float)x1, (float)t));
        }

        public static void removeLastPoint()
        {
            if (experiment.Count > 0)
                experiment.RemoveAt(experiment.Count - 1);
        }

        public static void clearExperiment()
        {
            experiment.Clear();
        }
    }
}
