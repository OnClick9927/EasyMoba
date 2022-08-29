/*********************************************************************************
 *Author:         OnClick
 *Version:        0.0.1
 *UnityVersion:   2018.3.1f1
 *Date:           2019-03-18
 *Description:    IFramework
 *History:        2018.11--
*********************************************************************************/
using UnityEditor;
using UnityEngine;

namespace IFramework
{
    public enum AnchorType
    {
        UpperLeft = 0,
        UpperCenter = 1,
        UpperRight = 2,
        MiddleLeft = 3,
        MiddleCenter = 4,
        MiddleRight = 5,
        LowerLeft = 6,
        LowerCenter = 7,
        LowerRight = 8
    }
    public enum SplitType
    {
        Vertical, Horizontal
    }
    partial class EditorTools
    {
        private const string copyAssetPathPath = "Assets/IFramework/Copy Path";
        private const string findScriptPath = "CONTEXT/MonoBehaviour/IFramework.FindScript";



        [MenuItem(findScriptPath)]
        static void FindScript(MenuCommand command)
        {
            Selection.activeObject = MonoScript.FromMonoBehaviour(command.context as MonoBehaviour);
        }

        [MenuItem(copyAssetPathPath, priority = -100000000)]
        public static void CopyAssetPath()
        {
            if (EditorApplication.isCompiling)
            {
                return;
            }
            string path = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
            GUIUtility.systemCopyBuffer = path;
        }

        static class Prefs
        {
            private static string GetKey<T>(string key)
            {
                return string.Format("{0}/{1}", typeof(T).FullName, key);
            }
            private static string GetString<T>(string key)
            {
                return EditorPrefs.GetString(GetKey<T>(key));
            }
            public static bool HasKey<T>(string key)
            {
                return EditorPrefs.HasKey(GetKey<T>(key));
            }
            private static void SetString<T>(string key, string value)
            {
                EditorPrefs.SetString(GetKey<T>(key), value);
            }
            public static void SetObject<T, V>(string key, V value)
            {
                SetString<T>(key, JsonUtility.ToJson(value));
            }
            public static V GetObject<T, V>(string key)
            {
                if (HasKey<T>(key))
                {
                    var str = GetString<T>(key);
                    return JsonUtility.FromJson<V>(str);
                }
                return default(V);
            }
        }

        public static void SaveToPrefs<T>(this T value, string key)
        {
            Prefs.SetObject<T, T>(key, value);
        }
        public static T GetFromPrefs<T>(this object value, string key)
        {
            return Prefs.GetObject<T, T>(key);
        }


        public static void OpenFolder(string folder)
        {
            EditorUtility.OpenWithDefaultApp(folder);
        }
        public static Rect LocalPosition(this EditorWindow self)
        {
            return new Rect(Vector2.zero, self.position.size);
        }

        public static Rect Zoom(this Rect rect, AnchorType type, float pixel)
        {
            return Zoom(rect, type, new Vector2(pixel, pixel));
        }
        public static Rect Zoom(this Rect rect, AnchorType type, Vector2 pixelOffset)
        {
            float tempW = rect.width + pixelOffset.x;
            float tempH = rect.height + pixelOffset.y;
            switch (type)
            {
                case AnchorType.UpperLeft:
                    break;
                case AnchorType.UpperCenter:
                    rect.x -= (tempW - rect.width) / 2;
                    break;
                case AnchorType.UpperRight:
                    rect.x -= tempW - rect.width;
                    break;
                case AnchorType.MiddleLeft:
                    rect.y -= (tempH - rect.height) / 2;
                    break;
                case AnchorType.MiddleCenter:
                    rect.x -= (tempW - rect.width) / 2;
                    rect.y -= (tempH - rect.height) / 2;
                    break;
                case AnchorType.MiddleRight:
                    rect.y -= (tempH - rect.height) / 2;
                    rect.x -= tempW - rect.width;
                    break;
                case AnchorType.LowerLeft:
                    rect.y -= tempH - rect.height;
                    break;
                case AnchorType.LowerCenter:
                    rect.y -= tempH - rect.height;
                    rect.x -= (tempW - rect.width) / 2;
                    break;
                case AnchorType.LowerRight:
                    rect.y -= tempH - rect.height;
                    rect.x -= tempW - rect.width;
                    break;
            }
            rect.width = tempW;
            rect.height = tempH;
            return rect;
        }



