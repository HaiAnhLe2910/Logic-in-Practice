using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE1.Propositions
{
    public class Pro:Proposition
    {
        //Properties
        public bool? BooleanValue { get; set; }

        //Constructor
        public Pro()
        {
        }

        //Method
        public override string Infix()
        {
            return Notation;
        }
        public override string Prefix()
        {
            return Notation;
        }
        public override bool? GetNodeValue(List<Pro> vars)
        {
            foreach (Pro v in vars)
            {
                if (v.Notation == Notation)
                    BooleanValue = v.BooleanValue;
            }
            return BooleanValue;
        }

        public override Proposition GetNANDs() => this;
    }
}
