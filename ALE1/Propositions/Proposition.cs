using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE1.Propositions
{
    public abstract class Proposition
    {
        //properties
        public Proposition LeftNode { get; set; }
        public Proposition RightNode { get; set; }
        public string Notation { get; set; }
        public int OrderInFormula { get; set; }

        //Constructor
        public Proposition()
        {
            LeftNode = RightNode = null;
            Notation = string.Empty;
            OrderInFormula = 0;

        }

        //methods
        public abstract string Infix();
        public abstract string Prefix();
        public abstract bool? GetNodeValue(List<Pro> vars);
        public abstract Proposition GetNANDs();

    }
}
