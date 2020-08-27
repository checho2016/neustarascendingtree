using System;
using System.Collections.Generic;

namespace NeustarAscendingTree
{
    public class Node
    {
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public int Weight { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Node();
            tree.Weight = 2;
            tree.LeftChild = new Node();
            tree.LeftChild.Weight = 4;
            tree.RightChild = new Node();
            tree.RightChild.Weight = 3;            
            Console.WriteLine("Weight order: " + string.Join(",", GetOrderedWeights(tree)));
            Console.ReadLine();
        }

        private static List<int> GetOrderedWeights(Node tree)
        {
            var result = new List<int>();
            var leftWeights = new List<int>();
            var rightWeights = new List<int>();

            if (tree.LeftChild != null)
            {
                leftWeights = GetOrderedWeights(tree.LeftChild);
            }

            if(tree.RightChild != null)
            {
                rightWeights = GetOrderedWeights(tree.RightChild);
            }
            result.Add(tree.Weight);
            result.AddRange(leftWeights);
            result.AddRange(rightWeights);
            //Here I usually use result.Sort() but since in the general instructions was requested to avoid built in functions I am doing the sorting manually
            result = SortList(result);
            return result;
        }

        private static List<int> SortList(List<int> unsortedList)
        {
            int t;
            for (int p = 0; p <= unsortedList.Count - 2; p++)
            {
                for (int i = 0; i <= unsortedList.Count - 2; i++)
                {
                    if (unsortedList[i] > unsortedList[i + 1])
                    {
                        t = unsortedList[i + 1];
                        unsortedList[i + 1] = unsortedList[i];
                        unsortedList[i] = t;
                    }
                }
            }
            return unsortedList;
        }
    }
}
