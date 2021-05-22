using ALE1.Propositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE1.Truth_Table
{
    public class Row
    {
        //fields
        private List<Pro> vars;

        //properties
        public bool? BoolVal { get; set; }


        //constructor
        public Row(List<Pro> vars)
        {
            this.vars = vars;
        }

        //Methods

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach(Pro variable in GetVariables())
            {
                output.Append(variable.BooleanValue == true ? "1" : variable.BooleanValue == false ? "0" : "*");
                output.Append("    ");
            }

            output.Append(BoolVal == true ? "1" : "0");
            return output.ToString();
        }


        //get list<Variables> in the sorted order  
        public List<Pro> GetVariables()
        {
            vars.Sort(new SortVariableName());
            return vars;
        }


        /// <summary>
        /// Check if 2 rows can be simplified with each other
        /// True if there is ONE difference in the variable values
        /// False in other cases
        /// </summary>
        /// <param name="anotherRow"></param>
        /// <returns></returns>
        public bool CanSimplifyWith(Row anotherRow)
        {
            int nrOfDiff = 0;

            for (int i = 0; i < vars.Count; i++)
            {
                if (GetVariables()[i].BooleanValue != anotherRow.GetVariables()[i].BooleanValue)
                    nrOfDiff++;
            }
            return nrOfDiff == 1 ? true : false;
        }

        /// <summary>
        /// Check if this row already exists in the rows list
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public bool Existed(List<Row> rows)
        {
            foreach (Row row in rows)
            {
                if (this.IsEqualTo(row))
                    return true;
            }
            return false;
        }
        
        /// <summary>
        /// Check if this row is equal to anotherRow
        /// </summary>
        /// <param name="anotherRow"></param>
        /// <returns>true if there is no difference in the variables values; otherwise false</returns>
        public bool IsEqualTo(Row anotherRow)
        {
            int nrOfDiff = 0;
            for(int i=0;i< anotherRow.vars.Count;i++)
            {
                if (GetVariables()[i].BooleanValue != anotherRow.GetVariables()[i].BooleanValue)
                    nrOfDiff++;
            }

            if (nrOfDiff == 0)
                return true;
            return false;
        }

        /// <summary>
        /// return the simplified row between 2 rows  
        /// </summary>
        /// <param name="anotherRow"></param>
        /// <returns></returns>
        public Row GetSimplifiedRowWith(Row anotherRow)
        {
            Row rowToSimplify = this.CopyRow();
            for (int i = 0; i < vars.Count; i++)
            {
                if (GetVariables()[i].BooleanValue != anotherRow.GetVariables()[i].BooleanValue)
                    rowToSimplify.GetVariables()[i].BooleanValue = null;
            }
            return rowToSimplify;
        }


        /// <summary>
        ///Return the new row that is the copy
        /// </summary>
        public Row CopyRow()
        {
            List<Pro> newVarList = new List<Pro>();
            for (int i = 0; i < vars.Count; i++)
            {
                Pro v = new Pro();
                v.Notation = GetVariables()[i].Notation;
                v.BooleanValue = GetVariables()[i].BooleanValue;
                newVarList.Add(v);
            }
            return new Row(newVarList);
        }

        /// <summary>
        /// Get DNF recursively by examine all variables
        /// </summary>
        /// <param name="vars"></param>
        /// <returns></returns>
        private Proposition GetDNFRecursively(List<Pro> vars)
        {
            Proposition root = new And();
         
            if (vars[0].BooleanValue == true)
                root.LeftNode = vars[0];
            else if (vars[0].BooleanValue == false)
            {
                root.LeftNode = new Negation();
                root.LeftNode.LeftNode = vars[0];
            }
            else
                root.LeftNode = null;

            vars.RemoveAt(0);
            
            if(vars.Count==0)
                root.RightNode = null;
            else if(vars.Count==1)
            {

                if (vars[0].BooleanValue == true)
                    root.RightNode = vars[0];
                else if (vars[0].BooleanValue == false)
                {
                    root.RightNode = new Negation();
                    root.RightNode.LeftNode = vars[0];
                }
                else
                    root.RightNode = null;
            }
            else 
                root.RightNode = GetDNFRecursively(vars);
            

            if (root.LeftNode == null && root.RightNode == null)
                root = null;
            else if (root.LeftNode != null && root.RightNode == null)
                root = root.LeftNode;
            else if (root.LeftNode == null && root.RightNode != null)
                root = root.RightNode;
            return root;
        }

        /// <summary>
        /// Get DNF of the row
        /// </summary>
        /// <returns></returns>
        public Proposition GetDNF()
        {
            Row newRow = CopyRow();
            return GetDNFRecursively(newRow.vars);
        }
    


    }
}
