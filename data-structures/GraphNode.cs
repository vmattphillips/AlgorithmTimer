using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class GraphNode<T> where T : IComparable
    {
        public T Data;
        public List<GraphNode<T>> Edges;

        public GraphNode(T data)
        {
            Data = data;
            Edges = new List<GraphNode<T>>();
        }

        public void AddEdge(GraphNode<T> node)
        {
            if (!Edges.Contains(node))
            {
                Edges.Add(node);
            }
        }

        public void RemoveEdge(GraphNode<T> node)
        {
            if (Edges.Contains(node))
            {
                Edges.Add(node);
            }
        }

        public void RemoveAllEdges()
        {
            foreach (GraphNode<T> g in Edges)
            {
                Edges.Remove(g);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[" + Data + "]");
            foreach (GraphNode<T> g in Edges)
            {
                sb.Append(" -> " + g.Data);
            }
            return sb.ToString();
        }
    }

    public class GraphNode
    {
        List<GraphNode<T>> nodes = new List<GraphNode<T>>();

        public StandardGraph()
        {
            // IN PROGRESS
        }
    }
}