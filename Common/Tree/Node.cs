using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lythen.Common.Tree
{
    public class Node
    {
        private int weight;           //结点权值
        private List<int> _child;           //孩子结点
        private int parent;           //父结点
        private int _next;
        private int _previous;
        private int _index;
        private string name;
         //构造器
        public Node()
        {
            weight = -1;
            _child = new List<int>();
            parent = -1;
            _next = -1;
            _previous = -1;
        }
        //构造器
        public Node(int w, List<int> c, int p)
        {
            weight = w;
            _child = c;
            parent = p;
            _next = -1;
            _previous = -1;
        }
        //结点权值属性
        public int Weight
        {
            set { weight = value; }
            get { return weight; }
        }
        //右孩子结点属性
        public List<int> Child
        {
            get { return _child; }
            set { _child = value; }
        }
        //父结点属性
        public int Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        //前兄弟结点属性
        public int Next
        {
            get { return _next; }
            set { _next = value; }
        }
        //后兄弟结点属性
        public int Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }
        //索引
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        //名称
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
