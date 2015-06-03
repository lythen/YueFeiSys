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
        private string TITLE;
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
        public RoleTree(DataTable dtSource, string parent_name, string node_name, string title)
        {
            _dtSource = dtSource;
            int n = dtSource.Rows.Count + 1;
            data = new Node[n];
            leafNum = n;
            PARENT_NAME = parent_name;
            NODE_NAME = node_name;
            TITLE = title;
        }
        //创建树
        public void Creat()
        {
            data[0] = new Node();
            data[0].Weight = 0;
            data[0].Index = 0;
            DataRow[] drs = _dtSource.Select(string.Format("{0}={1}", PARENT_NAME, _begin));
            int index = 0;
            int i = 0;
            foreach (DataRow dr in drs)
            {
                index++;
                data[index] = new Node();
                data[index].Index = index;
                if (i != 0)
                {
                    data[index].Previous = index - 1;
                    data[index - 1].Next = index;
                }
                data[index].Parent = 0;
                data[index].Weight = (int)dr[NODE_NAME];
                data[0].Child.Add(index);
                Recursive(ref index);
                i++;
            }
        }
        public Node[] CreateUnknowRootTree()
        {
            data[0] = new Node();
            data[0].Weight = 0;//根节点保留
            data[0].Name = "根结点";
            int index = -1;//索引
            int i = 1;//循环变量
            int parent;
            int this_id;
            bool getParent = false;
            foreach (DataRow dr in _dtSource.Rows)
            {
                index = -1;
                getParent = false;
                parent = (int)dr[PARENT_NAME];//父节点ID
                this_id = (int)dr[NODE_NAME];//自己的ID
                foreach (Node cnode in data)
                {
                    if (cnode != null && cnode.Weight == this_id)
                    {
                        //如果节点已存在，那就是之前构建父节点时构建的，是之前某一节点的父节点
                        index = cnode.Index;
                        cnode.Name = dr[TITLE].ToString();
                        break;
                    }
                }
                if (index == -1)
                {
                    //如果节点不存在
                    index = i;
                    data[index] = new Node();
                    data[index].Weight = this_id;
                    data[index].Index = i;
                    data[index].Name = dr[TITLE].ToString();
                }
                foreach (Node cnode in data)
                {
                    if (cnode.Weight == parent)
                    {
                        getParent = true;
                        data[index].Parent = cnode.Index;
                        cnode.Child.Add(i);
                        //如果父节点存在，要查找父节点的直接子节点，构建兄弟节点
                        foreach (int pnode in cnode.Child)
                        {
                            if (data[pnode].Next == -1)
                            {
                                data[pnode].Next = index;
                                data[index].Previous = data[pnode].Index;
                            }
                        }
                        break;
                    }
                }
                i++;
                if (!getParent)
                {
                    //不存在父节点
                    //看父节点是否在表里，在则加入树，不在则把父节点指向根结点。
                    //新添加的父节点不需要构建兄弟结点，只要子节点只有一个，以根节点为父节点的需要构建其兄弟节点
                    DataRow[] drs = _dtSource.Select(string.Format("{0}={1}", NODE_NAME, parent));
                    if (drs.Length > 0)
                    {
                        data[i] = new Node();
                        data[i].Child.Add(index);
                        data[i].Weight = parent;
                        data[index].Parent = i;
                        i++;
                    }
                    else
                    {
                        data[index].Parent = 0;
                        //构建兄弟节点
                        foreach (int pnode in data[0].Child)
                        {
                            if (data[pnode].Next == -1)
                            {
                                data[pnode].Next = index;
                                data[index].Previous = data[pnode].Index;
                                break;
                            }
                        }
                        data[0].Child.Add(index);
                    }
                }
            }
            return data;
        }
        void Recursive(ref int index)
        {
            int temp_index = index;
            int begin = data[index].Weight;
            DataRow[] drs = _dtSource.Select(string.Format("{0}={1}", PARENT_NAME, begin));
            int i = 0;
            foreach (DataRow dr in drs)
            {
                index++;
                data[index] = new Node();
                data[index].Index = index;
                if (i != 0)
                {
                    data[index].Previous = index - 1;
                    data[index - 1].Next = index;
                }
                data[index].Parent = temp_index;
                data[index].Weight = (int)dr[NODE_NAME];
                data[0].Child.Add(index);
                Recursive(ref index);
                i++;
            }
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
            else return RecursiveIsParent(data[index].Parent,parent);
        }
        bool RecursiveIsParent(int index,int parent)
        {
            if (data[index].Parent == -1) return false;
            int temp_parent = data[index].Parent;
            if (temp_parent == parent) return true;
            else
            return RecursiveIsParent(temp_parent, parent);
        }
    }
}
