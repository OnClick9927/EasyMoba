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

    public class CharStringConverter : StringConverter<char>
    {
        public override bool TryConvert(string self, out char result)
        {
            return char.TryParse(self, out result);
        }
    }

#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释

}
