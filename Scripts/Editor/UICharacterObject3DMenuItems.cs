using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace UI.ThreeDimensional
{
    public class UICharacterObject3DMenuItems : UIObject3DMenuItems
    {        
        [MenuItem("GameObject/UI/UICharacterObject3D")]
        private static void NewUICharacterObject3D()
        {                        
            Transform parent = UnityEditor.Selection.activeTransform;     

            if (parent == null || !(parent is RectTransform))
            {
                parent = GetCanvasTransform();
            }

            var prefabGUID = AssetDatabase.FindAssets("UICharacterObject3D t:GameObject").FirstOrDefault();
            if (prefabGUID != null)
            {                
                var prefab = (GameObject)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(prefabGUID), typeof(GameObject));                

                var newUIObject3D = GameObject.Instantiate(prefab);

                newUIObject3D.name = "UICharacterObject3D";
                newUIObject3D.transform.SetParent(parent);

                var transform = newUIObject3D.transform as RectTransform;

                transform.localPosition = Vector3.zero;
                transform.anchoredPosition3D = Vector3.zero;                
                transform.localScale = Vector3.one;
                transform.localRotation = Quaternion.identity;
                
                transform.SetParent(parent);

                transform.anchorMin = Vector2.zero;
                transform.anchorMax = Vector2.one;
                transform.offsetMin = Vector2.zero;
                transform.offsetMax = Vector2.zero;

                var uiObject3D = newUIObject3D.GetComponent<UICharacterObject3D>();
              
                UIObject3DTimer.DelayedCall(0.01f, () => uiObject3D.HardUpdateDisplay(), uiObject3D);
            }
        }
    }
}
