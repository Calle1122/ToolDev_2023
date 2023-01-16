using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class WindowEditor : EditorWindow
{
    [SerializeField] private VisualTreeAsset UXMLFile;

    public GameSettings settings = null;

    public float test = 2.5f;

    [MenuItem("Tools/Game Editor")]
    public static void ShowWindow()
    {
        WindowEditor window = GetWindow<WindowEditor>();
        window.titleContent = new GUIContent("Game Editor");
    }

    private void OnEnable()
    {
        settings = AssetDatabase.LoadAssetAtPath<GameSettings>("Assets/SO/GameSettings.asset");
        var serializedObj = new SerializedObject(settings);
        
        rootVisualElement.Bind(serializedObj);
    }

    private void CreateGUI()
    {
        UXMLFile = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UIBuilder/EditorWindow.uxml");
        
        UXMLFile.CloneTree(rootVisualElement);
    }
}
