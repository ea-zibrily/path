using System;
using System.Collections.Generic;
using System.Linq;
using Tsukuyomi.Weapons.Component;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Tsukuyomi.Weapons
{
    [CustomEditor(typeof(WeaponData))]
    public class WeaponDataSOEditor : Editor
    {
        private static List<Type> dataComponentTypes = new List<Type>();
        private WeaponData weaponDataSO;

        private bool showAddComponentButtons;
        private bool showAddForceButtons;

        private void OnEnable()
        {
            weaponDataSO = target as WeaponData;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            #region Add Component
            
            // EditorGUILayout.Foldout() buat ngumpulin button jadi 1 folder
            showAddComponentButtons = EditorGUILayout.Foldout(showAddComponentButtons, "Add Attack Component");
            if (showAddComponentButtons)
            {
                foreach (var dataComponentType in dataComponentTypes)
                {
                    if (GUILayout.Button((dataComponentType.Name)))
                    {
                        var component = Activator.CreateInstance(dataComponentType)  as ComponentData;
                        if (component == null)
                        {
                            return;
                        }
                        component.InitializeAttackData(weaponDataSO.maxAttackCounter);
                        weaponDataSO.AddData(component);
                    }
                }
            }

            #endregion

            #region Add Force
            
            // EditorGUILayout.Foldout() buat ngumpulin button jadi 1 folder
            showAddForceButtons = EditorGUILayout.Foldout(showAddForceButtons, "Add Attack Force");
            if (showAddForceButtons)
            {
                if (GUILayout.Button("Force Update Component Name"))
                {
                    foreach (var buttonName in weaponDataSO.WeaponComponentData)
                    {
                        buttonName.SetComponentName();
                    }
                }
            
                if (GUILayout.Button("Force Update Attack Name"))
                {
                    foreach (var buttonName in weaponDataSO.WeaponComponentData)
                    {
                        buttonName.SetAttackDataNames();
                    }
                }
                
                if (GUILayout.Button("Refresh Max Counter"))
                {
                    foreach (var buttonName in weaponDataSO.WeaponComponentData)
                    {
                        buttonName.InitializeAttackData(weaponDataSO.maxAttackCounter);
                    }
                }
            }

            #endregion
        }

        [DidReloadScripts]
        private static void OnRecompile()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(assembly  => assembly .GetTypes());
            var fileteredTypes = types.Where(
                type => type.IsSubclassOf(typeof(ComponentData)) && !type.ContainsGenericParameters && type.IsClass);
            
            dataComponentTypes = fileteredTypes.ToList();
        }
    }
}