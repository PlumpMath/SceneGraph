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
        public void EmptyBGSyntax()
        {
            SyntaxTreeNode temp =  testAnalyser.AnalyzeSyntax("==BG==\n");

            List<SyntaxTreeNode> tree = temp.GetChildren();

            if (tree.Count > 0)
            {
                Assert.AreEqual(tree[0].value, "==BG==\n");
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void EmptyItemSyntax()
        {
            SyntaxTreeNode temp = testAnalyser.AnalyzeSyntax("==BG==\n==ITEM==\n");

            List<SyntaxTreeNode> tree = temp.GetChildren();

            if (tree.Count > 0)
            {
                Assert.AreEqual(tree[1].value, "==ITEM==\n");
            }
            else
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void MapSyntax()
        { 
        
        
        }



    }
}
