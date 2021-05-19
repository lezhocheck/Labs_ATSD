using System;

namespace Tut1_ATSD
{
    public class LinkedList<T> where T : IComparable
    {
        private T[] array;
        private int capacity;
        private int last;
        
        public int Last => last;
        public int Capacity => capacity;
        
        public LinkedList()
        {
            capacity = 100;
            array = new T[capacity];
            last = 0;
        }

        public LinkedList(int size)
        {
            capacity = size;
            array = new T[capacity];
            last = 0;
        }

        public void AddItem(T item)
        {
            if (last < capacity)
            {
                if (last == 0)
                {
                    array[0] = item;
                    last++;
                    return;
                }
                
                for (int i = 0; i < last; i++)
                {
                    if (array[i].CompareTo(item) > 0)
                    {
                        for (int j = last; j > i; j--)
                        {
                            array[j] = array[j - 1];
                        }
                        array[i] = item;
                        last++;
                        return;
                    }

                    if (i == last - 1)
                    {
                        array[last] = item;
                        last++;
                        return;
                    }
                }
            }
            
            throw new ArgumentOutOfRangeException();
        }

        public bool Search(T item)
        {
            for (int i = 0; i < last; i++)
            {
                if (array[i].CompareTo(item) == 0)
                    return true;
            }

            return false;
        }
        
        public void DeleteItem(T item)
        {
            if (Search(item))
            {
                for (int i = 0; i < last; i++)
                {
                    if (array[i].CompareTo(item) == 0)
                    {
                        for (int j = i; j < last - 1; j++)
                        {
                            array[j] = array[j + 1];
                        }
                    }
                }

                last--;
                return;
            }

            throw new ArgumentOutOfRangeException();
        }

        public void Replase(T t, T k)
        {
            if (Search(t))
            {
                for (int i = 0; i < last; i++)
                {
                    if (array[i].CompareTo(t) == 0)
                    {
                        array[i] = k;
                    }
                }
            }
        }

        public void Dublicate(T item, int k)
        {
            if (Search(item) && last + k < capacity)
            {
                for (int i = 0; i < k; i++)
                {
                    AddItem(item);
                }
                return;
            }
            throw new ArgumentOutOfRangeException();
        }
        public void Print()
        {
            for (int i = 0; i < last; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        private LinkedList<T> Copy()
        {
            LinkedList<T> temp = new LinkedList<T>(capacity);
            for (int i = 0; i < last; i++)
            {
                temp.AddItem(array[i]);
            }
            return temp;
        }
        public LinkedList<T> Difference(T[] b)
        {
            LinkedList<T> temp = this.Copy();
            for (int i = 0; i < b.Length; i++)
            {
                if (temp.Search(b[i]))
                {
                    temp.DeleteItem(b[i]);
                }
            }
            return temp;
        }

        private LinkedList<T> DeleteDuplicates()
        {
            LinkedList <T> list = new LinkedList<T>(capacity);
            for (int i = 0; i < last; i++)
            {
                if (!list.Search(array[i]))
                {
                    list.AddItem(array[i]);
                }
            }

            return list;
        }
        public void Union(LinkedList<T> b)
        {
            this.Merge(b);
            LinkedList<T> list = DeleteDuplicates();
            this.array = list.array;
            this.last = list.last;
        }
        public void Intersection(LinkedList<T> b)
        {
            for (int i = 0; i < last; i++)
            {
                if (!b.Search(array[i]))
                {
                    this.DeleteItem(array[i]);
                    i = 0;
                }
            }
        }

        public int SubsequencesSearch()
        {
            int res = 1;
            for (int i = 2; i <= last; i++)
            {
                res *= i;
            }

            return res;
        }
        public LinkedList<T>[] Split(int n)
        {
            if (n > last || last % n != 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            int t = last / n;
            int counter = 0;
            int nowerList = 0;
            LinkedList<T>[] temp = new LinkedList<T>[n];
            for (int i = 0; i < last; i++)
            {
                if (counter < t)
                {
                    if(temp[nowerList] == null) 
                        temp[nowerList] = new LinkedList<T>(capacity);
                    
                    temp[nowerList].AddItem(array[i]);
                }
                else
                {
                    counter = 0;
                    nowerList++;
                    temp[nowerList] = new LinkedList<T>(capacity);
                    temp[nowerList].AddItem(array[i]);
                }
                counter++;
            }
            return temp;
        }

        public bool RecursiveSearch(int item)
        {
            return BinarySearch(0, last - 1, item) != Int32.MinValue;
        }
        private int BinarySearch(int low, int high, int key)
        {
            if (high < low)
                return Int32.MinValue;
            int mid = (low + high) / 2;
            if (key.CompareTo(array[mid]) == 0)
                return mid;
            if (key.CompareTo(array[mid]) > 0)
                return BinarySearch(mid + 1, high, key);
            return BinarySearch(low, mid - 1, key);
        }

        public void Merge(LinkedList<T> b)
        {
            if (last + b.last > capacity)
            {
                throw new ArgumentException("Cannot merge lists.");
            }
            for (int i = 0; i < b.last; i++)
            {
                this.AddItem(b.array[i]);
            }
        }

        public void TrimToSize()
        {
            T[] arr = new T[last];
            capacity = last;
            for (int i = 0; i < last; i++)
            {
                arr[i] = array[i];
            }

            array = arr;
        }
        public void Merge(T[] arr)
        {
            if (last + arr.Length > capacity)
            {
                throw new ArgumentException("Cannot merge lists.");
            }
            for (int i = 0; i < arr.Length; i++)
            {
                this.AddItem(arr[i]);
            }
        }

        public T[] SubList(int s, int f)
        {
            if (s < 0 || f > last || s >= f)
                throw new ArgumentOutOfRangeException();

            LinkedList<T> list = new LinkedList<T>(f - s);
            for (int i = s; i < f; i++)
            {
                list.AddItem(array[i]);
            }

            return list.array;
        }
        
    }
}