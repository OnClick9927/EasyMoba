/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-05-03
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
namespace IFramework.Serialization
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    public class SByteStringConverter : StringConverter<sbyte>
    {
        public override bool TryConvert(string self, out sbyte result)
        {
            return sbyte.TryParse(self, out result);
        }
    }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
}