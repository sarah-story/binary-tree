using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree;

namespace BinaryTreeTests
{
    [TestClass]
    public class BinaryTreeNodeTest
    {
        [TestMethod]
        public void CanInstantiateNode()
        {
            BinaryTreeNode<string> node = new BinaryTreeNode<string>();
            Assert.IsNotNull(node);
        }

        [TestMethod]
        public void InstantiatingNodeSetsValue()
        {
            BinaryTreeNode<string> node = new BinaryTreeNode<string>("foo");
            string expected = "foo";
            Assert.AreEqual(expected, node.Value);
        }

        [TestMethod]
        public void NewNodeWithChildrenHasChildren()
        {
            BinaryTreeNode<int> left = new BinaryTreeNode<int>(2);
            BinaryTreeNode<int> right = new BinaryTreeNode<int>(3);
            BinaryTreeNode<int> node = new BinaryTreeNode<int>(1, left, right);
            Assert.AreEqual(node.Left.Value, 2);
            Assert.AreEqual(node.Right.Value, 3);
        }

        [TestMethod]
        public void CanGetChildren()
        {
            BinaryTreeNode<int> left = new BinaryTreeNode<int>(2);
            BinaryTreeNode<int> right = new BinaryTreeNode<int>(3);
            BinaryTreeNode<int> node = new BinaryTreeNode<int>(1, left, right);
            BinaryTreeNode<int>[] expected = new BinaryTreeNode<int>[] { left, right };
            CollectionAssert.AreEqual(node.Children, expected);
        }

        [TestMethod]
        public void CanGetParent()
        {
            BinaryTreeNode<int> left = new BinaryTreeNode<int>(2);
            BinaryTreeNode<int> right = new BinaryTreeNode<int>(3);
            BinaryTreeNode<int> node = new BinaryTreeNode<int>(1, left, right);
            Assert.AreEqual(node.Left.Parent, node);
        }

        [TestMethod]
        public void NewNodeHasParent()
        {
            BinaryTreeNode<int> node = new BinaryTreeNode<int>(1);
            BinaryTreeNode<int> node2 = new BinaryTreeNode<int>(2);
            node.Left = node2;
            Assert.AreEqual(node2.Parent, node);
        }
    }
}
