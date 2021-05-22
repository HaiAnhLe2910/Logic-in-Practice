using ALE1.Truth_Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALE1
{
    public partial class MainForm : Form
    {
        private ProcessProposition myProcessing;
        private TruthTable myTruthTable; 
        public MainForm()
        {
            InitializeComponent();
            myProcessing = new ProcessProposition();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 800);
        }

        private void tbInfixRes_TextChanged(object sender, EventArgs e)
        {

        }

        private void BuildTree()
        {
            try
            {
                string input = tbInput.Text.Replace(" ", string.Empty);
                myProcessing.RootProp = myProcessing.InsertInBinaryTree(ref input);
                myProcessing.FillTheVariablesList();
            }
            catch(Exception)
            {
                MessageBox.Show("Please enter a correct formula in the prefix notation!");
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
           
            BuildTree();
                
            //Display the infix notation of the formula
            tbInfixRes.Text = myProcessing.GetInfix(myProcessing.RootProp);

            //Create the truth table from the formula
            myTruthTable = new TruthTable(myProcessing.Variables);
            myProcessing.AssignRowValues(myTruthTable.GetRows());

            //Get DNF form
            GetDNF();
            GetDNFSimple();

            //Get nandify
            GetNAND();
            

        }

        
        private void GetDNF()
        {
            if(myTruthTable.GetDNF()!=null)
            {
                tbDisjuncNormalInF.Text = myTruthTable.GetDNF().Infix();
                tbDisjuncNormalPreF.Text = myTruthTable.GetDNF().Prefix();
            }
            else
            {
                tbDisjuncNormalInF.Text = "No DNF for this formula";
                tbDisjuncNormalPreF.Text = "No DNF for this formula";
            }
        }

        private void GetDNFSimple()
        {
            if(myTruthTable.GetDNFSimple()!=null)
            {
                tbDisjuncSimpliInF.Text = myTruthTable.GetDNFSimple().Infix();
                tbDisjuncSimpliPreF.Text = myTruthTable.GetDNFSimple().Prefix();
            }
            else
            {
                tbDisjuncSimpliInF.Text = "No DNF simple for this formula";
                tbDisjuncSimpliPreF.Text = "No DNF simple for this formula";
            }
        }

        //Get Nandify
        private void GetNAND()
        {
            tbNANDPrefix.Text = myProcessing.GetPrefix(myProcessing.RootProp.GetNANDs());
            tbNANDInfix.Text = myProcessing.GetInfix(myProcessing.RootProp.GetNANDs());

        }

        
        private void btnPrintTree_Click(object sender, EventArgs e)
        {
                BuildTree();
                string filename = "abc.dot";
                myProcessing.GenerateTextFile(myProcessing.RootProp, filename);

                Process dot = new Process();
                dot.StartInfo.FileName = "dot.exe";
                dot.StartInfo.Arguments = "-Tpng -oabc.png abc.dot";
                dot.StartInfo.CreateNoWindow = true;
                dot.Start();
                dot.WaitForExit();

                PictureBoxTree.ImageLocation = "abc.png";

        }

        private void gbTruthTable_Enter(object sender, EventArgs e)
        {

        }

        private void btnGenerateTruthTable_Click(object sender, EventArgs e)
        {
            BuildTree();

            //Create the truth table from the formula
            myTruthTable = new TruthTable(myProcessing.Variables);
            myProcessing.AssignRowValues(myTruthTable.GetRows());

            //Display both truth tables and hash code
            tbTruthTable.Text = myTruthTable.ToString();
            tbSimplifiedTruthTable.Text = myTruthTable.SimplifiedTableToString();
            tbHashCode.Text = myTruthTable.GetHashCodeTB();
        }


        

    }

}


