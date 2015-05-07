using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace Lythen.Common.Tree
{
    public class Tree
    {
        public string IMessage { get; set; }
        public int value;
        public List<Tree> ChildNode = new List<Tree>();
        private string PARENT_NAME;
        private string NODE_NAME;
        private Tree _NEXT;
        private Tree _PREVIOUS;
        public Tree() { }
        public Tree(DataTable dtSource, int begin, string parent_name, string node_name)
        {
            PARENT_NAME = parent_name;
            NODE_NAME = node_name;
            InitTree(dtSource, begin);
        }
        private Tree InitTree(DataTable dtSource, int begin)
        {
            DataRow[] pDr = dtSource.Select(string.Format("{0}={1}", PARENT_NAME, begin));
            if (pDr.Length == 0) return null;
            if (pDr.Length > 1)
            {
                Tree ftree = new Tree();
                ftree.value = begin - 1;
                foreach (DataRow dr in pDr)
                {
                    Tree stree = new Tree();
                    stree.value = (int)dr[NODE_NAME];
                    DataRow[] drs = dtSource.Select(string.Format("{0}={1}", PARENT_NAME, stree.value));
                    foreach (DataRow cdr in drs)
                    {
                        Node(dtSource, stree);
                    }
                    ftree.ChildNode.Add(stree);
                }
                return ftree;
            }
            else
            {
                value = (int)pDr[0][NODE_NAME];
                DataRow[] drs = dtSource.Select(string.Format("{0}={1}", PARENT_NAME, value));
                foreach (DataRow dr in drs)
                {
                    Node(dtSource, this);
                }
                return this;
            }
        }
        public void Node(DataTable dtSource, Tree ftree)
        {
            DataRow[] pDr = dtSource.Select(string.Format("{0}={1}", PARENT_NAME, ftree.value));
            if (pDr.Length == 0)
            {
                return;
            }
            Tree node = new Tree();
            int i = 0;
            foreach (DataRow dr in pDr)
            {
                node = new Tree();
                node.value = (int)dr[NODE_NAME];
                Node(dtSource, node);
                ftree.ChildNode.Add(node);
            }
        }
        public Tree Next
        {
            get { return new Tree(); }
        }
    }
}
