using System;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

#if true

[CustomEditor(typeof(InspectorMono))]
public class InspectorEditor : Editor
{
    public VisualTreeAsset m_UXML;
    public ToolbarButton m_SettingsBtn;

    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();

        m_UXML = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UIBuilder/InspectorEditor.uxml");
        
        m_UXML.CloneTree(root);

        root.Query<ToolbarButton>("settings").First().clicked += Test;

        var foldout = new Foldout() { viewDataKey = "InspectorEditorFullFoldout", text = "Full Editor" };
        InspectorElement.FillDefaultInspector(foldout, serializedObject, this);
        root.Add(foldout);
        return root;
    }

    public void Test()
    {
        WindowEditor.ShowWindow();
    }
    
}

#endif
