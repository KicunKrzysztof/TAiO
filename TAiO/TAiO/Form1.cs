using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Algorithm;
using Algorithm.Model;
using Point = Algorithm.Point;

namespace TAiO
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private static readonly int[,] SampleMatrix =
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 1, 0, 2, 2, 2, 0, 3, 0, 0, 0, 4, 0, 0, 0, 5, 5, 5, 0 },
            { 0, 1, 0, 1, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 5, 0, 5, 0 },
            { 0, 1, 1, 1, 0, 2, 2, 2, 0, 3, 0, 0, 0, 4, 0, 0, 0, 5, 0, 5, 0 },
            { 0, 1, 0, 1, 0, 2, 0, 0, 0, 3, 0, 0, 0, 4, 0, 0, 0, 5, 0, 5, 0 },
            { 0, 1, 0, 1, 0, 2, 2, 2, 0, 3, 3, 3, 0, 4, 4, 4, 0, 5, 5, 5, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        public Form1()
        {
            AllocConsole();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PiecesGenerator generator = new PiecesGenerator();
            var pieces = generator.GeneratePieces(7, 4);

            //var pieces = new List<Piece>
            //{
            //    new Piece(new List<Point>()
            //    {
            //        new Point(1,1),
            //        new Point(0,1),
            //        new Point(0,2),
            //        new Point(0,3)
            //    }),
            //    //new Piece(new List<Point>()
            //    //{
            //    //    new Point(1,1),
            //    //    new Point(1,2),
            //    //    new Point(2,1),
            //    //    new Point(2,2)
            //    //}),
            //    new Piece(new List<Point>()
            //    {
            //        new Point(0,1),
            //        new Point(0,2),
            //        new Point(0,3),
            //        new Point(1,2)
            //    }),
            //    //new Piece(new List<Point>()
            //    //{
            //    //    new Point(0,0),
            //    //    new Point(0,0),
            //    //    new Point(0,0),
            //    //    new Point(0,0)
            //    //}),
            //};
            var solutionFinder = new SmallestSquareOptimalFinder(pieces);

            List<int[,]> boards = new List<int[,]>();
            solutionFinder.OnBoardUpdate += (o, args) =>
            {
                boards.Add((int[,])o);
            };

            var solutions = solutionFinder.CalculateSolutions();
           

            if (solutions != null)
            {
                foreach (var solution in solutions)
                {
                    tetrisMatrix1.PutMatrix(solution);
                    Task.Delay(300).Wait();
                }
            }
        }
    }
}
