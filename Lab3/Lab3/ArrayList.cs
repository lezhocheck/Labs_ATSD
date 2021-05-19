using System;
using System.Linq;

namespace Lab3
{
    public class ArrayList
    {
        private int[] _array;
        private int _last;

        public int Size => _last + 1;
        public bool IsEmpty => (Size <= 0);
        
        public enum Order
        {
            Ascending,
            Descending
        }
        public ArrayList(int capacity = 5)
        {
            _array = new int[capacity + 1];
            _last = 0;
        }

        public void AddItem(int item)
        {
            if (_last + 1 >= _array.Length)
            {
                int[] newArray = new int[_array.Length + 10];
                
                for (int i = 1; i < Size; i++)
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
            for (int i = 1; i < Size; i++)
            {
                Console.Write($"{_array[i]} ");
            }
            
            Console.WriteLine();
        }

        public bool Search(int item)
        {
            for (int i = 1; i < Size; i++)
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
                for (int i = 1; i < Size; i++)
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
            if (index >= 0 && index < Size - 1)
            {
                for (int i = index + 2; i < Size; i++)
                    _array[i - 1] = _array[i];

                _last--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        
        private void BuildMaxHeap(int[] array, int root, int last)
        {
            int child = root;
            int unsettled = root;
            
            while(2 * unsettled <= last)	       
            {	
                if(2 * unsettled < last && array[2 * unsettled + 1] > array[2 * unsettled])
                    child = 2*unsettled + 1;	
                else	
                    child = 2*unsettled;		
                
                if(array[unsettled] < array[child])	
                {	
                    Swap(ref array[unsettled], ref array[child]);
                    unsettled = child;
                }
                else break;
            }
        }
        
        private void BuildMinHeap(int[] array, int root, int last)
        {
            int child = root;
            int unsettled = root;
            
            while(2 * unsettled <= last)	       
            {	
                if(2 * unsettled < last && array[2 * unsettled + 1] < array[2 * unsettled])
                    child = 2*unsettled + 1;	
                else	
                    child = 2*unsettled;		
                
                if(array[unsettled] > array[child])	
                {	
                    Swap(ref array[unsettled], ref array[child]);
                    unsettled = child;
                }
                else break;
            }
        }
        
        private void HeapsortRec(int[] array, int n, Order order)
        {
            n--;

            if (order == Order.Ascending)
            {
                for(int i = n/2; i >= 1; i--)		
                    BuildMaxHeap(array, i, n);
            
                for(int end = n-1; end >= 1; end--)	
                {
                    Swap(ref array[1], ref array[end+1]);
                    BuildMaxHeap(array, 1, end);
                }   
            }

            if (order == Order.Descending)
            {
                for(int i = n/2; i >= 1; i--)		
                    BuildMinHeap(array, i, n);
            
                for(int end = n-1; end >= 1; end--)	
                {
                    Swap(ref array[1], ref array[end+1]);
                    BuildMinHeap(array, 1, end);
                }   
            }
        }

        public void HeapSort(Order order) => HeapsortRec(_array, Size, order);
    }
}