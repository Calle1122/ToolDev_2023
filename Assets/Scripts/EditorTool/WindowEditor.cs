using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(WindowMono))]
public class WindowEditor : EditorWindow
{
    [SerializeField] private VisualTreeAsset UXMLFile;

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
