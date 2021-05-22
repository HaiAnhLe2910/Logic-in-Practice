using ALE1.Propositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE1.Truth_Table
{
    public class TruthTable
    {
        //fields
        private List<string> varName;
        private List<Row> rows;

        //Constructor
        public TruthTable(List<string> varName)
        {
            this.varName = varName;
            rows = new List<Row>();
            GenerateTruthTable();
        }


        //Methods
        /// <summary>
        /// Construct the truth table
        /// </summary>
        public void GenerateTruthTable()
        {
            //number of rows = 2^number of variables
            int nrOfRows = Convert.ToInt32(Math.Pow(2, varName.Count));

            for (int i = 0; i < nrOfRows ; i++)
            {
                int varIndexInRow = 0;

                //Create a list of variables for each row
                List<Pro> varList = new List<Pro>();

                for (int j = varName.Count - 1; j >= 0; j--)
                {
                    Pro myVar = new Pro();
                    myVar.Notation = varName[varIndexInRow];//set notation
                    int value = i / Convert.ToInt32(Math.Pow(2, j)) % 2;
                    myVar.BooleanValue = value == 1;//set boolean value

                    varList.Add(myVar);
                    varIndexInRow++;
                }

                rows.Add(new Row(varList));
            }
        }


        /// <summary>
        /// return the complete truth table
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (string varname in varName)
            {
                output.Append($"{varname}");
                output.Append("    ");
            }
            output.Append("v");
            output.Append(Environment.NewLine);


            foreach (Row row in rows)
            {
                output.Append(row.ToString());
                output.Append(Environment.NewLine);
            }
            return output.ToString();
        }

        /// <summary>
        /// return the complete simplified truth table
        /// </summary>
        /// <returns></returns>
        public string SimplifiedTableToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (string varname in varName)
            {
                output.Append($"{varname}");
                output.Append("    ");
            }
            output.Append("v");
            output.Append(Environment.NewLine);

            //Display the row with false result first
            foreach (Row row in GetSimplifiedTable(GetRowFasle()))
            {
                row.BoolVal = false;
                output.Append(row.ToString());
                output.Append(Environment.NewLine);
            }
            
            //Then display the row with true result 
            foreach (Row row in GetSimplifiedTable(GetRowTrue()))
            {
                row.BoolVal = true;
                output.Append(row.ToString());
                output.Append(Environment.NewLine);
            }
            return output.ToString();
        }

        public List<Row> GetRows() => rows;


        public List<Row> GetRowTrue() => rows.FindAll(row => row.BoolVal == true);


        public List<Row> GetRowFasle() => rows.FindAll(row => row.BoolVal == false);


        public List<bool?> GetRowsResult()
        {
            List<bool?> results = new List<bool?>();
            foreach (Row row in rows)
                results.Add(row.BoolVal);
            return results;
        }


        public List<Row> GetSimplifiedTable(List<Row> rows)
        {
            List<Row> affectedRows = new List<Row>();
            List<Row> simplifiedRows = new List<Row>();
            Row newRow;

            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = i + 1; j < rows.Count; j++)
                {

                    if (rows[i].CanSimplifyWith(rows[j]))
                    {
                        //Add row to affected Row list if it is not existed 
                        if (!affectedRows.Contains(rows[i]))
                            affectedRows.Add(rows[i]);
                        if (!affectedRows.Contains(rows[j]))
                            affectedRows.Add(rows[j]);

                        //retrieve the simplified row
                        newRow = rows[i].GetSimplifiedRowWith(rows[j]);
                        //if the new row is not existed in the simplifiedRows list, add it
                        if (!newRow.Existed(simplifiedRows))
                            simplifiedRows.Add(newRow);
                    }
                }
            }
            //Find out the row which is not affected by simplification
            foreach (Row r in rows)
            {
                if (!affectedRows.Contains(r))
                    simplifiedRows.Add(r);
            }

            if (affectedRows.Count != 0)
                simplifiedRows = GetSimplifiedTable(simplifiedRows);
            else
                simplifiedRows = rows;
            return simplifiedRows;
        }

        public string GetHashCodeTB()
        {
            string binary = string.Empty;
            for (int i = GetRowsResult().Count - 1; i >= 0; i--)
            {
                binary += GetRowsResult()[i] == true ? "1" : "0";
            }
            return ConvertBinaryToHexa(binary);
        }

        /// <summary>
        /// Convert the binary input to hexadecimal
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        public string ConvertBinaryToHexa(string binary)
        {
            string result = string.Empty;
            List<string> DigitIn1group = new List<string>();
            int mod8 = binary.Length % 8;
            if (mod8 != 0)
            {
                binary = binary.PadLeft((binary.Length / 8 + 1) * 8, '0');
            }
            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                DigitIn1group.Add(string.Format("{0:X2}", Convert.ToByte(eightBits, 2)));
            }
            result = string.Concat(DigitIn1group);
            return result;
        }

        /// <summary>
        /// Get the binary tree of DNF 
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        private Proposition GetDNFRecursively(List<Row> rows)
        {
            Proposition root = null;

            //if there is 1 row, return the DNF of it
            if(rows.Count==1)
            {
                root = rows[0].GetDNF();
            }

            //if there is more than 1 row, return a binary tree with root 'Or'
            else if(rows.Count>1)
            {
                root = new Or();
                root.LeftNode = rows[0].GetDNF();
                rows.RemoveAt(0);
                
                //if there is 1 row in the right, return the right node
                if (rows.Count == 1)
                    root.RightNode = rows[0].GetDNF();
                //if there is more than 1 row, create the right sub-tree
                else
                    root.RightNode = GetDNFRecursively(rows);
            }
            
            return root;
        }

        /// <summary>
        /// Get DNF
        /// </summary>
        /// <returns></returns>
        public Proposition GetDNF()
        {
            List<Row> rowsTrue = new List<Row>();
            foreach(Row row in GetRowTrue())
            {
                Row newRow = row.CopyRow();
                rowsTrue.Add(newRow);
            }
            return GetDNFRecursively(rowsTrue);
        }

        /// <summary>
        /// Get the binary tree DNF of simplified truth table with rowsTrue
        /// </summary>
        /// <returns></returns>
        public Proposition GetDNFSimple()
        {
            List<Row> rowsTrue = new List<Row>();
            foreach(Row row in GetSimplifiedTable(GetRowTrue()))
            {
                Row newRow = row.CopyRow();
                rowsTrue.Add(newRow);
            }
            return GetDNFRecursively(rowsTrue);
        }

    }
}
