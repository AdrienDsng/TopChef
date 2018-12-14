using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Serialized
    {
        public string Name { get; private set; }

        public string Data { get; private set; }

        public Serialized(string name, string data)
        {
            Name = name;
            Data = data;
        }

        public static T Deserialize<T>(Serialized serialized) where T : class
        {
            try
            {
                byte[] array = Encoding.ASCII.GetBytes(serialized.Data);

                MemoryStream stream = new MemoryStream(array);

                var sr = new StreamReader(stream);

                var s = new XmlSerializer(typeof(T));

                return s.Deserialize(sr) as T;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Serialized Serialize(object serializable)
        {
            try
            {
                var sw = new StringWriter();

                var s = new XmlSerializer(serializable.GetType());

                s.Serialize(sw, serializable);

                return new Serialized(serializable.GetType().Name, sw.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

