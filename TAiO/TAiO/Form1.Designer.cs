namespace TAiO
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pieceSize = new System.Windows.Forms.NumericUpDown();
            this.pieceCount = new System.Windows.Forms.NumericUpDown();
            this.generateRadio = new System.Windows.Forms.RadioButton();
            this.sequenceRadio = new System.Windows.Forms.RadioButton();
            this.solutionsLabel = new System.Windows.Forms.Label();
            this.solutionRange = new System.Windows.Forms.TrackBar();
            this.sequenceLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sequenceTextBox = new System.Windows.Forms.TextBox();
            this.sequenceFileButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tetrisMatrix1 = new TAiO.TetrisMatrix();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solutionRange)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisMatrix1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.solutionsLabel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.solutionRange, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.sequenceLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(759, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 272F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(428, 768);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.button2, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.button1, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.pieceSize, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.pieceCount, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.generateRadio, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.sequenceRadio, 1, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(424, 268);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(2, 210);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 26);
            this.button2.TabIndex = 9;
            this.button2.Text = "Optymalny";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.optimalButton);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(214, 210);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 26);
            this.button1.TabIndex = 8;
            this.button1.Text = "Heurystyczny";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.heuristicButton);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Rozmiar ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ilość";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pieceSize
            // 
            this.pieceSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pieceSize.Location = new System.Drawing.Point(73, 183);
            this.pieceSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.pieceSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pieceSize.Name = "pieceSize";
            this.pieceSize.Size = new System.Drawing.Size(66, 20);
            this.pieceSize.TabIndex = 10;
            this.pieceSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // pieceCount
            // 
            this.pieceCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pieceCount.Location = new System.Drawing.Point(285, 183);
            this.pieceCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.pieceCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pieceCount.Name = "pieceCount";
            this.pieceCount.Size = new System.Drawing.Size(66, 20);
            this.pieceCount.TabIndex = 13;
            this.pieceCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // generateRadio
            // 
            this.generateRadio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generateRadio.AutoSize = true;
            this.generateRadio.Location = new System.Drawing.Point(133, 241);
            this.generateRadio.Name = "generateRadio";
            this.generateRadio.Size = new System.Drawing.Size(76, 17);
            this.generateRadio.TabIndex = 21;
            this.generateRadio.TabStop = true;
            this.generateRadio.Text = "Wygeneruj";
            this.generateRadio.UseVisualStyleBackColor = true;
            this.generateRadio.CheckedChanged += new System.EventHandler(this.generateRadio_CheckedChanged);
            // 
            // sequenceRadio
            // 
            this.sequenceRadio.AutoSize = true;
            this.sequenceRadio.Location = new System.Drawing.Point(215, 241);
            this.sequenceRadio.Name = "sequenceRadio";
            this.sequenceRadio.Size = new System.Drawing.Size(120, 17);
            this.sequenceRadio.TabIndex = 22;
            this.sequenceRadio.TabStop = true;
            this.sequenceRadio.Text = "Predefiniowany ciag";
            this.sequenceRadio.UseVisualStyleBackColor = true;
            this.sequenceRadio.CheckedChanged += new System.EventHandler(this.sequenceRadio_CheckedChanged);
            // 
            // solutionsLabel
            // 
            this.solutionsLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.solutionsLabel.AutoSize = true;
            this.solutionsLabel.Location = new System.Drawing.Point(180, 350);
            this.solutionsLabel.Name = "solutionsLabel";
            this.solutionsLabel.Size = new System.Drawing.Size(67, 13);
            this.solutionsLabel.TabIndex = 18;
            this.solutionsLabel.Text = "Rozwiązania";
            this.solutionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // solutionRange
            // 
            this.solutionRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.solutionRange.Location = new System.Drawing.Point(3, 375);
            this.solutionRange.Name = "solutionRange";
            this.solutionRange.Size = new System.Drawing.Size(422, 33);
            this.solutionRange.TabIndex = 17;
            this.solutionRange.Scroll += new System.EventHandler(this.solutionRange_Scroll);
            // 
            // sequenceLabel
            // 
            this.sequenceLabel.AutoSize = true;
            this.sequenceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sequenceLabel.Location = new System.Drawing.Point(3, 272);
            this.sequenceLabel.Name = "sequenceLabel";
            this.sequenceLabel.Size = new System.Drawing.Size(422, 34);
            this.sequenceLabel.TabIndex = 19;
            this.sequenceLabel.Text = "Ciąg";
            this.sequenceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.sequenceTextBox);
            this.flowLayoutPanel1.Controls.Add(this.sequenceFileButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 309);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(422, 30);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // sequenceTextBox
            // 
            this.sequenceTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sequenceTextBox.Location = new System.Drawing.Point(2, 6);
            this.sequenceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.sequenceTextBox.Name = "sequenceTextBox";
            this.sequenceTextBox.Size = new System.Drawing.Size(262, 20);
            this.sequenceTextBox.TabIndex = 15;
            // 
            // sequenceFileButton
            // 
            this.sequenceFileButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sequenceFileButton.Location = new System.Drawing.Point(268, 2);
            this.sequenceFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.sequenceFileButton.Name = "sequenceFileButton";
            this.sequenceFileButton.Size = new System.Drawing.Size(150, 29);
            this.sequenceFileButton.TabIndex = 16;
            this.sequenceFileButton.Text = "Z pliku";
            this.sequenceFileButton.UseVisualStyleBackColor = true;
            this.sequenceFileButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(191)))), ((int)(((byte)(244)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 434F));
            this.tableLayoutPanel1.Controls.Add(this.tetrisMatrix1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1190, 774);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tetrisMatrix1
            // 
            this.tetrisMatrix1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tetrisMatrix1.Location = new System.Drawing.Point(2, 2);
            this.tetrisMatrix1.Margin = new System.Windows.Forms.Padding(2);
            this.tetrisMatrix1.Name = "tetrisMatrix1";
            this.tetrisMatrix1.Size = new System.Drawing.Size(752, 770);
            this.tetrisMatrix1.TabIndex = 0;
            this.tetrisMatrix1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 774);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pieceSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieceCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solutionRange)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tetrisMatrix1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.NumericUpDown pieceCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown pieceSize;
        private System.Windows.Forms.TextBox sequenceTextBox;
        private System.Windows.Forms.Button sequenceFileButton;
        private TetrisMatrix tetrisMatrix1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label solutionsLabel;
        private System.Windows.Forms.TrackBar solutionRange;
        private System.Windows.Forms.RadioButton generateRadio;
        private System.Windows.Forms.RadioButton sequenceRadio;
        private System.Windows.Forms.Label sequenceLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

