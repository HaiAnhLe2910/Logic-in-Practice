namespace ALE1
{
    partial class MainForm
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
            this.gbParsing = new System.Windows.Forms.GroupBox();
            this.btnPrintTree = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.lbInfix = new System.Windows.Forms.Label();
            this.tbInfixRes = new System.Windows.Forms.TextBox();
            this.gbTruthTable = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSimplifiedTruthTable = new System.Windows.Forms.TextBox();
            this.tbTruthTable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHashCode = new System.Windows.Forms.TextBox();
            this.btnGenerateTruthTable = new System.Windows.Forms.Button();
            this.Normalize = new System.Windows.Forms.GroupBox();
            this.tbDisjuncSimpliPreF = new System.Windows.Forms.TextBox();
            this.tbDisjuncNormalPreF = new System.Windows.Forms.TextBox();
            this.tbDisjuncNormalInF = new System.Windows.Forms.TextBox();
            this.tbDisjuncSimpliInF = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbNANDInfix = new System.Windows.Forms.TextBox();
            this.tbNANDPrefix = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PictureBoxTree = new System.Windows.Forms.PictureBox();
            this.gbParsing.SuspendLayout();
            this.gbTruthTable.SuspendLayout();
            this.Normalize.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTree)).BeginInit();
            this.SuspendLayout();
            // 
            // gbParsing
            // 
            this.gbParsing.Controls.Add(this.btnPrintTree);
            this.gbParsing.Controls.Add(this.btnParse);
            this.gbParsing.Controls.Add(this.label2);
            this.gbParsing.Controls.Add(this.tbInput);
            this.gbParsing.Controls.Add(this.lbInfix);
            this.gbParsing.Controls.Add(this.tbInfixRes);
            this.gbParsing.Location = new System.Drawing.Point(16, 12);
            this.gbParsing.Name = "gbParsing";
            this.gbParsing.Size = new System.Drawing.Size(1291, 110);
            this.gbParsing.TabIndex = 0;
            this.gbParsing.TabStop = false;
            this.gbParsing.Text = "Parsing";
            // 
            // btnPrintTree
            // 
            this.btnPrintTree.Location = new System.Drawing.Point(1124, 59);
            this.btnPrintTree.Name = "btnPrintTree";
            this.btnPrintTree.Size = new System.Drawing.Size(150, 33);
            this.btnPrintTree.TabIndex = 22;
            this.btnPrintTree.Text = "Print Tree";
            this.btnPrintTree.UseVisualStyleBackColor = true;
            this.btnPrintTree.Click += new System.EventHandler(this.btnPrintTree_Click);
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(1124, 20);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(150, 33);
            this.btnParse.TabIndex = 9;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Input";
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(96, 25);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInput.Size = new System.Drawing.Size(1005, 26);
            this.tbInput.TabIndex = 0;
            // 
            // lbInfix
            // 
            this.lbInfix.AutoSize = true;
            this.lbInfix.Location = new System.Drawing.Point(6, 64);
            this.lbInfix.Name = "lbInfix";
            this.lbInfix.Size = new System.Drawing.Size(38, 20);
            this.lbInfix.TabIndex = 1;
            this.lbInfix.Text = "Infix";
            // 
            // tbInfixRes
            // 
            this.tbInfixRes.Location = new System.Drawing.Point(95, 66);
            this.tbInfixRes.Name = "tbInfixRes";
            this.tbInfixRes.Size = new System.Drawing.Size(1006, 26);
            this.tbInfixRes.TabIndex = 2;
            this.tbInfixRes.TextChanged += new System.EventHandler(this.tbInfixRes_TextChanged);
            // 
            // gbTruthTable
            // 
            this.gbTruthTable.Controls.Add(this.label6);
            this.gbTruthTable.Controls.Add(this.tbSimplifiedTruthTable);
            this.gbTruthTable.Controls.Add(this.tbTruthTable);
            this.gbTruthTable.Controls.Add(this.label3);
            this.gbTruthTable.Controls.Add(this.label1);
            this.gbTruthTable.Controls.Add(this.tbHashCode);
            this.gbTruthTable.Controls.Add(this.btnGenerateTruthTable);
            this.gbTruthTable.Location = new System.Drawing.Point(12, 390);
            this.gbTruthTable.Name = "gbTruthTable";
            this.gbTruthTable.Size = new System.Drawing.Size(469, 544);
            this.gbTruthTable.TabIndex = 3;
            this.gbTruthTable.TabStop = false;
            this.gbTruthTable.Text = "Truth Table";
            this.gbTruthTable.Enter += new System.EventHandler(this.gbTruthTable_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Simplified truth table";
            // 
            // tbSimplifiedTruthTable
            // 
            this.tbSimplifiedTruthTable.Location = new System.Drawing.Point(248, 117);
            this.tbSimplifiedTruthTable.Multiline = true;
            this.tbSimplifiedTruthTable.Name = "tbSimplifiedTruthTable";
            this.tbSimplifiedTruthTable.Size = new System.Drawing.Size(199, 415);
            this.tbSimplifiedTruthTable.TabIndex = 23;
            // 
            // tbTruthTable
            // 
            this.tbTruthTable.Location = new System.Drawing.Point(21, 117);
            this.tbTruthTable.Multiline = true;
            this.tbTruthTable.Name = "tbTruthTable";
            this.tbTruthTable.Size = new System.Drawing.Size(199, 415);
            this.tbTruthTable.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Truth table";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hash code";
            // 
            // tbHashCode
            // 
            this.tbHashCode.Location = new System.Drawing.Point(192, 34);
            this.tbHashCode.Name = "tbHashCode";
            this.tbHashCode.Size = new System.Drawing.Size(196, 26);
            this.tbHashCode.TabIndex = 7;
            // 
            // btnGenerateTruthTable
            // 
            this.btnGenerateTruthTable.Location = new System.Drawing.Point(17, 25);
            this.btnGenerateTruthTable.Name = "btnGenerateTruthTable";
            this.btnGenerateTruthTable.Size = new System.Drawing.Size(150, 35);
            this.btnGenerateTruthTable.TabIndex = 5;
            this.btnGenerateTruthTable.Text = "Generate ";
            this.btnGenerateTruthTable.UseVisualStyleBackColor = true;
            this.btnGenerateTruthTable.Click += new System.EventHandler(this.btnGenerateTruthTable_Click);
            // 
            // Normalize
            // 
            this.Normalize.Controls.Add(this.tbDisjuncSimpliPreF);
            this.Normalize.Controls.Add(this.tbDisjuncNormalPreF);
            this.Normalize.Controls.Add(this.tbDisjuncNormalInF);
            this.Normalize.Controls.Add(this.tbDisjuncSimpliInF);
            this.Normalize.Controls.Add(this.label5);
            this.Normalize.Controls.Add(this.label4);
            this.Normalize.Location = new System.Drawing.Point(16, 128);
            this.Normalize.Name = "Normalize";
            this.Normalize.Size = new System.Drawing.Size(1291, 157);
            this.Normalize.TabIndex = 12;
            this.Normalize.TabStop = false;
            this.Normalize.Text = "Normalize";
            // 
            // tbDisjuncSimpliPreF
            // 
            this.tbDisjuncSimpliPreF.Location = new System.Drawing.Point(138, 121);
            this.tbDisjuncSimpliPreF.Name = "tbDisjuncSimpliPreF";
            this.tbDisjuncSimpliPreF.Size = new System.Drawing.Size(1109, 26);
            this.tbDisjuncSimpliPreF.TabIndex = 16;
            // 
            // tbDisjuncNormalPreF
            // 
            this.tbDisjuncNormalPreF.Location = new System.Drawing.Point(138, 57);
            this.tbDisjuncNormalPreF.Name = "tbDisjuncNormalPreF";
            this.tbDisjuncNormalPreF.Size = new System.Drawing.Size(1109, 26);
            this.tbDisjuncNormalPreF.TabIndex = 15;
            // 
            // tbDisjuncNormalInF
            // 
            this.tbDisjuncNormalInF.Location = new System.Drawing.Point(138, 25);
            this.tbDisjuncNormalInF.Name = "tbDisjuncNormalInF";
            this.tbDisjuncNormalInF.Size = new System.Drawing.Size(1109, 26);
            this.tbDisjuncNormalInF.TabIndex = 14;
            // 
            // tbDisjuncSimpliInF
            // 
            this.tbDisjuncSimpliInF.Location = new System.Drawing.Point(138, 89);
            this.tbDisjuncSimpliInF.Name = "tbDisjuncSimpliInF";
            this.tbDisjuncSimpliInF.Size = new System.Drawing.Size(1109, 26);
            this.tbDisjuncSimpliInF.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Disjunc simplified";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Disjunc normal";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbNANDInfix);
            this.groupBox2.Controls.Add(this.tbNANDPrefix);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1295, 93);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "NAND";
            // 
            // tbNANDInfix
            // 
            this.tbNANDInfix.Location = new System.Drawing.Point(138, 57);
            this.tbNANDInfix.Name = "tbNANDInfix";
            this.tbNANDInfix.Size = new System.Drawing.Size(1109, 26);
            this.tbNANDInfix.TabIndex = 15;
            // 
            // tbNANDPrefix
            // 
            this.tbNANDPrefix.Location = new System.Drawing.Point(138, 25);
            this.tbNANDPrefix.Name = "tbNANDPrefix";
            this.tbNANDPrefix.Size = new System.Drawing.Size(1109, 26);
            this.tbNANDPrefix.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "nand";
            // 
            // PictureBoxTree
            // 
            this.PictureBoxTree.Location = new System.Drawing.Point(487, 401);
            this.PictureBoxTree.Name = "PictureBoxTree";
            this.PictureBoxTree.Size = new System.Drawing.Size(820, 533);
            this.PictureBoxTree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxTree.TabIndex = 23;
            this.PictureBoxTree.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 974);
            this.Controls.Add(this.PictureBoxTree);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Normalize);
            this.Controls.Add(this.gbTruthTable);
            this.Controls.Add(this.gbParsing);
            this.Name = "MainForm";
            this.Text = "ALE1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbParsing.ResumeLayout(false);
            this.gbParsing.PerformLayout();
            this.gbTruthTable.ResumeLayout(false);
            this.gbTruthTable.PerformLayout();
            this.Normalize.ResumeLayout(false);
            this.Normalize.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbParsing;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label lbInfix;
        private System.Windows.Forms.TextBox tbInfixRes;
        private System.Windows.Forms.GroupBox gbTruthTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHashCode;
        private System.Windows.Forms.Button btnGenerateTruthTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrintTree;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSimplifiedTruthTable;
        private System.Windows.Forms.TextBox tbTruthTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox Normalize;
        private System.Windows.Forms.TextBox tbDisjuncSimpliPreF;
        private System.Windows.Forms.TextBox tbDisjuncNormalPreF;
        private System.Windows.Forms.TextBox tbDisjuncNormalInF;
        private System.Windows.Forms.TextBox tbDisjuncSimpliInF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbNANDInfix;
        private System.Windows.Forms.TextBox tbNANDPrefix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox PictureBoxTree;
    }
}

