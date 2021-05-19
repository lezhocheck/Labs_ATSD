using System;

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
            
            _array[Count] = value;
            Count++;
        }

        public void Delete(int value)
        {
            int index = Search(value);
            
            if (index != -1)
            {
                int[] newArr = new int[_array.Length - 1];
                
                for (int i = 0; i < index; i++)
                {
                    newArr[i] = _array[i];
                }

                for (int i = index + 1; i < Count; i++)
                {
                    newArr[i - 1] = _array[i];
                }

                _array = newArr;
                Count--;
            }
        }
        
        private int Search(int value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Print()
        {
            for(int i = 0; i < Count; i++)
            {
                Console.Write($"{_array[i]} ");
            }
            
            Console.WriteLine();
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