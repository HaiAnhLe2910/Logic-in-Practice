using ALE1.Propositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE1.Truth_Table
{
    class SortVariableName:IComparer<Pro>
    {
        public int Compare(Pro x, Pro y)
        {
            return x.Notation.CompareTo(y.Notation);
        }
    }
}
