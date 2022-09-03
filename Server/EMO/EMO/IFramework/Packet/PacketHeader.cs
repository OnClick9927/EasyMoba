/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-03-14
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using System;

namespace IFramework.Packets
{
    struct PacketHeader
    {
        //头共 15 个字节

        public UInt32 MainId { get; set; }

        public UInt32 SubId { get; set; }
        public byte pkgType { get; set; }
        public UInt16 pkgCount { get; set; } /*= 1;*/
        public UInt32 messageLen { get; internal set; }
    }
}
