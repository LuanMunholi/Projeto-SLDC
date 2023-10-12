using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InstantiateGrid))]
public class GridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var grid = (InstantiateGrid)target;
        EditorGUI.BeginChangeCheck();
        base.OnInspectorGUI();

        if (EditorGUI.EndChangeCheck())
        {
            grid.Create();
        }

    }
}
