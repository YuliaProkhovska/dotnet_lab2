using System.Collections;

namespace Lab2
{
    internal  class ExtendedDictionary<T, U, V> : IEnumerable<ExtendedDictionaryElement<T, U, V>>
    {
        private  List<ExtendedDictionaryElement<T, U, V>> _list = new List<ExtendedDictionaryElement<T, U, V>>();

        public ExtendedDictionary()
        {
            _list = new List<ExtendedDictionaryElement<T, U, V>>();
        }

        public void Add(T key, U firstValue, V secondValue)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException("An element with the same key already exists in the dictionary");
            }
            _list.Add(new ExtendedDictionaryElement<T, U, V>
            {
                Key = key,
                FirstValue = firstValue,
                SecondValue = secondValue
            });
        }

        public void Remove(T key)
        {
            _list.RemoveAll(element => element.Key.Equals(key));
        }

        public bool ContainsKey(T key) => _list.Exists(element => element.Key.Equals(key));

        public bool ContainsValue(U firstValue, V secondValue) => 
         _list.Exists(element => element.FirstValue.Equals(firstValue) && element.SecondValue.Equals(secondValue));
        
        public int Count => _list.Count;

        public ExtendedDictionaryElement<T, U, V> this[T key]
        {
            get => _list.Find(element => element.Key.Equals(key));
            set => _list[_list.FindIndex(element => element.Key.Equals(key))] = value;
        }

        public ExtendedDictionaryElement<T, U, V> this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }
        
        public IEnumerator<ExtendedDictionaryElement<T, U, V>> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public class ExtendedDictionaryElement<T, U, V>
    {
        public  T Key { get; set; }
        public  U FirstValue { get; set; }
        public  V SecondValue { get; set; }
    }


}
