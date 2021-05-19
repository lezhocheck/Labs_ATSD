namespace Lab5
{
    public class UnsortedArrayList
    {
        private const int InitCapacity = 10;
        private int[] _array;
        private int _size;

        public int Count => _size;

        public UnsortedArrayList()
        {
            _array = new int[InitCapacity];
            _size = 0;
        }

        public UnsortedArrayList(int capacity)
        {
            _array = new int[capacity];
            _size = 0;
        }
    }
}