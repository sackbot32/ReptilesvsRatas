using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(GridManager))]
public class GridManagerInspector : Editor
{
    int columnLength = 0;
    int lineLength = 0;
    GridManager gridManager;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        gridManager = (GridManager)target;
        columnLength = EditorGUILayout.IntField("Column length", columnLength);
        lineLength = EditorGUILayout.IntField("Line length", lineLength);
        if (GUILayout.Button("Make grid from selected items"))
        {
            GetAllTiles();
            GetLines();
            GetCollumns();
        }
    }

    public void GetAllTiles()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            gridManager.allTiles.tiles.Add(obj.GetComponent<TileComponent>());
        }
    }

    public void GetLines()
    {
        gridManager.lines.Clear();
        int objectNumber = 0;
        TileCollection tileCollection = new TileCollection();
        foreach (GameObject obj in Selection.gameObjects)
        {
            objectNumber++;
            if (obj.GetComponent<TileComponent>() != null)
            {
                tileCollection.tiles.Add(obj.GetComponent<TileComponent>());
            }
            if(objectNumber == lineLength)
            {
                gridManager.lines.Add(tileCollection);
                tileCollection = new TileCollection();
                objectNumber = 0;
            }

        }
    }
    //Depends on get lines
    public void GetCollumns()
    {
        gridManager.columns.Clear();
        int objectNumber = 0;
        TileCollection tileCollection = new TileCollection();
        for (int i = 0; i < lineLength; i++)
        {
            foreach (TileCollection collection in gridManager.lines)
            {
                objectNumber++;
                tileCollection.tiles.Add(collection.tiles[i]);
            }
            if(objectNumber == columnLength)
            {
                gridManager.columns.Add(tileCollection);
                tileCollection = new TileCollection();
                objectNumber = 0;
            }
        }
    }
    
}
