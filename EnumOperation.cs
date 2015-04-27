using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace EnumOperation
{
    public static class EnumOperation
    {
        /// <summary>
        /// .Net 3.5 and above
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<T, string>> Of<T>() where T : struct
        {
            return Enum.GetValues(typeof (T))
                .Cast<T>()
                .Select(p => new KeyValuePair<T, string>(p, GetEnumDescripton(p)));
        }


        /// <summary>
        /// .Net 2.0
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<T, string>> Ofv20<T>() where T : struct
        {
            List<KeyValuePair<T,string>> list = new List<KeyValuePair<T, string>>();

            foreach (T item in Enum.GetValues(typeof(T)))
            {
                list.Add(new KeyValuePair<T, string>(item, GetEnumDescripton(item)));
            }

            return list;
        }

        /// <summary>
        /// If enum has DescriptionAttribute return this ToString else return enum.ToString()
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescripton<T>(T value) where T:struct 
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof (DescriptionAttribute));
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
