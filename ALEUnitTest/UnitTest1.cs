using System;
using ALE1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ALEUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Parse_to_infix()
        {
            var form = new MainForm();
            ProcessProposition myProcessing = new ProcessProposition();
            string input = "|(B,>(&(|(A,C),|(C,>(A,A))),>(&(&(|(&(B,&(B,B)),~(B)),&(A,=(A,~(|(A,A))))),B),|(&(=(C,C),C),C))))";
            myProcessing.RootProp = myProcessing.InsertInBinaryTree(ref input);
            myProcessing.GenerateTextFile(myProcessing.RootProp, "propositions.dot");
            Assert.AreEqual(myProcessing.GetInfix(myProcessing.RootProp), "(B | (((A | C) & (C | (A > A))) > (((((B & (B & B)) | ~ B) & (A & (A = ~ (A | A)))) & B) > (((C = C) & C) | C))))");
        }

        [TestMethod]
        public void Get_hash_code()
        {
            ProcessProposition myProcessing = new ProcessProposition();
            string input = "|(B,>(&(|(A,C),|(C,>(A,A))),>(&(&(|(&(B,&(B,B)),~(B)),&(A,=(A,~(|(A,A))))),B),|(&(=(C,C),C),C))))";
            myProcessing.RootProp = myProcessing.InsertInBinaryTree(ref input);
            myProcessing.FillTheVariablesList();

            ALE1.Truth_Table.TruthTable myTruthTable = new ALE1.Truth_Table.TruthTable(myProcessing.Variables);
            myProcessing.AssignRowValues(myTruthTable.GetRows());

            Assert.AreEqual(myTruthTable.GetHashCodeTB(), "FF");
        }

        [TestMethod]
        public void GetDNFInfix()
        {
            ProcessProposition myProcessing = new ProcessProposition();
            string input = "|(B,>(&(|(A,C),|(C,>(A,A))),>(&(&(|(&(B,&(B,B)),~(B)),&(A,=(A,~(|(A,A))))),B),|(&(=(C,C),C),C))))";
            myProcessing.RootProp = myProcessing.InsertInBinaryTree(ref input);
            myProcessing.FillTheVariablesList();

            ALE1.Truth_Table.TruthTable myTruthTable = new ALE1.Truth_Table.TruthTable(myProcessing.Variables);
            myTruthTable.ToString();
            myProcessing.AssignRowValues(myTruthTable.GetRows());

            Assert.AreEqual(myTruthTable.GetDNF().Infix(), "((~ A & (~ B & ~ C)) | ((~ A & (~ B & C)) | ((~ A & (B & ~ C)) | ((~ A & (B & C)) | ((A & (~ B & ~ C)) | ((A & (~ B & C)) | ((A & (B & ~ C)) | (A & (B & C)))))))))");
        }

        [TestMethod]
        public void GetDNFPrefix()
        {
            
            ProcessProposition myProcessing = new ProcessProposition();
            
            string input = "|(B,>(&(|(A,C),|(C,>(A,A))),>(&(&(|(&(B,&(B,B)),~(B)),&(A,=(A,~(|(A,A))))),B),|(&(=(C,C),C),C))))";
            myProcessing.RootProp = myProcessing.InsertInBinaryTree(ref input);
            myProcessing.FillTheVariablesList();

            ALE1.Truth_Table.TruthTable myTruthTable = new ALE1.Truth_Table.TruthTable(myProcessing.Variables);
            myProcessing.AssignRowValues(myTruthTable.GetRows());

            Assert.AreEqual(myTruthTable.GetDNF().Prefix(), "|(&(~(A),&(~(B),~(C))),|(&(~(A),&(~(B),C)),|(&(~(A),&(B,~(C))),|(&(~(A),&(B,C)),|(&(A,&(~(B),~(C))),|(&(A,&(~(B),C)),|(&(A,&(B,~(C))),&(A,&(B,C)))))))))");
        }

        [TestMethod]
        public void GetDNFSimplePrefix()
        {
            ProcessProposition myProcessing = new ProcessProposition();
            string input = "&(~(A),>(>(C,|(D,E)),~(B)))";
            myProcessing.RootProp = myProcessing.InsertInBinaryTree(ref input);
            myProcessing.FillTheVariablesList();

            ALE1.Truth_Table.TruthTable myTruthTable = new ALE1.Truth_Table.TruthTable(myProcessing.Variables);
            myTruthTable.SimplifiedTableToString();
            myProcessing.AssignRowValues(myTruthTable.GetRows());

            Assert.AreEqual(myTruthTable.GetDNFSimple().Prefix(), "|(&(~(A),~(B)),&(~(A),&(C,&(~(D),~(E)))))");

        }

        [TestMethod]
        public void GetDNFSimpleInfix()
        {
            ProcessProposition myProcessing = new ProcessProposition();
            string input = "%(~(A),>(>(C,|(D,E)),~(B)))";
            myProcessing.RootProp = myProcessing.InsertInBinaryTree(ref input);
            myProcessing.FillTheVariablesList();

            ALE1.Truth_Table.TruthTable myTruthTable = new ALE1.Truth_Table.TruthTable(myProcessing.Variables);
            myProcessing.AssignRowValues(myTruthTable.GetRows());

            Assert.AreEqual(myTruthTable.GetDNFSimple().Infix(), "(A | ((B & ~ C) | ((B & E) | (B & D))))");

        }

        [TestMethod]
        public void GetNANDPrefix()
        {
            ProcessProposition myProcessing = new ProcessProposition();
            string input = "&(~(A),=(>(C,|(D,E)),~(B)))";
            myProcessing.RootProp = myProcessing.InsertInBinaryTree(ref input);
            myProcessing.FillTheVariablesList();

            Assert.AreEqual(myProcessing.GetPrefix(myProcessing.RootProp.GetNANDs()), "%(%(%(A,A),%(%(%(%(C,%(%(%(D,D),%(E,E)),%(%(D,D),%(E,E)))),%(C,%(%(%(D,D),%(E,E)),%(%(D,D),%(E,E))))),%(%(B,B),%(B,B))),%(%(C,%(%(%(D,D),%(E,E)),%(%(D,D),%(E,E)))),%(B,B)))),%(%(A,A),%(%(%(%(C,%(%(%(D,D),%(E,E)),%(%(D,D),%(E,E)))),%(C,%(%(%(D,D),%(E,E)),%(%(D,D),%(E,E))))),%(%(B,B),%(B,B))),%(%(C,%(%(%(D,D),%(E,E)),%(%(D,D),%(E,E)))),%(B,B)))))");


        }

    }
}
