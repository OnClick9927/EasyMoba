/*********************************************************************************
 *Author:         OnClick
 *Version:        1.0
 *UnityVersion:   2020.3.3f1c1
 *Date:           2022-09-03
 *Description:    Description
 *History:        2022-09-03--
*********************************************************************************/
using IFramework;
using IFramework.Hotfix.Lua;
using IFramework.UI;

namespace EasyMoba
{
    public class MobaModules
    {
        public MobaAssetsUpdate update = new MobaAssetsUpdate();
        public TcpClient tcp;

        public UIModule UpdateUI { get { return Launcher.modules.GetModule<UIModule>("Update", priority: 2); } }
        public UIModule UI { get { return Launcher.modules.GetModule<UIModule>("Lua", priority: 100); } }

        public XLuaModule Lua
        {
            get { return Launcher.modules.GetModule<XLuaModule>(priority: 1); }
        }
    }
}
