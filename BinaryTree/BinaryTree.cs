using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        private BinaryTreeNode<T> root;

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTreeNode<T> Root
        {
            get { return root; }
            set { root = value; }
        }


        public int Size()
        {
            return Size(root);
        }

        private int Size(BinaryTreeNode<T> node)
        {
            if (node == null) { return 0; }
            else
            {
                return Size(node.Left) + Size(node.Right) + 1;
            }
        }

        public int BreadthFirstSearch(T value)
        {
            return BreadthFirstSearch(value, root);
        }

        private int BreadthFirstSearch(T value, BinaryTreeNode<T> node)
        {
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            if (node == null) { throw new NullReferenceException("The tree has no nodes"); }
            int count = 0;
            queue.Enqueue(node);
            while (queue.Count != 0)
            {
                count++;
                BinaryTreeNode<T> current = queue.Dequeue();
                if (current.Value.Equals(value)) { return count; }
                if (current.Left != null) { queue.Enqueue(current.Left); }
                if (current.Right != null) { queue.Enqueue(current.Right); }
            }
            throw new ArgumentException();
        }

        public int DepthFirstSearch(T value)
        {
            return DepthFirstSearch(value, root);
        }

        private int DepthFirstSearch(T value, BinaryTreeNode<T> node)
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            HashSet<BinaryTreeNode<T>> visited = new HashSet<BinaryTreeNode<T>>();
            if (node == null) { throw new NullReferenceException("The tree has no nodes"); }
            int count = 0;
            stack.Push(node);
            while (stack.Count != 0)
            {
                count++;
                BinaryTreeNode<T> current = stack.Pop();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    if (current.Value.Equals(value)) { return count; }
                    if (current.Right != null) { stack.Push(current.Right); }
                    if (current.Left != null) { stack.Push(current.Left); }
                }
            }
            throw new ArgumentException();
        }
    }
}
