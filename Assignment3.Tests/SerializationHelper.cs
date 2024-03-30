using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL), new Type[] { typeof(User), typeof(Node) } );
            using (FileStream stream = File.Create(fileName))
            {
                serializer.WriteObject(stream, users);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            try
            {
                using (FileStream fileStream = File.OpenRead(fileName))
                {
                    using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                    {
                        DataContractSerializer serializer = new DataContractSerializer(typeof(SLL), new Type[] { typeof(User), typeof(Node) });
                        return (SLL)serializer.ReadObject(bufferedStream);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Deserialization failed: " + ex.Message);
                return null;
            }
        }

        //// Serialize the SLL object to binary format
        //public static void Serialize(SLL sll, string fileName)
        //{
        //    try
        //    {
        //        using (FileStream stream = File.Create(fileName))
        //        {
        //            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL), new Type[] { typeof(User), typeof(Node) });
        //            serializer.WriteObject(stream, sll);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Serialization failed: " + ex.Message);
        //    }
        //}

        //// Deserialize the SLL object from binary format
        //public static SLL Deserialize(string fileName)
        //{
        //    try
        //    {
        //        using (FileStream stream = File.OpenRead(fileName))
        //        {
        //            DataContractSerializer serializer = new DataContractSerializer(typeof(SLL), new Type[] { typeof(User), typeof(Node) });
        //            return (SLL)serializer.ReadObject(stream);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Deserialization failed: " + ex.Message);
        //        return null;
        //    }
    }
    }

