/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.11f1
 *Date:           2019-09-08
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System.Collections.Generic;
using System.Reflection;

namespace IFramework.Serialization.DataTable
{
    /// <summary>
    /// string 解释器
    /// </summary>
    public interface IDataExplainer
    {
        /// <summary>
        /// 根据格子反序列化一个实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cols"></param>
        /// <param name="membersDic">需要反序列化的成员</param>
        /// <returns></returns>
        T CreatInstance<T>(List<DataColumn> cols, Dictionary<MemberInfo, string> membersDic);
        /// <summary>
        /// 根据 具体类型 获取单个数据格子数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="membersDic">需要序列化的成员</param>
        /// <returns></returns>
        List<DataColumn> GetColumns<T>(T t, Dictionary<MemberInfo, string> membersDic);
    }
}
