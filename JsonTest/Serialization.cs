using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;




namespace JsonTest
{
  /*  class Serialization
    {

        /// <summary>
        /// 序列化类型
        /// </summary>
        public enum SerializeType
        {
            Binary,
            Json,
            Xml
        }


        /// <summary>
        /// 对象反序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="aSerializeData">序列化字节数组</param>
        /// <param name="aType">序列化方式</param>
        /// <returns></returns>
        public static T Deserialize<T>(byte[] aSerializeData, SerializeType aType)
        {
            T obj = default(T); ;
            if (aSerializeData != null && aSerializeData.Length > 0)
            {
                MemoryStream stream = new MemoryStream(aSerializeData);
                switch (aType)
                {
                    case SerializeType.Binary:
                        BinaryFormatter bf = new BinaryFormatter();
                        obj = (T)bf.Deserialize(stream);
                        break;
                    case SerializeType.Json:
                        DataContractJsonSerializer djs = new DataContractJsonSerializer(typeof(T));
                        obj = (T)djs.ReadObject(stream);
                        break;
                    case SerializeType.Xml:
                        XmlSerializer xs = new XmlSerializer(typeof(T));
                        obj = (T)xs.Deserialize(stream);
                        break;
                }
                stream.Close();
            }
            return obj;
        }


        /// <summary>
        /// 对象序列化
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="aData">需要序列化的对象</param>
        /// <param name="aType">序列化方式</param>
        /// <returns></returns>
        public static byte[] Serialize<T>(T aData, SerializeType aType)
        {
            MemoryStream stream = new MemoryStream();
            switch (aType)
            {
                case SerializeType.Binary:
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, aData);
                    break;
                case SerializeType.Json:
                    DataContractJsonSerializer djs = new DataContractJsonSerializer(typeof(T));
                    djs.WriteObject(stream, aData);
                    break;
                case SerializeType.Xml:
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(stream, aData);
                    break;
            }
            byte[] data = stream.ToArray();
            stream.Close();
            return data;
        }
    }
    */

    }

