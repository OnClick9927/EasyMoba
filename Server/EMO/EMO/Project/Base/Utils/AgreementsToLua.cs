﻿using EMO.Project.Base.Net;
using IFramework;


namespace EMO.Project.Base.Utils
{
    public class AgreementsToLua
    {
        private static string _outPutPathFileName = "";

        private static string OutPutPathFileName
        {
            get
            {
                if (_outPutPathFileName == "")
                {
                    var rootDir = Directory.GetCurrentDirectory().CombinePath("EmmyLua");
                    FileUtils.CreateDir(rootDir);
                    _outPutPathFileName = rootDir.CombinePath("NetEventDefine.lua.txt");
                }
                return _outPutPathFileName;
            }
        }
        static string left = "{";
        static string right = "}";
        public static void Build()
        {
            var responseTypes = typeof(INetMsg).GetSubTypesInAssemblys().ToList();
            List<Type> types = new List<Type>();
            List<Type> enumTypes = new List<Type>();

            types.AddRange(responseTypes);
            var org = BuidRequestAndResponse(types);
            var other = BuildOther("", types, enumTypes);
            var _enum = BuildEnum("", enumTypes);

            File.WriteAllText(OutPutPathFileName, org + _enum + other);
            Log.L("---------------EmmyLua 协议生成完毕----------------------------");
        }

        private static string BuildEnum(string result, List<Type> types)
        {
            types = types.Distinct().ToList();
            result += "\nNetEventDefine.Enums = {\n";
            foreach (var type in types)
            {
                string name = type.Name;
                result += $"\t---@enum {name}\n";
                result += $"\t{name} = {left} ";
                var arr = Enum.GetValues(type);
                foreach (var val in arr)
                {
                    string _name = val.ToString();
                    var code = Convert.GetTypeCode(val);
                    long value = Convert.ToInt64(val);
                    result += $"{_name} = {value}, ";
                }
                result += $"{right},\n";
            }
            result += "}\n";
            return result;
        }
        private static string BuidRequestAndResponse(List<Type> types)
        {
            string result = "NetEventDefine = {\n";

            foreach (Type type in types)
            {
                if (type.IsInterface) continue;
                NetMessageCode h = type.GetCustomAttributes(typeof(NetMessageCode), false).First() as NetMessageCode;
                uint subId = h.SubId;

                result += $"\t{type.Name} = {left} " +
                    $"MainId = {h.MainId}, " +
                    $"SubId = {h.SubId} " +
                    $"{right},\n";
            }
            return result + "}\n";
        }

        private static Dictionary<Type, string> typeMap = new Dictionary<Type, string>()
        {
            {typeof(string), "string"},
            {typeof(char), "string"},

            {typeof(short), "number"},
            {typeof(int), "number"},
            {typeof(long), "number"},
            {typeof(ushort), "number"},
            {typeof(uint), "number"},
            {typeof(ulong), "number"},
            {typeof(float), "number"},
            {typeof(double), "number"},
            {typeof(DateTime), "number"},


            {typeof(bool), "boolean"},
        };

        public static string GetLuaType(Type type)
        {
            if (typeMap.ContainsKey(type))
            {
                return typeMap[type];
            }

            return string.Empty;
        }
        private static string WriteFields(string result, string fieldName, Type type, List<Type> other)
        {
            var luaType = GetLuaType(type);
            if (string.IsNullOrEmpty(luaType))
            {
                if (type.IsSubclassOfGeneric(typeof(List<>)))
                {
                    var eles = type.GetGenericArguments();
                    var element_type = eles[0];
                    var element_type_luaType = GetLuaType(element_type);
                    if (string.IsNullOrEmpty(element_type_luaType))
                    {
                        luaType = $"{element_type.Name}[]";
                        other.Add(element_type);
                    }
                    else
                    {
                        luaType = $"{element_type_luaType}[]";
                    }

                }
                else if (type.IsArray)
                {
                    var element_type = type.GetElementType();
                    var element_type_luaType = GetLuaType(element_type);
                    if (string.IsNullOrEmpty(element_type_luaType))
                    {
                        luaType = $"{element_type.Name}[]";
                        other.Add(element_type);
                    }
                    else
                    {
                        luaType = $"{element_type_luaType}[]";
                    }

                }
                else if (type.IsSubclassOfGeneric(typeof(Dictionary<,>)))
                {
                    var eles = type.GetGenericArguments();
                    var element_type_1 = eles[0];
                    var element_type_2 = eles[1];
                    var element_type_luaType_1 = GetLuaType(element_type_1);
                    var element_type_luaType_2 = GetLuaType(element_type_2);
                    if (string.IsNullOrEmpty(element_type_luaType_1))
                    {
                        other.Add(element_type_1);
                        element_type_luaType_1 = element_type_1.Name;
                    }
                    if (string.IsNullOrEmpty(element_type_luaType_2))
                    {
                        other.Add(element_type_2);
                        element_type_luaType_2 = element_type_2.Name;
                    }
                    luaType = $"table<{element_type_luaType_1},{element_type_luaType_2}>";
                }
                else
                {
                    luaType = type.Name;
                    other.Add(type);
                }

            }
            result += $"---@field {fieldName} {luaType}\n";
            return result;
        }
        private static string BuildString(Type type, string result, List<Type> other, List<Type> enumTypes)
        {
            string className = type.Name;

            if (!type.IsEnum)
            {
                result += $"\n---@class {className}";

                result += $"\n";
                var fileds = type.GetFields();
                var ps = type.GetProperties();

                foreach (var field in fileds)
                    result = WriteFields(result, field.Name, field.FieldType, other);
                foreach (var p in ps)
                    result = WriteFields(result, p.Name, p.PropertyType, other);
            }
            else
            {
                //result += $" Enum\n";
                enumTypes.Add(type);
            }


            return result;
        }

        private static string BuildOther(string result, List<Type> other, List<Type> enumTypes)
        {
            List<Type> types = new List<Type>(other);
            other.Clear();
            types = types.Distinct().ToList();
            foreach (var type in types)
            {
                result = BuildString(type, result, other, enumTypes);
            }

            if (other.Count != 0)
            {
                result = BuildOther(result, other, enumTypes);
            }

            return result;
        }
    }
}