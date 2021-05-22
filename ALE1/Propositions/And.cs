using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE1.Propositions
{
    class And:Proposition
    {
        //Constructor
        public And() { Notation = "&"; }

        //Methods
        public override string Infix()
        {
            return $"({LeftNode.Infix()} {Notation} {RightNode.Infix()})";
        }
        public override string Prefix()
        {
            return $"{Notation}({LeftNode.Prefix()},{RightNode.Prefix()})";
        }
        public override bool? GetNodeValue(List<Pro> vars)
        {
            return LeftNode.GetNodeValue(vars) & RightNode.GetNodeValue(vars);
        }

        public override Proposition GetNANDs()
        {
            Proposition output = new NAND();
            output.LeftNode = new NAND();
            output.LeftNode.LeftNode = LeftNode.GetNANDs();
            output.LeftNode.RightNode = RightNode.GetNANDs();

            output.RightNode = new NAND();
            output.RightNode.LeftNode = LeftNode.GetNANDs();
            output.RightNode.RightNode = RightNode.GetNANDs();
            return output;
        }
    }
}
