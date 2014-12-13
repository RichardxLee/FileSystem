using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Node
    {
        public string Name;
        public Node parent;
        public List<Node> Children;

        public Node(string _name)
        {
            this.Name = _name;
            Children = new List<Node>();
            parent = null;
        }

        public void AddNode(Node node)
        {
            Children.Add(node);
        }

        public void SetParent(Node node)
        {
            this.parent = node;
        }

        public Node GoToChildrenNode(string name)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                if (Children[i].Name == name)
                {
                    return Children[i];
                }
            }
            return null;
        }
    }
}
