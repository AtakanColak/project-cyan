using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace CyanDataTransactions.Classes
{
    public class Tools
    {
        public static IList ReadAllClassesFromFile(string filePath, object type, string filename)
        {
            XmlTextReader reader = new XmlTextReader(filePath);
            Type listType = typeof(List<>).MakeGenericType(type.GetType());
            IList list = (IList)Activator.CreateInstance(listType);

            try
            {
                while (reader.Read())
                {
                    if (reader.Name == type.GetType().Name)
                    {

                        object a = Activator.CreateInstance(type.GetType());
                        foreach (var p in a.GetType().GetProperties())
                        {
                            object attr = reader.GetAttribute(p.Name.ToLower());
                            try
                            {
                                int integerNumbuh = Convert.ToInt32(attr);
                                p.SetValue(a, integerNumbuh);
                            }
                            catch
                            {
                                string stringAttr = attr.ToString();
                                p.SetValue(a, stringAttr);
                            }
                        }
                        list.Add(a);

                    }
                }
            }
            catch (Exception ex)
            {
                if (filePath.Length < 50)
                {
                    list = ReadAllClassesFromFile("../../../CyanDataTransactions/Data/" + filename + ".xml", type, filename);
                }
                else
                {
                    throw ex; 
                }
            }
            reader.Dispose();
            return list;
        }
        public static object FindTypeById(string filePath, object type, int id)
        {
            string path = "../../Data/" + filePath + ".xml";
            IList list = ReadAllClassesFromFile(path, type, filePath);
            object obj = list;
            foreach (var p in type.GetType().GetProperties())
            {
                if (p.Name.ToLower().Equals("id"))
                {
                    foreach (var item in list)
                    {
                        if (Convert.ToInt32(p.GetValue(item)) == id)
                        {
                            obj = item;
                        }
                    }
                }
            }
            return obj;
        }
        public static IList ReturnListOfGivenClassWithCurrentId(string filePath, object classType, out int currentId)
        {
            XmlTextReader reader = new XmlTextReader(filePath);
            Type listType = typeof(List<>).MakeGenericType(classType.GetType());
            IList list = (IList)Activator.CreateInstance(listType);
            currentId = 0;
            try
            {
                while (reader.Read())
                {
                    if (reader.Name == classType.GetType().Name)
                    {

                        object a = Activator.CreateInstance(classType.GetType());
                        foreach (var p in a.GetType().GetProperties())
                        {
                            object attr = reader.GetAttribute(p.Name.ToLower());
                            try
                            {
                                int integerNumbuh = Convert.ToInt32(attr);
                                p.SetValue(a, integerNumbuh);
                            }
                            catch
                            {

                                string stringAttr = attr.ToString();
                                p.SetValue(a, stringAttr);
                            }

                            if (p.Name.ToLower() == "id")
                            {
                                currentId = Convert.ToInt32(attr) + 1;
                            }
                        }
                        list.Add(a);

                    }
                }
            }
            catch
            { }
            reader.Dispose();

            return list;
        }
        public static void AddGivenClass(string filePath, object classType)
        {
            int currentId = 0;
            IList list = ReturnListOfGivenClassWithCurrentId(filePath, classType, out currentId);
            Type type = classType.GetType();
            foreach (var p in type.GetProperties())
            {
                if (p.Name.ToLower().Equals("id"))
                {
                    p.SetValue(classType, currentId);
                }
            }
            list.Add(classType);
            File.Delete(filePath);
            XmlTextWriter writer = new XmlTextWriter(filePath, null);
            writer.WriteStartDocument();
            writer.WriteStartElement(type.Name + "s");
            foreach (object obj in list)
            {
                writer.WriteStartElement(type.Name);
                foreach (var p in type.GetProperties())
                {
                    writer.WriteAttributeString(p.Name.ToLower(), p.GetValue(obj).ToString());
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
        public static void AddGivenClassWithDelete(string filePath, object classType, bool delete)
        {
            int currentId = 0;
            IList list = ReturnListOfGivenClassWithCurrentId(filePath, classType, out currentId);
            Type type = classType.GetType();
            foreach (var p in type.GetProperties())
            {
                if (p.Name.ToLower().Equals("id"))
                {
                    p.SetValue(classType, currentId);
                }
            }
            list.Clear();
            list.Add(classType);
            File.Delete(filePath);
            XmlTextWriter writer = new XmlTextWriter(filePath, null);
            writer.WriteStartDocument();
            writer.WriteStartElement(type.Name + "s");
            foreach (object obj in list)
            {
                writer.WriteStartElement(type.Name);
                foreach (var p in type.GetProperties())
                {
                    writer.WriteAttributeString(p.Name.ToLower(), p.GetValue(obj).ToString());
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }
    }
}
