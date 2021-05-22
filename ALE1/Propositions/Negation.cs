using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE1.Propositions
{
    class Negation:Proposition
    {
        //Constructor
        public Negation()
        {
            Notation = "~";
        }

        //Methods
        public override string Infix()
        {
            return $"{Notation} {LeftNode.Infix()}";
        }
        public override string Prefix()
        {
            return $"{Notation}({LeftNode.Prefix()})";
        }
        public override bool? GetNodeValue(List<Pro> vars)
        {
            return !LeftNode.GetNodeValue(vars);
        }

        public override Proposition GetNANDs()
        {
            Proposition output = new NAND();
            output.LeftNode = LeftNode.GetNANDs();
            output.RightNode = LeftNode.GetNANDs();
            return output;
        }
    }
}
