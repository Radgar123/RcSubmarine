using ManagersAndControllers.SaveManager;

namespace Editor
{
    using UnityEngine;
    using System.Collections;
    using UnityEditor;

    [CustomEditor(typeof(SaveManager))]
    public class CustomSaveManagerEditor : Editor
    {
        
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            SaveManager myTarget = (SaveManager) target;
            
            if (GUILayout.Button("Save"))
            {
                myTarget.SaveData();
            }
            
            if (GUILayout.Button("Load"))
            {
                myTarget.LoadData();
            }
        }
    }
}