using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE1.Propositions
{
    public class NAND : Proposition
    {
        //Constructor
        public NAND()
        {
            Notation = "%";
        }



        //Methods
        public override bool? GetNodeValue(List<Pro> vars)
        {
            return !(LeftNode.GetNodeValue(vars) & RightNode.GetNodeValue(vars));
        }

        public override string Infix()
        {
            return $"({LeftNode.Infix()} {Notation} {RightNode.Infix()})";
        }

        public override string Prefix()
        {
            return $"{Notation}({LeftNode.Prefix()},{RightNode.Prefix()})";
        }

        public override Proposition GetNANDs() => this;
       
    }
}
