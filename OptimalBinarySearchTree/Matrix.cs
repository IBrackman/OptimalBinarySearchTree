using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimalBinarySearchTree
{
    public class Matrix<T>
    {
        private const double Tolerance = 0.001;
        public int N { get; set; }
        public List<T> Keys { get; set; }
        public double[] P { get; set; }
        public double[] Q { get; set; }
        public Cell<T>[][] Grid { get; set; }

        public void SetKeys(T[] keys)
        {
            if (keys.Length != N) throw new Exception("Bad keys[] size");
            Keys = new List<T>(N + 1) {default(T)};
            for (var i = 1; i <= N; i++)
                Keys.Add(keys[i - 1]);
        }

        public void SetPq(double[] p, double[] q)
        {
            if (p.Length != N || q.Length != N + 1) throw new Exception("Bad p[] or q[] size");
            if (Math.Abs(p.Sum() + q.Sum() - 1) > Tolerance) throw new Exception("Sum of p and q not equals 1");
            P = new double[N + 1];
            Q = new double[N + 1];
            Q[0] = q[0] < 0 ? throw new Exception("Probability in q less zero") : q[0];

            for (var i = 1; i <= N; i++)
            {
                P[i] = p[i - 1] < 0 ? throw new Exception("Probability in p less zero") : p[i - 1];
                Q[i] = q[i] < 0 ? throw new Exception("Probability in q less zero") : q[i];
            }
        }

        public void SetGrid()
        {
            Grid = new Cell<T>[N + 1][];

            for (var i = 1; i <= N; i++)
            {
                Grid[i] = new Cell<T>[N + 1];
                for (var j = i; j <= N; j++)
                    Grid[i][j] = new Cell<T>();
            }

            for (var j = 0; j < N; j++)
            {
                for (var i = 1; i <= N - j; i++)
                {
                    FindOptimal(i, j);
                }
            }
        }

        private void FindOptimal(int str, int diag)
        {
            Grid[str][str + diag].Root = Keys[str];
            Grid[str][str + diag].WeightedLength = ComputeWeightedLength(str, str + diag, str);
            Grid[str][str + diag].WeightSum = ComputeWeightSum(str, str + diag, str);

            for (var i = str + 1; i <= str + diag; i++)
            {
                if (ComputeWeightedLength(str, str + diag, i) >= Grid[str][str + diag].WeightedLength) continue;
                Grid[str][str + diag].Root = Keys[i];
                Grid[str][str + diag].WeightedLength = ComputeWeightedLength(str, str + diag, i);
                Grid[str][str + diag].WeightSum = ComputeWeightSum(str, str + diag, i);
            }
        }

        private double ComputeWeightedLength(int str, int col, int rootNum)
        {
            var res = 0.0;
            if (rootNum - 1 >= str) res += Grid[str][rootNum - 1].WeightedLength + Grid[str][rootNum - 1].WeightSum;
            else res += Q[rootNum - 1];
            if (rootNum + 1 <= col) res += Grid[rootNum + 1][col].WeightedLength + Grid[rootNum + 1][col].WeightSum;
            else res += Q[rootNum];
            return res;
        }

        private double ComputeWeightSum(int str, int col, int rootNum)
        {
            var res = 0.0;
            if (rootNum - 1 >= str) res += Grid[str][rootNum - 1].WeightSum;
            else res += Q[rootNum - 1];
            if (rootNum + 1 <= col) res += Grid[rootNum + 1][col].WeightSum;
            else res += Q[rootNum];
            res += P[rootNum];
            return res;
        }
    }
}