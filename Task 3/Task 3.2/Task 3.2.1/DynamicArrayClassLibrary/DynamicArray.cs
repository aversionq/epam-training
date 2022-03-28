using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrayClassLibrary
{
    public class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {
        private T[] _dynamicArray;

        /// <summary>
        /// Creates a DynamicArray<typeparamref name="T"/> instance
        /// with Capacity = 8.
        /// </summary>
        public DynamicArray()
        {
            _dynamicArray = new T[8];
        }

        /// <summary>
        /// Creates a DynamicArray<typeparamref name="T"/> instance with Capacity = <paramref name="capacity"/>
        /// </summary>
        /// <param name="capacity"></param>
        public DynamicArray(int capacity)
        {
            _dynamicArray = new T[capacity];
        }

        /// <summary>
        /// Creates a DynamicArray<typeparamref name="T"/> instance with <paramref name="collection"/> elements.
        /// </summary>
        /// <param name="collection"></param>
        public DynamicArray(ICollection<T> collection)
        {
            _dynamicArray = new T[collection.Count];
            collection.CopyTo(_dynamicArray, 0);
            Length = collection.Count;
        }

        /// <summary>
        /// Creates a DynamicArray<typeparamref name="T"/> instance with <paramref name="collection"/> elements.
        /// </summary>
        /// <param name="collection"></param>
        public DynamicArray(IEnumerable<T> collection) : this(collection.ToList()) { }

        /// <summary>
        /// Returns amount of elements in DynamicArray<typeparamref name="T"/> instance.
        /// </summary>
        public int Length { get; private set; } = 0;

        /// <summary>
        /// Returns DynamicArray<typeparamref name="T"/> instance Capacity.
        /// </summary>
        public int Capacity
        {
            get => _dynamicArray.Length;

            set
            {
                T[] tempArray = new T[value];

                if (value < Length)
                {
                    for (int i = 0; i < value; i++)
                    {
                        tempArray[i] = _dynamicArray[i];
                    }
                    _dynamicArray = tempArray;
                    Length = value;     // Изменяем длину массива, т.к новое Capacity меньше старой длины массива.
                }
                else
                {
                    _dynamicArray = tempArray;
                }
            }
        }

        /// <summary>
        /// Adds <paramref name="item"/> to an end of DynamicArray<typeparamref name="T"/> instance.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (Length == Capacity)
            {
                ExpandArray();
            }
            _dynamicArray[Length] = item;
            Length++;
        }

        /// <summary>
        /// Adds <paramref name="collection"/> to an end of DynamicArray<typeparamref name="T"/> instance.
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(ICollection<T> collection)
        {
            if (collection.Count > (Capacity - Length))
            {
                ExpandArray(collection.Count);
            }
            collection.CopyTo(_dynamicArray, Length);
            Length += collection.Count;
        }

        /// <summary>
        /// Removes <paramref name="item"/> from DynamicArray<typeparamref name="T"/> instance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>true if <paramref name="item"/> was succesfully removed from DynamicArray<typeparamref name="T"/> instance.</returns>
        public bool Remove(T item)
        {
            if (_dynamicArray.Contains(item))
            {
                int elemIndex = -1;
                for (int i = 0; i < Length; i++)
                {
                    if (_dynamicArray[i].Equals(item))
                    {
                        elemIndex = i;
                        break;
                    }
                }

                for (int i = elemIndex; i <Length; ++i)
                {
                    _dynamicArray[i] = _dynamicArray[i + 1];
                }
                Length--;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Inserts an <paramref name="item"/> at an DynamicArray<typeparamref name="T"/> instance position <paramref name="pos"/>. 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="item"></param>
        /// <returns>true if <paramref name="item"/> was succesfully inserted. 
        /// Throws ArgumentOutOfRangeException if <paramref name="pos"/> parameter is out of available array range. </returns>
        public bool Insert(int pos, T item)
        {
            if (pos >= 0 && pos <= Length)
            {
                if (Length == Capacity)
                {
                    ExpandArray();
                }

                for (int i = Length - 1; i >= pos ; i--)
                {
                    _dynamicArray[i + 1] = _dynamicArray[i];
                }
                _dynamicArray[pos] = item;
                Length++;

                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index is out of range.");
            }
        }

        /// <summary>
        /// Gets/Sets value from/to the DynamicArray<typeparamref name="T"/> according to the requested index.
        /// If the index is negative, element reference counts by 'Length + index'.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>value from DynamicArray<typeparamref name="T"/> instance with requested <paramref name="index"/>
        /// Throws ArgumentOutOfRangeException if requested index is out of DynamicArray<typeparamref name="T"/> instance range.</returns>
        public T this[int index]
        {
            get
            {
                if (index >= -Length && index < Length)
                {
                    if (index >= 0)
                    {
                        return _dynamicArray[index];
                    }
                    else
                    {
                        return _dynamicArray[Length + index];
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }
            }
            set
            {
                if (index >= -Length && index < Length)
                {
                    if (index >= 0)
                    {
                        _dynamicArray[index] = value;
                    }
                    else
                    {
                        _dynamicArray[Length + index] = value;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }
            }
        }

        /// <summary>
        /// Clones DynamicArray<typeparamref name="T"/> instance to a new DynamicArray<typeparamref name="T"/> instance.
        /// </summary>
        /// <returns>new DynamicArray<typeparamref name="T"/> instance with cloned data.</returns>
        public object Clone()
        {
            DynamicArray<T> clonedArray = new DynamicArray<T>(Capacity);
            clonedArray.Length = Length;
            for (int i = 0; i < Length; i++)
            {
                clonedArray[i] = _dynamicArray[i];
            }
            return clonedArray;
        }

        /// <summary>
        /// Converts DynamicArray<typeparamref name="T"/> instance into Array instance.
        /// </summary>
        /// <returns>Array with elements from DynamicArray<typeparamref name="T"/> instance.</returns>
        public T[] ToArray()
        {
            T[] array = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                array[i] = _dynamicArray[i];
            }
            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)GetValuesArray()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetValuesArray().GetEnumerator();
        }

        private void ExpandArray()
        {
            T[] tempArray = new T[Capacity * 2];
            _dynamicArray.CopyTo(tempArray, 0);
            _dynamicArray = tempArray;
        }

        private void ExpandArray(int len)
        {
            T[] tempArray = new T[Capacity + len];
            _dynamicArray.CopyTo(tempArray, 0);
            _dynamicArray = tempArray;
        }

        private T[] GetValuesArray()
        {
            T[] valuesArray = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                valuesArray[i] = _dynamicArray[i];
            }
            return valuesArray;
        }
    }
}
