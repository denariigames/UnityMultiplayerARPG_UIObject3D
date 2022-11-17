/*
 * TODO:
 * 1) Change to 'targets' and allow multi object editing
 */
#region Namespace Imports
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace UI.ThreeDimensional
{
    [CustomEditor(typeof(UICharacterObject3D)), CanEditMultipleObjects]
    public class UICharacterObject3DEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            Dictionary<UICharacterObject3D, Transform> targetPrefabs = new Dictionary<UICharacterObject3D, Transform>();
            targetPrefabs = targets.ToDictionary(k => k as UICharacterObject3D, v => (v as UICharacterObject3D).ObjectPrefab);
            Dictionary<UICharacterObject3D, float> renderScales = targets.ToDictionary(k => k as UICharacterObject3D, v => (v as UICharacterObject3D).RenderScale);

            EditorGUI.BeginChangeCheck();

            if (GUILayout.Button("Force Render"))
            {
                foreach (var t in targetPrefabs)
                {
                    t.Key.HardUpdateDisplay();
                }
            }

            EditorGUILayout.Space();

            base.OnInspectorGUI();

            if (!EditorGUI.EndChangeCheck()) return;

            foreach (var t in targetPrefabs)
            {
                if (t.Key.ObjectPrefab != t.Value
                || renderScales[t.Key] != t.Key.RenderScale)
                {
                    t.Key.SetStarted();
                    t.Key.HardUpdateDisplay();
                    UIObject3DTimer.AtEndOfFrame(() => t.Key.UpdateDisplay(), t.Key);
                }
                else
                {
                    t.Key.UpdateDisplay(true);
                }
            }

        }
    }
}
