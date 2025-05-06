using UnityEditor;
using UnityEngine;

public class AddCharacterSorting : EditorWindow
{
    [MenuItem("Tools/ĳ���� ���� ��ũ��Ʈ �߰�")]
    public static void AddScript()
    {
        int count = 0;

        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.CompareTag("Map")) continue;

            var sr = obj.GetComponent<SpriteRenderer>();
            if (sr != null && obj.GetComponent<SortingOrderByY>() == null)
            {
                var added = Undo.AddComponent<SortingOrderByY>(obj);
                added.orderOffset = 1000; // �ʺ��� �տ� ������ ����
                count++;
            }
        }

        Debug.Log($"{count}���� ĳ���� ������Ʈ�� ���� ��ũ��Ʈ�� �߰��߽��ϴ�.");
    }
}
