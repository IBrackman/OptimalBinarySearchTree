using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptimalBinarySearchTree;

namespace UnitTestOptimalBinarySearchTree
{
    [TestClass]
    public class OptimalBinarySearchTreeTests
    {
        private int N { get; set; }
        private int[] Keys { get; set; }
        private string[] SKeys { get; set; }
        private double[] P { get; set; }
        private double[] Q { get; set; }

        [TestMethod]
        public void TestMethodInt1()
        {
            N = 4;
            Keys = new[] { 1, 2, 3, 4 };
            const double sum = 23.0;
            P = new[] { 6 / sum, 2 / sum, 8 / sum, 7 / sum };
            Q = new[] { 0.0, 0, 0, 0, 0 };

            var tree = new OptimalBinarySearchTree<int>(N, Keys, P, Q);
            tree.BuildTree();


            Assert.AreEqual(3, tree.Root.Value);
            Assert.AreEqual(0, tree.Root.Level);

            Assert.AreEqual(2, tree.Root.Left.Right.Value);
            Assert.AreEqual(2, tree.Root.Left.Right.Level);
        }

        [TestMethod]
        public void TestMethodStr1()
        {
            N = 4;
            SKeys = new[] { "A", "B", "C", "D" };
            const double sum = 23.0;
            P = new[] { 6 / sum, 2 / sum, 8 / sum, 7 / sum };
            Q = new[] { 0.0, 0, 0, 0, 0 };

            var tree = new OptimalBinarySearchTree<string>(N, SKeys, P, Q);
            tree.BuildTree();


            Assert.AreEqual("C", tree.Root.Value);
            Assert.AreEqual(0, tree.Root.Level);

            Assert.AreEqual("B", tree.Root.Left.Right.Value);
            Assert.AreEqual(2, tree.Root.Left.Right.Level);
        }

        [TestMethod]
        public void TestMethodInt2()
        {
            N = 4;
            Keys = new[] { 1, 2, 3, 4 };
            const double sum = 51.0;
            P = new[] { 6 / sum, 2 / sum, 7 / sum, 8 / sum };
            Q = new[] { 4 / sum, 7 / sum, 5 / sum, 3 / sum, 9 / sum };

            var tree = new OptimalBinarySearchTree<int>(N, Keys, P, Q);
            tree.BuildTree();


            Assert.AreEqual(3, tree.Root.Value);
            Assert.AreEqual(0, tree.Root.Level);

            Assert.AreEqual(2, tree.Root.Left.Right.Value);
            Assert.AreEqual(2, tree.Root.Left.Right.Level);
        }

        [TestMethod]
        public void TestMethodStr2()
        {
            N = 4;
            SKeys = new[] { "A", "B", "C", "D" };
            const double sum = 51.0;
            P = new[] { 6 / sum, 2 / sum, 7 / sum, 8 / sum };
            Q = new[] { 4 / sum, 7 / sum, 5 / sum, 3 / sum, 9 / sum };

            var tree = new OptimalBinarySearchTree<string>(N, SKeys, P, Q);
            tree.BuildTree();


            Assert.AreEqual("C", tree.Root.Value);
            Assert.AreEqual(0, tree.Root.Level);

            Assert.AreEqual("B", tree.Root.Left.Right.Value);
            Assert.AreEqual(2, tree.Root.Left.Right.Level);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Bad keys[] size")]
        public void TestMethodExc1()
        {
            N = 4;
            Keys = new[] { 1, 2, 3, 4, 5 };
            const double sum = 51.0;
            P = new[] { 6 / sum, 2 / sum, 7 / sum, 8 / sum };
            Q = new[] { 4 / sum, 7 / sum, 5 / sum, 3 / sum, 9 / sum };

            var tree = new OptimalBinarySearchTree<int>(N, Keys, P, Q);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Bad p[] or q[] size")]
        public void TestMethodExc2()
        {
            N = 4;
            Keys = new[] { 1, 2, 3, 4 };
            const double sum = 51.0;
            P = new[] { 6 / sum, 2 / sum, 7 / sum };
            Q = new[] { 4 / sum, 7 / sum, 5 / sum, 3 / sum, 9 / sum };

            var tree = new OptimalBinarySearchTree<int>(N, Keys, P, Q);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Bad p[] or q[] size")]
        public void TestMethodExc3()
        {
            N = 4;
            Keys = new[] { 1, 2, 3, 4 };
            const double sum = 51.0;
            P = new[] { 6 / sum, 2 / sum, 7 / sum, 8 / sum };
            Q = new[] { 4 / sum, 7 / sum, 5 / sum, 3 / sum };

            var tree = new OptimalBinarySearchTree<int>(N, Keys, P, Q);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Sum of p and q not equals 1")]
        public void TestMethodExc4()
        {
            N = 4;
            Keys = new[] { 1, 2, 3, 4 };
            const double sum = 51.0;
            P = new[] { 6 / sum, 2 / sum, 7 / sum, 9 / sum };
            Q = new[] { 4 / sum, 7 / sum, 5 / sum, 3 / sum, 9 / sum };

            var tree = new OptimalBinarySearchTree<int>(N, Keys, P, Q);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Sum of p and q not equals 1")]
        public void TestMethodExc5()
        {
            N = 4;
            Keys = new[] { 1, 2, 3, 4 };
            const double sum = 51.0;
            P = new[] { 6 / sum, 2 / sum, 7 / sum, 8 / sum };
            Q = new[] { 4 / sum, 7 / sum, 5 / sum, 2 / sum, 9 / sum };

            var tree = new OptimalBinarySearchTree<int>(N, Keys, P, Q);
        }

        [TestMethod]
        public void TestMethodPrint()
        {
            N = 4;
            SKeys = new[] { "A", "B", "C", "D" };
            const double sum = 51.0;
            P = new[] { 6 / sum, 2 / sum, 7 / sum, 8 / sum };
            Q = new[] { 4 / sum, 7 / sum, 5 / sum, 3 / sum, 9 / sum };

            var tree = new OptimalBinarySearchTree<string>(N, SKeys, P, Q);
            tree.BuildTree();
            
            tree.PrintTree();
        }
    }
}