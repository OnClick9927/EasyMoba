using UnityEngine;
using UnityEditor;
using static IFramework.UI.SuperScrollView.LoopListView;
using UnityEditorInternal;
using IFramework.GUITool;

namespace IFramework.UI.SuperScrollView
{

    [CustomEditor(typeof(LoopListView))]
    class LoopListViewEditor : Editor
    {

        SerializedProperty mSupportScrollBar;
        SerializedProperty mItemSnapEnable;
        SerializedProperty mArrangeType;
        SerializedProperty mItemPrefabDataList;
        SerializedProperty mItemSnapPivot;
        SerializedProperty mViewPortSnapPivot;

        GUIContent mSupportScrollBarContent = new GUIContent("SupportScrollBar");
        GUIContent mItemSnapEnableContent = new GUIContent("ItemSnapEnable");
        GUIContent mArrangeTypeGuiContent = new GUIContent("ArrangeType");
        GUIContent mItemSnapPivotContent = new GUIContent("ItemSnapPivot");
        GUIContent mViewPortSnapPivotContent = new GUIContent("ViewPortSnapPivot");
        ReorderableList reorderableList;
        protected virtual void OnEnable()
        {
            mSupportScrollBar = serializedObject.FindProperty("_supportScrollBar");
            mItemSnapEnable = serializedObject.FindProperty("_snapEnable");
            mArrangeType = serializedObject.FindProperty("_arrangeType");
            mItemPrefabDataList = serializedObject.FindProperty("prefabDatas");
            mItemSnapPivot = serializedObject.FindProperty("_snapPivot");
            mViewPortSnapPivot = serializedObject.FindProperty("_viewPortSnapPivot");

            reorderableList = EditorTools.ReorderableListTool.CreateAutoLayout(mItemPrefabDataList);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.LabelField("Prefabs", GUIStyles.BoldLabel);
            reorderableList.DoLayoutList();
            EditorGUILayout.PropertyField(mArrangeType, mArrangeTypeGuiContent);
            EditorGUILayout.PropertyField(mSupportScrollBar, mSupportScrollBarContent);
            EditorGUILayout.PropertyField(mItemSnapEnable, mItemSnapEnableContent);
            if (mItemSnapEnable.boolValue == true)
            {
                EditorGUILayout.PropertyField(mItemSnapPivot, mItemSnapPivotContent);
                EditorGUILayout.PropertyField(mViewPortSnapPivot, mViewPortSnapPivotContent);
            }
            EditorGUILayout.Space();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
