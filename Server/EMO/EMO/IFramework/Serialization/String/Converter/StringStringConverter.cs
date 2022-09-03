/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-04-07
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/

namespace IFramework.Serialization
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    [System.Runtime.InteropServices.ComVisible(false)]

    public class StringStringConverter : StringConverter<string>
    {
        const string flag="\"";
        public override bool TryConvert(string self, out string result)
        {
            if (!self.StartsWith(flag) || !self.EndsWith(flag)) 
            {
                result = self;
                return true;
            }
            else
            {
                self = self.Remove(0, 1);
                self = self.Remove(self.Length - 1, 1);
                result = self;
                return true;
            }
        }
        public override string ConvertToString(string t)
        {
            return $"{flag}{t}{flag}";
        }
    }


#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释

}
