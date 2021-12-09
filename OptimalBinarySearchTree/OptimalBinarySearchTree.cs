using System.Diagnostics;
using System.Drawing;
using QuickGraph;
using QuickGraph.Graphviz;

namespace OptimalBinarySearchTree
{
    public class OptimalBinarySearchTree<T>
    {
        public Node<T>[] Tree { get; set; }
        public Node<T> Root { get; set; }
        private Matrix<T> Matrix { get; }

        public OptimalBinarySearchTree(int n, T[] keys, double[] p, double[] q)
        {
            Tree = new Node<T>[n];
            Root = new Node<T>();
            Matrix = new Matrix<T> {N = n};
            Matrix.SetKeys(keys);
            Matrix.SetPq(p, q);
            Matrix.SetGrid();
        }

        public void BuildTree()
        {
            var i = -1;

            Root = RecursiveBuildNode(1, Matrix.N, 0, ref i);
        }

        private Node<T> RecursiveBuildNode(int str, int col, int lvl, ref int i)
        {
            i++;
            var j = i;
            Tree[j] = new Node<T> {Value = Matrix.Grid[str][col].Root, Level = lvl};

            if (str <= Matrix.Keys.IndexOf(Tree[j].Value) - 1)
                Tree[j].Left = RecursiveBuildNode(str, Matrix.Keys.IndexOf(Tree[j].Value) - 1, lvl + 1, ref i);

            if (Matrix.Keys.IndexOf(Tree[j].Value) + 1 <= col)
                Tree[j].Right = RecursiveBuildNode(Matrix.Keys.IndexOf(Tree[j].Value) + 1, col, lvl + 1, ref i);

            return Tree[j];
        }

        public void PrintTree()
        {
            var graph = new AdjacencyGraph<T, Edge<T>>();
            graph.AddVertex(Root.Value);
            PrintSubTree(graph, Root);

            var graphViz =
                new GraphvizAlgorithm<T, Edge<T>>(graph, @".\", QuickGraph.Graphviz.Dot.GraphvizImageType.Png);

            graphViz.FormatVertex += FormatVertex;

            graphViz.FormatEdge += FormatEdge;


            graphViz.Generate(new FileDotEngine(), "tree");

            Process.Start("cmd.exe", "/C " + @"H:\Graphviz\bin\dot.exe -T png tree.dot > tree.png");

            Process.Start("tree.png");
        }

        private static void FormatVertex(object sender, FormatVertexEventArgs<T> e)
        {
            e.VertexFormatter.Label = e.Vertex.ToString();

            e.VertexFormatter.Shape = QuickGraph.Graphviz.Dot.GraphvizVertexShape.Box;

            e.VertexFormatter.StrokeColor = Color.Black;

            e.VertexFormatter.Font = new Font(FontFamily.GenericSansSerif, 12);
        }


        private static void FormatEdge(object sender, FormatEdgeEventArgs<T, Edge<T>> e)
        {
            e.EdgeFormatter.Font = new Font(FontFamily.GenericSansSerif, 8);

            e.EdgeFormatter.StrokeColor = Color.Black;
        }

        private static void PrintSubTree(IMutableVertexAndEdgeSet<T, Edge<T>> graph, Node<T> root)
        {
            if (root.Left != null)
            {
                graph.AddVertex(root.Left.Value);
                graph.AddEdge(new Edge<T>(root.Value, root.Left.Value));
                PrintSubTree(graph, root.Left);
            }

            if (root.Right != null)
            {
                graph.AddVertex(root.Right.Value);
                graph.AddEdge(new Edge<T>(root.Value, root.Right.Value));
                PrintSubTree(graph, root.Right);
            }
        }
    }
}