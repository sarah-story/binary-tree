using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTreeNode<T> where T : IComparable
    {
        private BinaryTreeNode<T> left;
        private BinaryTreeNode<T> right;

        public BinaryTreeNode() : this(default(T), null, null) { }
        public BinaryTreeNode(T data) : this(data, null, null) { }
        public BinaryTreeNode(T data, BinaryTreeNode<T> l, BinaryTreeNode<T> r)
        {
            Value = data;
            Children = new BinaryTreeNode<T>[2];
            Children[0] = l;
            Children[1] = r;
            left = l;
            right = r;
            if (l != null) { Left.Parent = this; }
            if (r != null) { Right.Parent = this; }
            Parent = null;
        }

        public BinaryTreeNode<T> Left
        {
            get { return left; }
            set
            {
                left = value;
                left.Parent = this;
                Children[0] = left;
            }
        }

        public BinaryTreeNode<T> Right
        {
            get { return right; }
            set
            {
                right = value;
                right.Parent = this;
                Children[1] = right;
            }
        }

        public BinaryTreeNode<T> Parent;

        public BinaryTreeNode<T>[] Children;

        public T Value;
    }
}
