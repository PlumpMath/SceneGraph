using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SceneGraphReader.Scene;
using SceneGraphReader.Parser;

namespace UnitTests
{
    [TestClass]
    public class ParserTests
    {
        private SyntaxAnalyser testAnalyser;

        public ParserTests()
        {
            testAnalyser = new SyntaxAnalyser();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void CreateDefautTree()
        {
            SyntaxTreeNode node = SyntaxTreeNode.CreateDefaultTree();

            Assert.IsTrue(node.GetChildren().Count > 0);
        }

        [TestMethod]
        public void EmptyItemSyntax()
        {
            SyntaxTreeNode temp = testAnalyser.AnalyzeSyntax("==BG==\n==ITEMS==\n");

            if (temp != null)
            {
               Assert.AreEqual(temp.GetChildren()[1].value, "==ITEMS==\n");
               return;
            }
            
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void MapSyntax()
        {
            SyntaxTreeNode temp = testAnalyser.AnalyzeSyntax("==BG==\nMap\n(\n)\n==ITEMS==\n");

            if (temp != null)
            {
               Assert.AreEqual(temp.GetChildren()[0].GetChildren()[0].value, "Map\n(\n)\n");
                return;
            }

            Assert.IsTrue(false);
        }

        [TestMethod]
        public void ItemSyntax()
        {
            SyntaxTreeNode temp = testAnalyser.AnalyzeSyntax("==BG==\nMap\n(\n)\n==ITEMS==\nItem\n(\nName=\"Blah\"\nItem\n(\nName=\"Blah2\"\nItem\n(\nName=\"Blah3\"\nPos=45,32\n)\n)\n)\nItem\n(\nName=\"Blah4\"\nPos=4,5\n)\n");

            if (temp != null)
            {
                Assert.AreEqual(temp.GetChildren()[1].GetChildren()[0].value, "Item\n(\nName=\"Blah\"\nPos=45,32\n)\n");
                Assert.AreEqual(temp.GetChildren()[1].GetChildren()[0].GetChildren()[0].value, "Name=\"Blah\"\n");
                Assert.AreEqual(temp.GetChildren()[1].GetChildren()[0].GetChildren()[1].value, "Pos=45,32\n");
                return;
            }

            Assert.IsTrue(false);
        }



    }
}
