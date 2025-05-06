using UnityEditor;
using UnityEngine;

public class AddCharacterSorting : EditorWindow
{
    [MenuItem("Tools/캐릭터 정렬 스크립트 추가")]
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
                added.orderOffset = 1000; // 맵보다 앞에 오도록 보장
                count++;
            }
        }

        Debug.Log($"{count}개의 캐릭터 오브젝트에 정렬 스크립트를 추가했습니다.");
    }
}
