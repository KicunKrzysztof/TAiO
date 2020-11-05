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
using Algorithm.Heuristic;

namespace TAiO
{
    public partial class Form1 : Form
    {
        private readonly AlghoritmRunner alghoritmRunner = new AlghoritmRunner();
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
            InitializeComponent();
        }

        private void optimalButton(object sender, EventArgs e)
        {
            Start(AlgorithmType.Optimal);
        }

        private void heuristicButton(object sender, EventArgs e)
        {
            Start(AlgorithmType.Heuristic);
        }

        private void Start(AlgorithmType type)
        {
            List<int[,]> solutions = null;
            if (radioButton1.Checked)
            {
                solutions = alghoritmRunner.Run(type, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
            }
            else
            {
                List<int> n_list = InputManagement.ParseNList(textBox1.Text);
                if (n_list == null)
                    return;
                if(n_list.Count == 1)
                {
                    solutions = alghoritmRunner.Run(type, (int)numericUpDown1.Value, n_list[0]) ;
                }
                else
                {
                    solutions = alghoritmRunner.Run(type, (int)numericUpDown1.Value, n_list);
                }
            }
            if (solutions == null)
                return;
            Task.Run((() =>
            {
                foreach (var solution in solutions)
                {
                    tetrisMatrix1.PutMatrix(solution);
                    Task.Delay(300).Wait();
                }
            }));
        }
    }
}
