using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;

namespace UtilLib
{

    public class ArrayUtil
    {
        public static Array cutArrayEnd(Array ar, int length)
        {
            CustomArray ca = (CustomArray)ar.Clone();
            while (ar.Length != length)
            {
                ca.RemoveLast();
            }
            return ca.ToArray();
        }
    }

    public class CustomArray : NameObjectCollectionBase
    {
        public CustomArray() { }
        
        public CustomArray(IDictionary id, bool readOnly)
        {
            foreach (DictionaryEntry de in id)
            {
                this.BaseAdd((string)de.Key, de.Value);
            }
            this.IsReadOnly = readOnly;
        }

        public DictionaryEntry this[int index]
        {
            get
            {
                DictionaryEntry de = new DictionaryEntry(BaseGetKey(index), BaseGet(index));
                return de;
            }
            set
            {
                BaseSet((string)value.Key, value.Value);
            }
        }

        public object this[string key]
        {
            get
            {
                return BaseGet(key);
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

        public Array AllValues
        {
            get
            {
                return BaseGetAllValues();
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

        public DictionaryEntry Pop()
        {
            DictionaryEntry tmp = new DictionaryEntry(BaseGetKey(base.Count - 1), BaseGet(base.Count - 1));
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

        public Array ToArray()
        {
            List<object> tmp = new List<object>();
            foreach (object obj in this)
            {
                tmp.Add(obj);
            }
            return tmp.ToArray();
        }
    }
}
