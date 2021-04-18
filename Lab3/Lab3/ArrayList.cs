using System;
using System.Linq;

namespace Lab3
{
    public class ArrayList
    {
        private int[] _array;
        private int _last;

        public int Size => _last + 1;

        public ArrayList(int capacity = 5)
        {
            _array = new int[capacity];
            _last = -1;
        }

        public void AddItem(int item)
        {
            if (_last + 1 >= _array.Length)
            {
                int[] newArray = new int[_array.Length + 10];
                
                for (int i = 0; i < _array.Length; i++)
                {
                    newArray[i] = _array[i];
                }

                _array = newArray;
            }
            
            _array[_last + 1] = item;
            _last++;
        }

        public void Print()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.Write($"{_array[i]} ");
            }
            
            Console.WriteLine();
        }

        public bool Search(int item)
        {
            for (int i = 0; i < Size; i++)
            {
                if (_array[i] == item)
                    return true;
            }

            return false;
        }

        public void Delete(int item)
        {
            if (Search(item))
            {
                for (int i = 0; i < Size; i++)
                {
                    if (_array[i] == item)
                    {
                        for (int j = i + 1; j < Size; j++)
                            _array[j - 1] = _array[j];
                        
                        break;
                    }
                }
                
                _last--;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void DeleteAt(int index)
        {
            if (index >= 0 && index < Size)
            {
                for (int i = index + 1; i < Size; i++)
                    _array[i - 1] = _array[i];

                _last--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}