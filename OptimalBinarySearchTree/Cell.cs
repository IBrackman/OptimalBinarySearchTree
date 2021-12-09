namespace OptimalBinarySearchTree
{
    public class Cell<T>
    {
        public T Root { get; set; }
        public double WeightedLength { get; set; } = double.MaxValue;
        public double WeightSum { get; set; }
    }
}