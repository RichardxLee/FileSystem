using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class CommandProcessor
    {
        // variable
        Node root, current;
        // constructor
        public CommandProcessor()
        {
            root = new Node("root");
            current = root;
        }

        public void Process(string command)
        {
            Console.Write("Command: " + command + "\r\n");
            string sub_command = command.Substring(0,2);

            if (sub_command == "di") // dir
            {
                string path = current.Name;
                Node tmp = current;
                while (tmp.parent != null)
                {
                    tmp = tmp.parent;
                    path = System.IO.Path.Combine(tmp.Name, path);
                }
                Console.Write("Directory of " + path + ":\r\n");

                if (current.Children.Count == 0)
                {
                    Console.Write("No subdirectories\r\n");
                }
                else
                {
                    for (int i = 0; i < current.Children.Count; i++)
                    {
                        Console.Write(current.Children[i].Name + " ");
                    }
                    Console.WriteLine();
                }
            }
            else if (sub_command == "up") // up
            {
                if (current == root)
                {
                    Console.Write("Cannot move up from root directory\r\n");
                }
                else
                {
                    current = current.parent;
                }
            }
            else if (sub_command == "mk") // mkdir
            {
                // separate by space
                string[] element = command.Split(null);
                string foldername = element[1];

                // check if name exist
                bool exist = false;
                if (current.Children.Count != 0)
                {
                    for (int i = 0; i < current.Children.Count; i++)
                    {
                        if (current.Children[i].Name == foldername)
                        {
                            Console.Write("Subdirectory already exists\r\n");
                            exist = true;
                        }
                    }
                }

                // make folder and add to tree
                if (!exist)
                {
                    Node newnode = new Node(foldername);
                    newnode.parent = current;
                    current.Children.Add(newnode);
                }
                
            }
            else if (sub_command == "cd") // cd
            {
                // separate by space
                string[] element = command.Split(null);
                string foldername_cd = element[1];

                // check if name exist
                bool exist = false;
                if (current.Children.Count != 0)
                {
                    for (int i = 0; i < current.Children.Count; i++)
                    {
                        if (current.Children[i].Name == foldername_cd)
                        {
                            exist = true;
                        }
                    }
                }

                // if exist, go to that directory
                if (exist)
                {
                    current = current.GoToChildrenNode(foldername_cd);
                }
                else
                {
                    Console.Write("Subdirectory does not exist\r\n");
                }
            }
            else if (sub_command == "fi") // find
            {
                
            }
            else // invalid command
            {
                Console.Write("invalid command: " + command + "\r\n");
            }
        }
    }
}
