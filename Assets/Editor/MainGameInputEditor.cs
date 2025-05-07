using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.Linq;

[CustomEditor(typeof(MiniGameInput))]
public class MiniGameInputEditor : Editor
{
    private string[] sceneNames;
    private int selectedIndex;

    private void OnEnable()
    {
        sceneNames = EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => System.IO.Path.GetFileNameWithoutExtension(scene.path))
            .ToArray();

        var targetScript = (MiniGameInput)target;
        selectedIndex = System.Array.IndexOf(sceneNames, targetScript.miniGameScene);
        if (selectedIndex < 0) selectedIndex = 0;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("¹Ì´Ï°ÔÀÓ ¾À ¼±ÅÃ", EditorStyles.boldLabel);

        selectedIndex = EditorGUILayout.Popup("¾À ÀÌ¸§", selectedIndex, sceneNames);

        var targetScript = (MiniGameInput)target;
        targetScript.miniGameScene = sceneNames[selectedIndex];

        EditorUtility.SetDirty(targetScript);

        serializedObject.ApplyModifiedProperties();
    }
}
