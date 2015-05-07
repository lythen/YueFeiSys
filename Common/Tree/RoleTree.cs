using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Lythen.Common.Tree
{
    public class RoleTree
    {
        private Node[] data;
        private int leafNum;
        private DataTable _dtSource;
        private string PARENT_NAME;
        private string NODE_NAME;
        private int _begin;
        //索引器
        public Node this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
        //叶子结点数目
        public int LeafNum
        {
            get { return leafNum; }
            set { leafNum = value; }
        }
        //构造器
        public RoleTree(DataTable dtSource, int begin, string parent_name, string node_name)
        {
            _dtSource = dtSource;
            int n = dtSource.Rows.Count + 1;
            data = new Node[n];
            leafNum = n;
            PARENT_NAME = parent_name;
            NODE_NAME = node_name;
            _begin = begin;
        }
        //创建树
        public void Creat()
        {
            data[0] = new Node();
            data[0].Weight = 0;
            DataRow[] drs = _dtSource.Select(string.Format("{0}={1}", PARENT_NAME, _begin));
            int index = 0;
            int i = 0;
            int[] childList = new int[drs.Length];
            foreach (DataRow dr in drs)
            {
                index++;
                data[index] = new Node();
                if (i != 0)
                {
                    data[index].Previous = index - 1;
                    data[index - 1].Next = index;
                }
                data[index].Parent = 0;
                data[index].Weight = (int)dr[NODE_NAME];
                childList[i] = index;
                Recursive(ref index);
                i++;
            }
            data[0].Child = childList;
        }
        void Recursive(ref int index)
        {
            int temp_index = index;
            int begin = data[index].Weight;
            DataRow[] drs = _dtSource.Select(string.Format("{0}={1}", PARENT_NAME, begin));
            int i = 0;
            int[] childList = new int[drs.Length];
            foreach (DataRow dr in drs)
            {
                index++;
                data[index] = new Node();
                if (i != 0)
                {
                    data[index].Previous = index - 1;
                    data[index - 1].Next = index;
                }
                data[index].Parent = temp_index;
                data[index].Weight = (int)dr[NODE_NAME];
                childList[i] = index;
                Recursive(ref index);
                i++;
            }
            data[temp_index].Child = childList;
        }
        public bool isParent(int parent, int child)
        {
            int index = 0;
            foreach (Node node in data)
            {
                if (node.Weight == child)
                    break;
                index++;
            }
            if (data[index].Parent == parent) return true;
            else return RecursiveIsParent(data[index].Parent); 
        }
        bool RecursiveIsParent(int index)
        {
            if (data[index].Parent == -1) return false;
            int temp_parent = data[index].Parent;
            return RecursiveIsParent(temp_parent);
        }
    }
}
