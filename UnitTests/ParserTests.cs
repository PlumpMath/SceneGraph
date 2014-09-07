using System;
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

            Assert.IsTrue(node != null);
        }
    }
}
