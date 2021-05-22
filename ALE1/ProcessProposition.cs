using ALE1.Propositions;
using ALE1.Truth_Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALE1
{
    public class ProcessProposition
    {
        //Properties
        public Proposition RootProp { get; set; }
        public List<string> Variables { get; set; }


        //Constructor
        public ProcessProposition()
        {
            RootProp = null;
        }

        //Methods
        public Proposition InsertInBinaryTree(ref string s)
        {
            Proposition root = null;
            switch (s[0])
            {
                case '>':
                    {
                        root = new Implication();
                        s = s.Substring(2);
                        while (s[0] != ',')
                        {
                            root.LeftNode = InsertInBinaryTree(ref s);
                            s = s.Substring(1);
                        }
                        s = s.Substring(1);
                        while (s[0] != ')')
                        {
                            root.RightNode = InsertInBinaryTree(ref s);
                            s = s.Substring(1);
                        }
                        break;
                    }
                case '=':
                    {
                        root = new BiImplication();
                        s = s.Substring(2);
                        while (s[0] != ',')
                        {
                            root.LeftNode = InsertInBinaryTree(ref s);
                            s = s.Substring(1);
                        }
                        s = s.Substring(1);
                        while (s[0] != ')')
                        {
                            root.RightNode = InsertInBinaryTree(ref s);
                            s = s.Substring(1);
                        }
                        break;
                    }
                case '&':
                    {
                        root = new And();
                        s = s.Substring(2);
                        while (s[0] != ',')
                        {
                            root.LeftNode = InsertInBinaryTree(ref s);
                            s = s.Substring(1);
                        }
                        s = s.Substring(1);
                        while (s[0] != ')')
                        {
                            root.RightNode = InsertInBinaryTree(ref s);
                            s = s.Substring(1);
                        }
                        break;
                    }
                case '|':
                    {
                        root = new Or();
                        s = s.Substring(2);
                        while (s[0] != ',')
                        {
                            root.LeftNode = InsertInBinaryTree(ref s);
                            s = s.Substring(1);
                        }
                        s = s.Substring(1);
                        while (s[0] != ')')
                        {
                            root.RightNode = InsertInBinaryTree(ref s);
                            s = s.Substring(1);
                        }
                        break;

                    }

                case '~':
                    {
                        root = new Negation();
                        s = s.Substring(2);
                        while (s[0] != ')')
                        {
                            root.LeftNode = InsertInBinaryTree(ref s);
                            s = s.Substring(1);
                        }
                        break;
                    }
                case '%':
                    {
                        root = new NAND();
                        s = s.Substring(2);
                        while (s[0] != ',')
                        {
                            root.LeftNode = InsertInBinaryTree(ref s);
                            s = s.Substring(1);
                        }
                        s = s.Substring(1);
                        while (s[0] != ')')
                        {
                            root.RightNode = InsertInBinaryTree(ref s);
                            s = s.Substring(1);
                        }
                        break;
                    }
                default:
                    {
                        root = new Pro();
                        (root as Pro).Notation = s[0].ToString();
                        break;
                    }

            }
            return root;
        }
        public string GetInfix(Proposition p) => p.Infix();
        public string GetPrefix(Proposition p) => p.Prefix();

        /// <summary>
        /// Write the nodes and assign their orders to the file 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sw"></param>
        private void WriteFormulaToTextFile(Proposition root, StreamWriter sw)
        {
            if (root.OrderInFormula == 0)
                root.OrderInFormula = 1;
            sw.WriteLine($"  node{root.OrderInFormula} [ label = \"{root.Notation}\" ]");
            if (root.LeftNode != null)
            {
                root.LeftNode.OrderInFormula = root.OrderInFormula * 2;
                sw.WriteLine("   node" + root.OrderInFormula + " -- node" + root.LeftNode.OrderInFormula);
                WriteFormulaToTextFile(root.LeftNode, sw);
            }
            if (root.RightNode != null)
            {
                root.RightNode.OrderInFormula = root.OrderInFormula * 2 + 1;
                sw.WriteLine("   node" + root.OrderInFormula + " -- node" + root.RightNode.OrderInFormula);
                WriteFormulaToTextFile(root.RightNode, sw);
            }
        }

        /// <summary>
        /// Generate a text file to print the tree through GraphViz
        /// </summary>
        /// <param name="p"></param>
        /// <param name="filename"></param>
        public void GenerateTextFile(Proposition p, string filename)//Generate a text file to print the tree through GraphViz
        {
            FileStream fs = null;
            StreamWriter sw = null;
            fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs);
            try
            {
                sw.WriteLine("graph logic {");
                sw.WriteLine("   node [ fontname = \"Arial\" ]");
                WriteFormulaToTextFile(p, sw);
                sw.WriteLine("}");
            }
            catch (IOException i)
            {
                MessageBox.Show(i.Message);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }



        /// <summary>
        /// Add the variable of the function to the list
        /// </summary>
        public void FillTheVariablesList()
        {
            Variables = new List<string>();

            //Get the infix function from the prefix proposition
            string infixFunc = GetInfix(RootProp);

            char[] delemiterChars = { ' ', '~', '|', '>', '=', '&', '(', ')', '%' };
            foreach (char c in infixFunc)
            {
                //Not add c if c is a delimeter character or the existed variable
                if (!delemiterChars.Contains(c) && !Variables.Contains(c.ToString()))
                    Variables.Add(c.ToString());
            }

            //sort the variable list 
            Variables.Sort();
        }

        //Assign the value for 
        public void AssignRowValues(List<Row> rows)
        {
            foreach (Row r in rows)
            {
                r.BoolVal = RootProp.GetNodeValue(r.GetVariables());
            }
        }

    }
}
