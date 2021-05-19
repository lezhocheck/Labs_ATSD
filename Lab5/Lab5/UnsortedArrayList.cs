namespace Lab5
{
    public class UnsortedArrayList
    {
        private const int InitCapacity = 10;
        private int[] _array;
        
        public int Count { get; private set; }

        public UnsortedArrayList()
        {
            _array = new int[InitCapacity];
            Count = 0;
        }

        public UnsortedArrayList(int capacity)
        {
            _array = new int[capacity];
            Count = 0;
        }

        public void Add(int value)
        {
            if (Count == _array.Length - 1)
            {
                DoubleCapacity();
            }
            
            _array[Count - 1] = value;
            Count++;
        }

        private void DoubleCapacity()
        {
            int cap = _array.Length;
            int[] newArray = new int[cap * 2];

            for(int i = 0; i < Count; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }
    }
}