namespace Lab3
{
    public class ArrayList
    {
        private int[] _array;
        private int _last;

        public ArrayList(int cap = 25)
        {
            _array = new int[cap];
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
    }
}