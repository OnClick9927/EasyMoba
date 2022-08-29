/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2017.2.3p3
 *Date:           2019-07-02
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
namespace IFramework.UI
{
    public static class UIEx
    {
        public static IAwaiter<UIItem> GetAwaiter(this UIItem target)
        {
            return new UIItemAwaiter(target);
        }
    }


}
