using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class WindowEditor : EditorWindow
{
    [SerializeField] private VisualTreeAsset UXMLFile;

    public float test = 2.5f;

    [MenuItem("Tools/Game Editor")]
    public static void ShowWindow()
    {
        WindowEditor window = GetWindow<WindowEditor>();
        window.titleContent = new GUIContent("Game Editor");
    }
    
    private void CreateGUI()
    {
        UXMLFile.CloneTree(rootVisualElement);
    }
}
