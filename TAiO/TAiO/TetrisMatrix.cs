using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAiO
{
    public partial class TetrisMatrix : PictureBox
    {
        private int[,] _matrix;
        private List<Color> _colors;
        public TetrisMatrix()
        {
            InitializeComponent();
            InitMatrix();
        }

        public void PutMatrix(int [,] matrix)
        {
            _matrix = matrix;
            this.Invalidate();
            Console.WriteLine("kutas");
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            //Bitmap btm = new Bitmap(this.Size.Width, this.Size.Height);

            SolidBrush myBrush = new SolidBrush(Color.White);
            //SolidBrush myBrush = new SolidBrush(Color.FromArgb(0,0,0));
            pe.Graphics.FillRectangle(myBrush, new Rectangle(0, 0, Size.Width, Size.Height));
            myBrush.Dispose();
          
            int delta = Size.Height / Math.Max(_matrix.GetLength(0), _matrix.GetLength(1));
            int y = 0, x = 0, a = delta*_matrix.GetLength(0);

            GenerateColors();
            List<SolidBrush> brushes = new List<SolidBrush>();
            for (int i = 0; i < _colors.Count; i++)
                brushes.Add(new SolidBrush(_colors[i]));
            for (int i = 0; i < _matrix.GetLength(0); i++)
                for (int j = 0; j < _matrix.GetLength(0); j++)
                {
                    pe.Graphics.FillRectangle(brushes[_matrix[i, j]], j * delta, i * delta, delta, delta);
                }
            for (int i = 0; i < _colors.Count; i++)
                brushes[i].Dispose();
            Pen pen = new Pen(Color.Black);
            for(int i = 0; i <= _matrix.GetLength(0); i++)
            {
                pe.Graphics.DrawLine(pen, 0, y, a, y);
                y += delta;
                pe.Graphics.DrawLine(pen, x, 0, x, a);
                x += delta;
            }
            pen.Dispose();

            //Pen myPen = new Pen(Color.Aqua);
            //pe.Graphics.DrawRectangle(myPen, new Rectangle(this.Location,
            //   this.Size));
            Console.WriteLine("dupa");

        }
        private void InitMatrix()
        {
            _matrix =  new int[30, 30];
            for(int i = 0; i < _matrix.GetLength(0); i++)
                for(int j = 0; j < _matrix.GetLength(0); j++)
                {
                    _matrix[i, j] = i;
                }
        }

        private void GenerateColors()
        {
            Random rand = new Random();
            _colors = new List<Color>();
            HashSet<int> intSet = new HashSet<int>();
            for (int i = 0; i < _matrix.GetLength(0); i++)
                for (int j = 0; j < _matrix.GetLength(0); j++)
                {
                    if (!intSet.Contains(_matrix[i, j]))
                    {
                        intSet.Add(_matrix[i, j]);
                    }
                }
            int delta = 255 / (intSet.Count + 1);//"+1" to avoid generating white color
            int r = 255 - delta; //to avoid generating white color
            _colors.Add(Color.White);
            for (int i = 1; i<intSet.Count; i++)
            {
                _colors.Add(Color.FromArgb(r, rand.Next(255), rand.Next(255)));
                r -= delta;
            }
        }
    }
}
