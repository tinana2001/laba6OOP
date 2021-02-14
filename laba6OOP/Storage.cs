using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6OOP
{
    class Storage
    {
        public Shape[] _values;
        int size;
        int count = 0;

        public Storage(int size)
        {
            this.size = size;
            _values = new Shape[size];
        }


        public int getCount()
        {
            return count;
        }

        public Shape getObj(int i)
        {
            if (i < count) return _values[i];
            return null;
        }


        public void DeleteItem(int index)
        {
            if (size > 0)
            {
                if (index <= size)
                {
                    for (int i = index; i < count; i++)
                    {
                        _values[i] = _values[i + 1];
                    }
                    count--;
                    Array.Clear(_values, count, 1);

                }
            }

        }
        private bool CheckFree() // проверка свободных мест
        {
            if (count < size)
            {
                return true;
            }
            return false;
        }


        public void AddElem()
        {
            Shape[] _bufer = new Shape[size * 2 + 1];
            for (int i = 0; i < size; i++)
            {
                _bufer[i] = _values[i];
            }
            _values = _bufer;
            size = size * 2;
        }
        public void CreatItem(Shape item)
        {
            if (!CheckFree())
            {
                AddElem();
            }
            _values[count] = item;
            count++;
        }
    }
}
