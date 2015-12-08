using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;
using UtilLib;
using System.Collections.ObjectModel;

namespace UtilLib
{
    public class ArrayUtil
    {
        public static Array CutArrayEnd(Array ar, int length)
        {
            var v = ar.GetValue(0);
            CustomArray<object> ca = (CustomArray<object>)ar.Clone();
            while (ar.Length != length)
            {
                ca.RemoveLast();
            }
            return ca.ToArray();
        }

        public enum MergeOption
        {
            Alternately,
            FirstIsFirst,
            SecondIsFirst
        }

        public static Array Merge(Array ar1, Array ar2, MergeOption mrg)
        {
            CustomArray<object> ca = new CustomArray<object>();
            if (mrg == MergeOption.Alternately)
            {
                for (int i = 0; i < Math.Max(ar1.Length, ar2.Length); i++)
                {
                    if (i == 0)
                    {
                        ca.Add(null, ar1.GetValue(0));
                    }
                    else if (i % 2 == 0)
                    {
                        if (!(ar1.Length < i))
                            ca.Add(null, ar1.GetValue(i / 2));
                        else
                            ca.Add(null, ar2.GetValue(i / 2));
                    }
                    else if (i % 2 != 0)
                    {
                        if (!(ar1.Length < i))
                            ca.Add(null, ar2.GetValue((i - 1) / 2));
                        else
                            ca.Add(null, ar2.GetValue((i / 2) / 2));
                    }
                }
            }
            else if (mrg == MergeOption.FirstIsFirst)
            {
                foreach (object o in ar1)
                    ca.Add(null, o);
                foreach (object o in ar2)
                    ca.Add(null, o);
            }
            else if (mrg == MergeOption.SecondIsFirst)
            {
                foreach (object o in ar2)
                    ca.Add(null, o);
                foreach (object o in ar1)
                    ca.Add(null, o);
            }
            return ca.ToArray();
        }

        public static List<T> ReadOnlyToList<T>(ReadOnlyCollection<T> ToCopy)
        {
            List<T> tmp = new List<T>();
            foreach (T item in ToCopy)
                tmp.Add(item);
            return tmp;
        }
    }

    public class CustomArray<T> : NameObjectCollectionBase
    {
        public CustomArray() { }

        public CustomArray(bool readOnly, params CustomArrayObject<T>[] objects)
        {
            foreach (CustomArrayObject<T> cao in objects)
                BaseAdd(cao.Key, cao.Value);
            this.IsReadOnly = readOnly;
        }
        
        public CustomArray(IDictionary id, bool readOnly)
        {
            foreach (DictionaryEntry de in id)
            {
                this.BaseAdd((string)de.Key, de.Value);
            }
            this.IsReadOnly = readOnly;
        }

        public CustomArray(CustomArray<T> ca, bool readOnly)
        {
            foreach (DictionaryEntry de in ca)
            {
                this.BaseAdd((string)de.Key, de.Value);
            }
            this.IsReadOnly = readOnly;
        }

        public CustomArrayObject<T> this[int index]
        {
            get
            {
                CustomArrayObject<T> de = new CustomArrayObject<T>(BaseGetKey(index), (T)BaseGet(index));
                return de;
            }
            set
            {
                BaseSet((string)value.Key, value.Value);
            }
        }

        public T this[string key]
        {
            get
            {
                return (T)BaseGet(key);
            }
            set
            {
                BaseSet(key, value);
            }
        }
        
        public string[] AllKeys
        {
            get
            {
                return BaseGetAllKeys();
            }
        }

        public List<T> AllValues
        {
            get
            {
                List<T> tmp = new List<T>();
                foreach (T val in this)
                    tmp.Add(val);
                return tmp;
            }
        }

        public bool HasKeys
        {
            get
            {
                return BaseHasKeys();
            }
        }

        public void Add(string key, object value)
        {
            BaseAdd(key, value);
        }

        public void Add(DictionaryEntry de)
        {
            BaseAdd((string)de.Key, de.Value);
        }

        public void Add(CustomArrayObject<T> de)
        {
            BaseAdd(de.Key, de.Value);
        }

        public void Remove(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string key)
        {
            BaseRemove(key);
        }

        public void RemoveLast()
        {
            BaseRemoveAt(base.Count - 1);
        }

        public CustomArrayObject<T> Pop()
        {
            CustomArrayObject<T> tmp = new CustomArrayObject<T>(BaseGetKey(base.Count - 1), (T)BaseGet(base.Count - 1));
            BaseRemoveAt(base.Count - 1);
            return tmp;
        }

        public object PopValue()
        {
            object tmp = BaseGet(base.Count - 1);
            BaseRemoveAt(base.Count - 1);
            return tmp;
        }

        public void Clear()
        {
            BaseClear();
        }

        public List<T> ToList()
        {
            List<T> tmp = new List<T>();
            foreach (T obj in this)
            {
                tmp.Add(obj);
            }
            return tmp;
        }

        public Array ToArray()
        {
            List<T> tmp = new List<T>();
            foreach (T obj in this)
            {
                tmp.Add(obj);
            }
            return tmp.ToArray();
        }

        public IDictionary ToIDictionary()
        {
            Dictionary<string, object> tmp = new Dictionary<string, object>();
            foreach (DictionaryEntry de in this)
            {
                tmp.Add(de.Key.ToString(), de.Value);
            }
            return tmp;
        }

        public CustomArray<T> Clone()
        {
            CustomArray<T> tmp = new CustomArray<T>();
            for (int i = 0; i < this.Count; i++)
                tmp.Add(this[i]);
            return tmp;
        }

        public void Reverse()
        {
            Dictionary<string, object> tmp = new Dictionary<string, object>();
            for (int i = base.Count - 1; i >= 0; i--)
                tmp.Add(this[i].Key.ToString(), this[i].Value);
            BaseClear();
            foreach (KeyValuePair<string, object> de in tmp)
                BaseAdd(de.Key.ToString(), de.Value);
        }

        public CustomArray<T> ReverseAndClone()
        {
            CustomArray<T> tmp = (CustomArray<T>)this.MemberwiseClone();
            tmp.Reverse();
            return tmp;
        }
    }

    public class CustomArrayObject<T>
    {
        private string key;
        private T value;
        private bool ReadOnly = false;

        public string Key
        {
            get { return key; }
            set
            {
                if (!ReadOnly)
                    key = value;
            }
        }

        public T Value
        {
            get { return value; }
            set
            {
                if (!ReadOnly)
                    this.value = value;
            }
        }

        public CustomArrayObject() { }

        public CustomArrayObject(string Key, T Value, bool ReadOnly = false)
        {
            key = Key;
            value = Value;
            this.ReadOnly = ReadOnly;
        }
    }
}
