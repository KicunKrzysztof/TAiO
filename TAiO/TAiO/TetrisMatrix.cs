using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            GenerateColors();
        }

        public void PutMatrix(int [,] matrix)
        {
            _matrix = matrix;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            int delta = Size.Height / Math.Max(_matrix.GetLength(0), _matrix.GetLength(1));
            int y = 0, x = 0, a = delta*_matrix.GetLength(0);
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
            var colors = new List<Color>
            {
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Orange,
                Color.Purple,
                Color.Brown,
                Color.Black,
                Color.Magenta,
                Color.Aqua,
                Color.BlueViolet,
                Color.Chartreuse,
                Color.Chocolate,
                Color.Coral,
                Color.Crimson,
                Color.DarkBlue,
                Color.DarkCyan,
                Color.DarkGoldenrod,
                Color.DarkGray,
                Color.DarkGreen,
                Color.DarkOrange,
                Color.DarkRed,
                Color.DarkSlateBlue,
                Color.DeepPink,
                Color.DodgerBlue,
                Color.Firebrick,
                Color.DarkViolet,
                Color.ForestGreen,
                Color.Gold,
                Color.Goldenrod,
                Color.GreenYellow,
                Color.IndianRed,
                Color.Indigo,
                Color.LawnGreen,
                Color.LightSeaGreen,
                Color.Lime,
                Color.LimeGreen,
                Color.Maroon,
                Color.MediumBlue,
                Color.MediumVioletRed,
                Color.MidnightBlue,
                Color.Navy,
                Color.Olive,
                Color.Yellow,
                Color.Tomato,
                Color.Teal,
                Color.SpringGreen,
                Color.Sienna,
                Color.SaddleBrown,
                //-------------------same:
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Orange,
                Color.Purple,
                Color.Brown,
                Color.Black,
                Color.Magenta,
                Color.Aqua,
                Color.BlueViolet,
                Color.Chartreuse,
                Color.Chocolate,
                Color.Coral,
                Color.Crimson,
                Color.DarkBlue,
                Color.DarkCyan,
                Color.DarkGoldenrod,
                Color.DarkGray,
                Color.DarkGreen,
                Color.DarkOrange,
                Color.DarkRed,
                Color.DarkSlateBlue,
                Color.DeepPink,
                Color.DodgerBlue,
                Color.Firebrick,
                Color.DarkViolet,
                Color.ForestGreen,
                Color.Gold,
                Color.Goldenrod,
                Color.GreenYellow,
                Color.IndianRed,
                Color.Indigo,
                Color.LawnGreen,
                Color.LightSeaGreen,
                Color.Lime,
                Color.LimeGreen,
                Color.Maroon,
                Color.MediumBlue,
                Color.MediumVioletRed,
                Color.MidnightBlue,
                Color.Navy,
                Color.Olive,
                Color.Yellow,
                Color.Tomato,
                Color.Teal,
                Color.SpringGreen,
                Color.Sienna,
                Color.SaddleBrown
            };
            colors.AddRange(typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Select(c => (Color)c.GetValue(null, null))
                .ToList());
            _colors = new List<Color>();
            _colors.Add(Color.White);
            _colors.AddRange(colors);
        }
    }
}
