using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilLib
{
    public class Cryptography
    {
        #region Encode
        public static string Encode(string m_enc)
        {
            //To64UTF8
            byte[] toEncodeAsBytes =
            Encoding.UTF8.GetBytes(m_enc);
            string returnValue =
            Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string EncodeWC(string m_enc)
        {
            string changed = null;
            char[] m_encar = m_enc.ToCharArray();
            for (int i = 0; i < m_enc.Length; i++)
            {
                char c = m_enc[i];
                if (m_enc[i] % 7 == 0 | m_enc[i] % 3 == 0)
                    m_encar[m_enc.IndexOf(c)] = (char)((int)c - 7 / 3);
            }
            foreach (char c in m_encar)
                changed += c.ToString();
            m_enc = changed;
            //To64UTF8
            byte[] toEncodeAsBytes =
            Encoding.UTF8.GetBytes(m_enc);
            string returnValue =
            Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string EncodeWC(string m_enc, int index)
        {
            string changed = null;
            char[] m_encar = m_enc.ToCharArray();
            for (int i = 0; i < m_enc.Length; i++)
            {
                char c = m_enc[i];
                if (m_enc.IndexOf(c) % index == 0)
                    m_encar[m_enc.IndexOf(c)] = (char)((int)c - index);
            }
            foreach (char c in m_encar)
                changed += c.ToString();
            m_enc = changed;
            //To64UTF8
            byte[] toEncodeAsBytes =
            Encoding.UTF8.GetBytes(m_enc);
            string returnValue =
            Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string EncodeWC(string m_enc, int index1, int index2)
        {
            string changed = null;
            char[] m_encar = m_enc.ToCharArray();
            for (int i = 0; i < m_enc.Length; i++)
            {
                char c = m_enc[i];
                if (m_enc[i] % index1 == 0 | m_enc[i] % index2 == 0)
                    m_encar[m_enc.IndexOf(c)] = (char)((int)c - index1 / index2);
            }
            foreach (char c in m_encar)
                changed += c.ToString();
            m_enc = changed;
            //To64UTF8
            byte[] toEncodeAsBytes =
            Encoding.UTF8.GetBytes(m_enc);
            string returnValue =
            Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        #region Array
        public static string[] EncodeArray(string[] m_enc)
        {
            List<string> temp = new List<string>();
            foreach (string s in m_enc)
            {
                temp.Add(Encode(s));
            }
            return temp.ToArray();
        }

        public static string[] EncodeArrayWC(string[] m_enc)
        {
            List<string> temp = new List<string>();
            foreach (string s in m_enc)
            {
                temp.Add(EncodeWC(s));
            }
            return temp.ToArray();
        }

        public static string[] EncodeArrayWC(string[] m_enc, int index)
        {
            List<string> temp = new List<string>();
            foreach (string s in m_enc)
            {
                temp.Add(EncodeWC(s, index));
            }
            return temp.ToArray();
        }

        public static string[] EncodeArrayWC(string[] m_enc, int index1, int index2)
        {
            List<string> temp = new List<string>();
            foreach (string s in m_enc)
            {
                temp.Add(EncodeWC(s, index1, index2));
            }
            return temp.ToArray();
        }
        #endregion
        #endregion
        #region Decrypt
        public static string Decode(string m_enc)
        {
            //From64
            byte[] encodedDataAsBytes =
            Convert.FromBase64String(m_enc);
            string returnValue =
            Encoding.UTF8.GetString(encodedDataAsBytes);
            return returnValue;
        }

        public static string DecodeWC(string m_enc)
        {
            string changed = null;
            char[] m_encar = m_enc.ToCharArray();
            for (int i = 0; i < m_enc.Length; i++)
            {
                char c = m_enc[i];
                if (m_enc[i] % 7 == 0 | m_enc[i] % 3 == 0)
                    m_encar[m_enc.IndexOf(c)] = (char)((int)c - 7 / 3);
            }
            foreach (char c in m_encar)
                changed += c.ToString();
            m_enc = changed;
            //From64
            byte[] encodedDataAsBytes =
            Convert.FromBase64String(m_enc);
            string returnValue =
            Encoding.UTF8.GetString(encodedDataAsBytes);
            return returnValue;
        }

        public static string DecodeWC(string m_enc, int index)
        {
            string changed = null;
            char[] m_encar = m_enc.ToCharArray();
            for (int i = 0; i < m_enc.Length; i++)
            {
                char c = m_enc[i];
                if (m_enc.IndexOf(c) % index == 0)
                    m_encar[m_enc.IndexOf(c)] = (char)((int)c - index);
            }
            foreach (char c in m_encar)
                changed += c.ToString();
            m_enc = changed;
            //From64
            byte[] encodedDataAsBytes =
            Convert.FromBase64String(m_enc);
            string returnValue =
            Encoding.UTF8.GetString(encodedDataAsBytes);
            return returnValue;
        }

        public static string DecodeWC(string m_enc, int index1, int index2)
        {
            string changed = null;
            char[] m_encar = m_enc.ToCharArray();
            for (int i = 0; i < m_enc.Length; i++)
            {
                char c = m_enc[i];
                if (m_enc[i] % index1 == 0 | m_enc[i] % index2 == 0)
                    m_encar[m_enc.IndexOf(c)] = (char)((int)c - index1 / index2);
            }
            foreach (char c in m_encar)
                changed += c.ToString();
            m_enc = changed;
            //From64
            byte[] encodedDataAsBytes =
            Convert.FromBase64String(m_enc);
            string returnValue =
            Encoding.UTF8.GetString(encodedDataAsBytes);
            return returnValue;
        }
        #region Array
        public static string[] DecodeArray(string[] m_enc)
        {
            List<string> temp = new List<string>();
            foreach (string s in m_enc)
            {
                temp.Add(Decode(s));
            }
            return temp.ToArray();
        }

        public static string[] DecodeArrayWC(string[] m_enc)
        {
            List<string> temp = new List<string>();
            foreach (string s in m_enc)
            {
                temp.Add(DecodeWC(s));
            }
            return temp.ToArray();
        }

        public static string[] DecodeArrayWC(string[] m_enc, int index)
        {
            List<string> temp = new List<string>();
            foreach (string s in m_enc)
            {
                temp.Add(DecodeWC(s, index));
            }
            return temp.ToArray();
        }

        public static string[] DecodeArrayWC(string[] m_enc, int index1, int index2)
        {
            List<string> temp = new List<string>();
            foreach (string s in m_enc)
            {
                temp.Add(DecodeWC(s, index1, index2));
            }
            return temp.ToArray();
        }
        #endregion
        #endregion
    }
}
