namespace DataStructures
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Data { get; set; }

        public Node(int data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
    }

    public class BinarySearchTree
    {
        private Node _root { get; set; }

        public BinarySearchTree()
        {
            this._root = null;
        }

        public void Insert(int data)
        {
            if (_root == null)
            {
                _root = new Node(data);
                return;
            }
            else
            {
                Insert(_root, new Node(data));
            }
        }

        private void Insert(Node root, Node newNode)
        {
            if (root == null)
            {
                root = newNode;
            }
            if (newNode.Data < root.Data)
            {
                if (root.Left == null)
                {
                    root.Left = newNode;
                }
                else
                {
                    Insert(root.Left, newNode);
                }
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = newNode;
                }
                else
                {
                    Insert(root.Right, newNode);
                }
            }
        }

        public Node Search(int data)
        {
            return Search(_root, data);
        }

        private Node Search(Node root, int data)
        {
            if (root == null || root.Data == data)
            {
                return root;
            }
            if (root.Data < data)
            {
                return Search(root.Right, data);
            }
            else
            {
                return Search(root.Left, data);
            }
        }

        public void BFT()
        {
            Node current;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(this._root);
            int qSize = 1;
            while (qSize > 0)
            {
                current = q.Dequeue();
                qSize--;
                Console.Write($"{current.Data}, ");
                if (current.Left != null)
                {
                    q.Enqueue(current.Left);
                    qSize++;
                }
                if (current.Right != null)
                {
                    q.Enqueue(current.Right);
                    qSize++;
                }
            }
        }
    }
}