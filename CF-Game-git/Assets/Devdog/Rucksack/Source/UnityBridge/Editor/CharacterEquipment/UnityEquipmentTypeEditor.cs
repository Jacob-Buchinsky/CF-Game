using System;
using System.Collections.Generic;
using Devdog.General2.Editors;
using Devdog.Rucksack.Items.Editor;
using UnityEditor;
using UnityEngine;

namespace Devdog.Rucksack.CharacterEquipment.Editor
{
    [CustomEditor(typeof(UnityEquipmentType), true)]
    public class UnityEquipmentTypeEditor : ObjectEditorBase<UnityEquipmentType>
    {
        protected override void OnInspecstorGUI(Dictionary<string, Action<SerializedProperty>> overrides)
        {
            overrides["_guid"] = (obj) =>
            {
                using (new GUIDisabledBlock())
                {
                    EditorGUILayout.PropertyField(obj, new GUIContent(obj.displayName), true);
                }
            };
            
            base.OnInspecstorGUI(overrides);
        }
    }
}