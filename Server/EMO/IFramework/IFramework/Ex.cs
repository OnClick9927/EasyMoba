using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IFramework
{
    public static class Ex
    {
        /// <summary>
        /// 是否存在文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool ExistFile(this string path)
        {
            return File.Exists(path);
        }
        /// <summary>
        /// 是否是一个文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsDirectory(this string path)
        {
            FileInfo fi = new FileInfo(path);
            if ((fi.Attributes & FileAttributes.Directory) != 0)
                return true;
            return false;
        }

        /// <summary>
        /// 移除空文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool RemoveEmptyDirectory(this string path)
        {
            if (string.IsNullOrEmpty(path)) throw new Exception("Directory name is invalid.");
            try
            {
                if (!Directory.Exists(path)) return false;
                string[] subDirectoryNames = Directory.GetDirectories(path, "*");
                int subDirectoryCount = subDirectoryNames.Length;
                foreach (string subDirectoryName in subDirectoryNames)
                {
                    if (subDirectoryName.RemoveEmptyDirectory())
                    {
                        subDirectoryCount--;
                    }
                }
                if (subDirectoryCount > 0) return false;
                if (Directory.GetFiles(path, "*").Length > 0) return false;
                Directory.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 拼接路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="toCombinePath"></param>
        /// <returns></returns>
        public static string CombinePath(this string path, string toCombinePath)
        {
            return Path.Combine(path, toCombinePath).ToRegularPath();
        }
        /// <summary>
        /// 拼接路径
        /// </summary>
        /// <param name="path"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string CombinePath(this string path, string[] paths)
        {
            for (int i = 1; i < paths.Length; i++)
            {
                path = path.CombinePath(paths[i]);
            }
            return path.ToRegularPath();
        }

        /// <summary>
        /// 规范路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ToRegularPath(this string path)
        {
            path = path.Replace('\\', '/');
            return path;
        }

        /// <summary>
        /// 如果文件夹不存在则创建
        /// </summary>
        /// <param name="path"></param>
        public static void MakeDirectoryExist(this string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }



        /// <summary>
        /// 获取当前程序集中的类型的子类，3.5有问题
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetSubTypesInAssembly(this Type self)
        {
            if (self.IsInterface)
                return Assembly.GetExecutingAssembly()
                               .GetTypes()
                               .Where(item => item.GetInterfaces().Contains(self));
            return Assembly.GetExecutingAssembly()
                           .GetTypes()
                           .Where(item => item.IsSubclassOf(self));
        }
        /// <summary>
        /// 获取所有程序集中的类型的子类，3.5有问题
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetSubTypesInAssemblys(this Type self)
        {
            if (self.IsInterface)
                return AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(item => item.GetTypes())
                                .Where(item => item.GetInterfaces().Contains(self));
            return AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(item => item.GetTypes())
                            .Where(item => item.IsSubclassOf(self));
        }

        /// <summary>
        /// 是否继承接口
        /// </summary>
        /// <param name="self"></param>
        /// <param name="Interface"></param>
        /// <returns></returns>
        public static bool IsExtendInterface(this Type self, Type Interface)
        {
            return self.GetInterfaces().Contains(Interface);
        }

        /// <summary>
        /// 是否继承自泛型类
        /// </summary>
        /// <param name="self"></param>
        /// <param name="genericType"></param>
        /// <returns></returns>
        public static bool IsSubclassOfGeneric(this Type self, Type genericType)
        {
#if NETFX_CORE
                if (!genericTypeDefinition.GetTypeInfo().IsGenericTypeDefinition)
#else
            if (!genericType.IsGenericTypeDefinition)
#endif
                return false;

#if NETFX_CORE
                if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition().Equals(genericTypeDefinition))
#else
            if (self.IsGenericType && self.GetGenericTypeDefinition().Equals(genericType))
#endif
                return true;

#if NETFX_CORE
                Type baseType = type.GetTypeInfo().BaseType;
#else
            Type baseType = self.BaseType;
#endif
            if (baseType != null && baseType != typeof(object))
            {
                if (baseType.IsSubclassOfGeneric(genericType))
                    return true;
            }

            foreach (Type t in self.GetInterfaces())
            {
                if (t.IsSubclassOfGeneric(genericType))
                    return true;
            }

            return false;
        }
        /// <summary>
        /// 获取类型树
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static IList<Type> GetTypeTree(this Type t)
        {
            var tmp = t;
            var types = new List<Type>();
            do
            {
                types.Add(t);
                t = t.BaseType;
            } while (t != null);
            types.AddRange(tmp.GetInterfaces());
            return types;
        }
        /// <summary>
        /// 获取程序集下的静态扩展
        /// </summary>
        /// <param name="self"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> GetExtensionMethods(this Type self, Assembly assembly)
        {
            var query = from type in assembly.GetTypes()
                        where !type.IsGenericType && !type.IsNested
                        from method in type.GetMethods(BindingFlags.Static
                            | BindingFlags.Public | BindingFlags.NonPublic)
                        where method.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false)
                        where method.GetParameters()[0].ParameterType == self
                        select method;
            return query;
        }


        /// <summary>
        /// 字符串结尾转Unix编码
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToUnixLineEndings(this string self)
        {
            return self.Replace("\r\n", "\n").Replace("\r", "\n");
        }
        /// <summary>
        /// 在字符串前拼接字符串
        /// </summary>
        /// <param name="self"></param>
        /// <param name="toPrefix"></param>
        /// <returns></returns>
        public static string AppendHead(this string self, string toPrefix)
        {
            return new StringBuilder(toPrefix).Append(self).ToString();
        }


        /// <summary>
        /// 拼接字符串
        /// </summary>
        /// <param name="self"></param>
        /// <param name="toAppend"></param>
        /// <returns></returns>
        public static string Append(this string self, string toAppend)
        {
            return new StringBuilder(self).Append(toAppend).ToString();
        }

        /// <summary>
        /// 拼接字符串
        /// </summary>
        /// <param name="self"></param>
        /// <param name="toAppend"></param>
        /// <returns></returns>
        public static string Append(this string self, params string[] toAppend)
        {
            if (toAppend == null)
            {
                return self;
            }
            StringBuilder result = new StringBuilder(self);
            foreach (string str in toAppend)
            {
                result = result.Append(str);
            }
            return result.ToString();
        }


    }

}
