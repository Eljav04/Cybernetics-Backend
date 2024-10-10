using System.Collections;
using MyColection.Generic.Exceptions;

namespace MyColection.Generic
{
    public class MyList<T> : IEnumerable<T>
    {
        public MyList()
        {
            _myArray = new T[0];
            Count = 0;
        }

        // Creating ordinary array for base
        private T[] _myArray;
        private const int _default_capacity = 4;

        // Count and Capacity properties
        // Capaciry actually equal Length of base array
        public int Count { get; private set; }
        public int Capacity { get { return _myArray.Length; } }

        // Ability to get any item in list by index
        public T this[int index] { get {
                return _myArray[index];
            } }

        // Ability to enumerete array
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _myArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _myArray.GetEnumerator();

        }

        // Addiotnal private functionality

        private void _resize(int requireCount)
        {
            Array.Resize<T>(ref _myArray, requireCount);
        }

        // Default resize funct - increase capacity +4
        private void _resize()
        {
            Array.Resize<T>(ref _myArray, Capacity + _default_capacity);
        }
        //

        private long _long_sum()
        {
            long long_sum_result = 0;
            for (int i = 0; i < Count; i++)
            {
                long_sum_result += Convert.ToInt64(_myArray[i]);
            }
            return long_sum_result;
        }

        private decimal _decimal_sum() {
            decimal decimal_sum_result = 0m;
            for (int i = 0; i < Count; i++)
            {
                decimal_sum_result += Convert.ToDecimal(_myArray[i]);
            }
            return decimal_sum_result;
        }

        private void _shift_items(int index, int shift_count)
        {
            if (index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            // Resize array base on remaining space and count for shift element 
            decimal able_space = Capacity - Count;
            if (shift_count > able_space)
            {
                decimal resize_repetings = (shift_count - able_space) / 4;
                decimal resize_quantity = Math.Ceiling(resize_repetings) * _default_capacity;
                _resize(Convert.ToInt32(Capacity + resize_quantity));
            }

            for (int i = Count - 1; i >= index; i--)
            {
                _myArray[i + shift_count] = _myArray[i];
            }

            Count += shift_count;
        }

        private void _shift_items_reverse(int index, int shift_count)
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if ((index + shift_count) > Count)
            {
                throw new ArgumentOutOfRangeException();
            }


            for (int i = index; i < Count - 1; i++)
            {
                _myArray[i] = _myArray[i + shift_count];
            }

            Count -= shift_count;
        }

        private bool _is_numeric()
        {
            switch (typeof(T).ToString())
            {
                case "System.Int16":
                    return true;
                case "System.Int32":
                    return true;
                case "System.Int64":
                    return true;
                case "System.Decimal":
                    return true;
                case "System.Single":
                    return true;
                case "System.Double":
                    return true;

                default:
                    return false;
            };
        }