        public static Rect CutBottom(this Rect r, float pixels)
        {
            r.yMax -= pixels;
            return r;
        }
        public static Rect CutTop(this Rect r, float pixels)
        {
            r.yMin += pixels;
            return r;
        }
        public static Rect CutRight(this Rect r, float pixels)
        {
            r.xMax -= pixels;
            return r;
        }
        public static Rect CutLeft(this Rect r, float pixels)
        {
            r.xMin += pixels;
            return r;
        }
        public static Rect Cut(this Rect r, float pixels)
        {
            return r.Margin(-pixels);
        }
        public static Rect Margin(this Rect r, float pixels)
        {
            r.xMax += pixels;
            r.xMin -= pixels;
            r.yMax += pixels;
            r.yMin -= pixels;
            return r;
        }

        public static Rect[] Split(this Rect r, SplitType type, float offset, float padding = 0, bool justMid = true)
        {
            switch (type)
            {
                case SplitType.Vertical:
                    return r.VerticalSplit(offset, padding, justMid);
                case SplitType.Horizontal:
                    return r.HorizontalSplit(offset, padding, justMid);
                default:
                    return default(Rect[]);
            }
        }
        public static Rect SplitRect(this Rect r, SplitType type, float offset, float padding = 0)
        {
            switch (type)
            {
                case SplitType.Vertical:
                    return r.VerticalSplitRect(offset, padding);
                case SplitType.Horizontal:
                    return r.HorizontalSplitRect(offset, padding);
                default:
                    return default(Rect);
            }
        }
        public static Rect[] VerticalSplit(this Rect r, float width, float padding = 0, bool justMid = true)
        {
            if (justMid)
                return new Rect[2]{
                r.CutRight((int)(r.width-width)).CutRight(padding).CutRight(-Mathf.CeilToInt(padding/2f)),
                r.CutLeft(width).CutLeft(padding).CutLeft(-Mathf.FloorToInt(padding/2f))
            };
            return new Rect[2]{
                r.CutRight((int)(r.width-width)).Cut(padding).CutRight(-Mathf.CeilToInt(padding/2f)),
                r.CutLeft(width).Cut(padding).CutLeft(-Mathf.FloorToInt(padding/2f))
            };
        }
        public static Rect[] HorizontalSplit(this Rect r, float height, float padding = 0, bool justMid = true)
        {
            if (justMid)
                return new Rect[2]{
                r.CutBottom((int)(r.height-height)).CutBottom(padding).CutBottom(-Mathf.CeilToInt(padding/2f)),
                r.CutTop(height).CutTop(padding).CutTop(-Mathf.FloorToInt(padding/2f))
                };
            return new Rect[2]{
                r.CutBottom((int)(r.height-height)).Cut(padding).CutBottom(-Mathf.CeilToInt(padding/2f)),
                r.CutTop(height).Cut(padding).CutTop(-Mathf.FloorToInt(padding/2f))
            };
        }
        public static Rect HorizontalSplitRect(this Rect r, float height, float padding = 0)
        {
            Rect rect = r.CutBottom((int)(r.height - height)).Cut(padding).CutBottom(-Mathf.CeilToInt(padding / 2f));
            rect.y += rect.height;
            rect.height = padding;
            return rect;
        }
        public static Rect VerticalSplitRect(this Rect r, float width, float padding = 0)
        {
            Rect rect = r.CutRight((int)(r.width - width)).Cut(padding).CutRight(-Mathf.CeilToInt(padding / 2f));
            rect.x += rect.width;
            rect.width = padding;
            return rect;
        }
        public static Vector2 TopLeft(this Rect r)
        {
            return new Vector2(r.x, r.y);
        }
        public static Vector2 TopRight(this Rect r)
        {
            return new Vector2(r.xMax, r.y);
        }
        public static Vector2 BottomRight(this Rect r)
        {
            return new Vector2(r.xMax, r.yMax);
        }
        public static Vector2 BottomLeft(this Rect r)
        {
            return new Vector2(r.x, r.yMax);
        }
        public static Rect Set(this Rect self, Vector2 position, Vector2 size)
        {
            self.Set(position.x, position.y, size.x, size.y);
            return self;
        }
        public static void DrawOutLine(this Rect rect, float width, Color color)
        {
            Handles.color = color;

            Handles.DrawAAPolyLine(2, new Vector3(rect.x,
                                         rect.y,
                                         0),
                          new Vector3(rect.x,
                                         rect.yMax,
                                         0),
                          new Vector3(rect.xMax,
                                         rect.yMax,
                                         0),
                          new Vector3(rect.xMax,
                                         rect.y,
                                         0),
                          new Vector3(rect.x,
                                         rect.y,
                                         0)
                            );

            Handles.color = Color.white;
        }
    }
}
