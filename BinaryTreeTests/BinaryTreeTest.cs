using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree;

namespace BinaryTreeTest
{
    [TestClass]
    public class TestBinaryTree
    {
        [TestMethod]
        public void CanCreateTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            Assert.IsNotNull(tree);
        }

        [TestMethod]
        public void RootIsNull()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            Assert.IsNull(tree.Root);
        }

        [TestMethod]
        public void SetRoot()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int>(1);
            Assert.AreEqual(tree.Root.Value, 1);
        }

        [TestMethod]
        public void AddNodesToTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int>(1);
            tree.Root.Left = new BinaryTreeNode<int>(2);
            tree.Root.Right = new BinaryTreeNode<int>(3);
            tree.Root.Left.Left = new BinaryTreeNode<int>(4);
            tree.Root.Left.Right = new BinaryTreeNode<int>(5);
            BinaryTreeNode<int>[] expected = { tree.Root.Left, tree.Root.Right };
            BinaryTreeNode<int>[] expected2 = { tree.Root.Left.Left, tree.Root.Left.Right };
            CollectionAssert.AreEqual(expected, tree.Root.Children);
            CollectionAssert.AreEqual(expected2, tree.Root.Left.Children);
        }

        [TestMethod]
        public void GetSizeOfEmptyTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            Assert.AreEqual(0, tree.Size());
        }

        [TestMethod]
        public void GetSizeOfTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int>(1);
            tree.Root.Left = new BinaryTreeNode<int>(2);
            tree.Root.Right = new BinaryTreeNode<int>(3);
            tree.Root.Left.Left = new BinaryTreeNode<int>(4);
            tree.Root.Left.Right = new BinaryTreeNode<int>(5);
            Assert.AreEqual(5, tree.Size());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void BreadthFirstOnEmptyTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.BreadthFirstSearch(0);
        }

        [TestMethod]
        public void BreadthFirstFind()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int>(1);
            tree.Root.Left = new BinaryTreeNode<int>(2);
            tree.Root.Right = new BinaryTreeNode<int>(3);
            tree.Root.Left.Left = new BinaryTreeNode<int>(4);
            tree.Root.Left.Right = new BinaryTreeNode<int>(5);
            int expected = 3;
            Assert.AreEqual(expected, tree.BreadthFirstSearch(3));
        }

        [TestMethod]
        public void BreadthFirstFindBiggerTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int>(1);
            tree.Root.Left = new BinaryTreeNode<int>(2);
            tree.Root.Right = new BinaryTreeNode<int>(3);
            tree.Root.Left.Left = new BinaryTreeNode<int>(4);
            tree.Root.Left.Right = new BinaryTreeNode<int>(5);
            tree.Root.Left.Left.Left = new BinaryTreeNode<int>(6);
            tree.Root.Left.Left.Right = new BinaryTreeNode<int>(7);
            tree.Root.Left.Right.Left = new BinaryTreeNode<int>(8);
            tree.Root.Left.Right.Right = new BinaryTreeNode<int>(9);
            int expected = 9;
            Assert.AreEqual(expected, tree.BreadthFirstSearch(9));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BreadthFirstElementDoesNotExist()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int>(1);
            tree.Root.Left = new BinaryTreeNode<int>(2);
            tree.Root.Right = new BinaryTreeNode<int>(3);
            tree.Root.Left.Left = new BinaryTreeNode<int>(4);
            tree.Root.Left.Right = new BinaryTreeNode<int>(5);
            tree.BreadthFirstSearch(8);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DepththFirstOnEmptyTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.DepthFirstSearch(0);
        }

        [TestMethod]
        public void DepthFirstFind()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int>(1);
            tree.Root.Left = new BinaryTreeNode<int>(2);
            tree.Root.Right = new BinaryTreeNode<int>(3);
            tree.Root.Left.Left = new BinaryTreeNode<int>(4);
            tree.Root.Left.Right = new BinaryTreeNode<int>(5);
            int expected = 5;
            Assert.AreEqual(expected, tree.DepthFirstSearch(3));
        }

        [TestMethod]
        public void DepthFirstFindBiggerTree()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int>(1);
            tree.Root.Left = new BinaryTreeNode<int>(2);
            tree.Root.Right = new BinaryTreeNode<int>(3);
            tree.Root.Left.Left = new BinaryTreeNode<int>(4);
            tree.Root.Left.Right = new BinaryTreeNode<int>(5);
            tree.Root.Left.Left.Left = new BinaryTreeNode<int>(6);
            tree.Root.Left.Left.Right = new BinaryTreeNode<int>(7);
            tree.Root.Left.Right.Left = new BinaryTreeNode<int>(8);
            tree.Root.Left.Right.Right = new BinaryTreeNode<int>(9);
            int expected = 6;
            Assert.AreEqual(expected, tree.DepthFirstSearch(5));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DepthFirstElementDoesNotExist()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Root = new BinaryTreeNode<int>(1);
            tree.Root.Left = new BinaryTreeNode<int>(2);
            tree.Root.Right = new BinaryTreeNode<int>(3);
            tree.Root.Left.Left = new BinaryTreeNode<int>(4);
            tree.Root.Left.Right = new BinaryTreeNode<int>(5);
            tree.DepthFirstSearch(8);
        }
    }
}
