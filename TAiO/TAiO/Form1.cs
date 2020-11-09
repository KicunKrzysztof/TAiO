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
using System.IO;

namespace TAiO
{
    public partial class Form1 : Form
    {
        private CancellationToken showSolutionCancellationToken;
        private List<Solution> solutions;
        private readonly AlghoritmRunner alghoritmRunner = new AlghoritmRunner();
        private readonly string solutionsText = "Rozwiązania";

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
            SetSolutions(new List<Solution>());
            generateRadio.Checked = true;
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
            if (generateRadio.Checked)
            {
                StartJob(new Job((int)pieceSize.Value, new List<int>() { (int)pieceCount.Value }, type));
            }
            else
            {
                List<int> n_list = InputManagement.ParseNList(sequenceTextBox.Text);
                if (n_list == null)
                    return;
                StartJob(new Job((int)pieceSize.Value, n_list, type));
            }
        }

        private void StartJob(Job job)
        {
            List<Solution> solutions = new List<Solution>();
            if (job.NList == null)
                return;
            if (job.NList.Count == 1)
            {
                {
                    solutions = alghoritmRunner.Run(job.AlgorithmType, job.PieceSize, job.NList[0]);
                }
            }
            else
            {
                if (job.AlgorithmType == AlgorithmType.Optimal)
                {
                    solutions = alghoritmRunner.RunPredefined(job.PieceSize, job.NList);
                }
                else
                {
                    solutions = alghoritmRunner.Run(job.AlgorithmType, job.PieceSize, job.NList);
                }
            }
            solutions = solutions?.OrderBy(a => Guid.NewGuid()).ToList();
            SetSolutions(solutions);

        }

        private void ShowSolutions(List<Solution> solutions)
        {
            var tokenSource = new CancellationTokenSource();
            showSolutionCancellationToken = tokenSource.Token;
            Task.Run((() =>
            {
                foreach (var solution in solutions)
                {
                    tetrisMatrix1.PutMatrix(solution.Board);
                    Task.Delay(300).Wait();
                }
            }), showSolutionCancellationToken);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            var jobs = InputManagement.ParseFile(fileContent);
            Task.Run((() =>
            {
                foreach (var job in jobs)
                {
                    StartJob(job);
                    Task.Delay(1000).Wait();
                }
            }));
        }

        private void SetSolutions(List<Solution> solutions)
        {
            this.solutions = solutions;
            if (solutions == null || this.solutions.Count == 0)
            {
                solutionsLabel.Visible = false;
                solutionRange.Visible = false;
                solutionRange.Maximum = 0;
                solutionRange.Minimum = 0;
                return;
            }

            solutionRange.Visible = true;
            solutionsLabel.Visible = true;
            solutionRange.Maximum = solutions.Count;
            solutionRange.Minimum = 1;
            solutionRange.Focus();
            solutionsLabel.Text = solutionsText + $" 0/{solutions.Count}";
            if (solutions.Count == 1)
            {
                solutionsLabel.Visible = false;
                solutionRange.Visible = false;
            }
            DrawSolution(0);
        }

        private void DrawSolution(int solutionIndex)
        {
            var solution = solutions[solutionIndex];
            tetrisMatrix1.PutMatrix(solution.Board);
        }
        private void solutionRange_Scroll(object sender, EventArgs e)
        {
            solutionsLabel.Text = solutionsText + $" {solutionRange.Value}/{solutions.Count}";
            DrawSolution(solutionRange.Value - 1);
        }

        private void sequenceRadio_CheckedChanged(object sender, EventArgs e)
        {
            sequenceLabel.Visible = true;
            sequenceFileButton.Visible = true;
            sequenceTextBox.Visible = true;
            pieceCount.Enabled = false;

        }

        private void generateRadio_CheckedChanged(object sender, EventArgs e)
        {
            sequenceLabel.Visible = false;
            sequenceFileButton.Visible = false;
            sequenceTextBox.Visible = false;
            pieceCount.Enabled = true;
        }

    }
}
