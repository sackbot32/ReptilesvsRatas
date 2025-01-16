using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(RatHordeManager))]
public class RatHordeManagerEditor : Editor
{
    RatHordeManager r_Manager;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        r_Manager = (RatHordeManager)target;
        if (GUILayout.Button("Spawn next wave manually"))
        {
            r_Manager.SpawnNextWave();
        }
        if (GUILayout.Button("Set gameplay wave same to saved wave"))
        {
            r_Manager.EqualizeWaves();
        }
    }

}