        // Quick Sort function
        private void _quick_sort(T[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = _split(array, start, end);

            _quick_sort(array, start, pivot - 1);
            _quick_sort(array, pivot + 1, end);
        }
        private int _split(T[] array, int start, int end)
        {
            int i = start - 1;
            decimal pivot = Convert.ToDecimal(array[end]);

            for (int j = start; j < end; j++)
            {

                if (Convert.ToDecimal(array[j]) < pivot)
                {
                    i++;
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }

            i++;
            (array[i], array[end]) = (array[end], array[i]);

            return i;
        }
        //

        public static void ShowItems(MyList<T> list)
        {
            Console.Write("[");
            for (int i = 0; i < list.Count; i++)
            {
                if (i != list.Count - 1)
                {
                    Console.Write(list[i] + ", ");
                }
                else
                {
                    Console.Write(list[i]);
                }
            }
            Console.Write("]");
        }



    
        // Main functionalty //

        public void Add(T new_item)
        {
            if (Count.Equals(Capacity))
            {
                _resize();
            }
            _myArray[Count++] = new_item;
        }

        public void AddRange(MyList<T> insert_list)
        {
            foreach (T item in insert_list)
            {
                Add(item);
            }
        }

        public void Insert(int insert_index, T new_item)
        {
            _shift_items(insert_index, 1);
            _myArray[insert_index] = new_item;
        }

        public void InsertRange(int insert_index, MyList<T> insert_list)
        {
            _shift_items(insert_index, insert_list.Count);
            for (int i = 0; i < insert_list.Count; i++)
            {
                _myArray[insert_index + i] = insert_list[i];
            }
        }

        public void TrimExcess()
        {
            if (!(Count <= _default_capacity))
            {
                _resize(Count);
            }
            else
            {
                _resize(_default_capacity);
            }
        }

        public decimal Sum()
        {
            if (Count < 1)
            {
                throw new NotEnoughElements("Your list is empty. Find sum of items is impossible!");
            }

            switch (typeof(T).ToString())
            {
                case "System.Int16":
                    return _long_sum();
                case "System.Int32":
                    return _long_sum();
                case "System.Int64":
                    return _long_sum();
                case "System.Decimal":
                    return _decimal_sum();
                case "System.Single":
                    return _decimal_sum();
                case "System.Double":
                    return _decimal_sum();

                default:
                    throw new NaNSumExpception();
            };
        }

        public decimal Max()
        {
            if (Count < 1)
            {
                throw new NotEnoughElements("Your list is empty. Find max item is impossible!");
            }

            if (!_is_numeric())
            {
                throw new NaNSumExpception();
            }

            decimal max_element = Convert.ToDecimal(_myArray[0]);
            for (int i = 1; i < Count; i++)
            {
                decimal current_elment = Convert.ToDecimal(_myArray[i]);
                if (current_elment > max_element)
                {
                    max_element = current_elment;
                }
            }
            return max_element;
        }

        public decimal MaxLessThan(T compare_item)
        {
            if (Count < 1)
            {
                throw new NotEnoughElements("Your list is empty. Find max item is impossible!");
            }

            if (!_is_numeric())
            {
                throw new NaNSumExpception();
            }

            decimal max_element = Min();
            decimal _compare_item = Convert.ToDecimal(compare_item);

            if (max_element > _compare_item)
            {
                throw new MaxElementException("Your list must have at least one element, which less than compare elment!");
            }
           
            for (int i = 1; i < Count; i++)
            {
                decimal current_elment = Convert.ToDecimal(_myArray[i]);
                if (current_elment > max_element)
                {
                    if (current_elment < _compare_item)
                    {
                        max_element = current_elment;
                    }
                }
            }
            return max_element;
        }

        public decimal Min()
        {
            if (Count < 1)
            {
                throw new NotEnoughElements("Your list is empty. Find min item is impossible!");
            }

            if (!_is_numeric())
            {
                throw new NaNSumExpception();
            }

            decimal min_element = Convert.ToDecimal(_myArray[0]);
            for (int i = 1; i < Count; i++)
            {
                decimal current_elment = Convert.ToDecimal(_myArray[i]);
                if (current_elment < min_element)
                {
                    min_element = current_elment;
                }
            }
            return min_element;
        }

        public decimal MinGreaterThan(T compare_item)
        {
            if (Count < 1)
            {
                throw new NotEnoughElements("Your list is empty. Find min item is impossible!");
            }

            if (!_is_numeric())
            {
                throw new NaNSumExpception();
            }

            decimal min_element = Max();
            decimal _compare_item = Convert.ToDecimal(compare_item);

            if (min_element < _compare_item)
            {
                throw new MinElementException("Your list must have at least one element, which greater than compare elment!");
            }

            for (int i = 1; i < Count; i++)
            {
                decimal current_elment = Convert.ToDecimal(_myArray[i]);
                if (current_elment < min_element)
                {
                    if (current_elment > _compare_item)
                    {
                        min_element = current_elment;
                    }
                }
            }
            return min_element;
        }

        public void Reverse()
        {
            // Switch two opposite item in array
            int iterat_count = Count / 2;
            for (int i = 0; i < iterat_count; i++)
            {
                (_myArray[i], _myArray[Count - 1 - i]) =
                    (_myArray[Count - 1 - i], _myArray[i]);
            }
        }

        public void RemoveAt(int element_index)
        {
            _shift_items_reverse(element_index, 1);
        }

        public bool Remove(T remove_element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_myArray[i].Equals(remove_element))
                {
                    _shift_items_reverse(i, 1);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveAll(T remove_element)
        {
            bool ifFinded = false;
            MyList<int> indexes_forRemove = new();
            for (int i = 0; i < Count; i++)
            {
                if (_myArray[i].Equals(remove_element))
                {
                    indexes_forRemove.Add(i);
                    ifFinded = true;
                }
            }

            indexes_forRemove.Reverse();
            foreach (int iForRem in indexes_forRemove)
            {
                _shift_items_reverse(iForRem, 1);
            }

            if (ifFinded)
            {
                return true;
            }
            return false;
        }

        public void Clear()
        {
            _myArray = new T[Capacity];
            Count = 0;
        }

        public void Sort()
        {
            if (_is_numeric())
            {
                _quick_sort(_myArray, 0, Count - 1);
            }
            else
            {
                throw new NaNSumExpception();
            }
            
        }

        public bool Contains(T require_item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_myArray[i].Equals(require_item))
                {
                    return true;
                }
            }
            return false;
        }

        public int FindIndex(T require_item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_myArray[i].Equals(require_item))
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindLastIndex(T require_item)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                if (_myArray[i].Equals(require_item))
                {
                    return i;
                }
            }
            return -1;
        }

        public List<T> ToList()
        {
            List<T> output_list = new();
            foreach (T item in this)
            {
                output_list.Add(item);
            }
            return output_list;
        }


    }
}
