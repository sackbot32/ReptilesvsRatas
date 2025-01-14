using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridManager))]
public class GridManagerInspector : Editor
{
    int columnLength = 0;
    int lineLength = 0;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GridManager gridManager = (GridManager)target;
        columnLength = EditorGUILayout.IntField("Column length", columnLength);
        lineLength = EditorGUILayout.IntField("Line length", lineLength);
        if (GUILayout.Button("Make grid from selected items"))
        {

        }
    }

    
}
