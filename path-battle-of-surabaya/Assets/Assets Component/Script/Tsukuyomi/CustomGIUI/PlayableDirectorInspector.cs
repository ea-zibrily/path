﻿using System.Linq;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Tsukuyomi.CustomGIUI
{
    public class PlayableDirectorInspector : UnityEditor.Editor
    {
        private TimelineAsset[] _timelineAssets;
 
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.LabelField("Configured Timelines", EditorStyles.boldLabel);
            var playableDirector = serializedObject.targetObject as PlayableDirector;
        
            if (playableDirector == null)
            {
                return;
            }
        
            _timelineAssets = _timelineAssets ?? Resources.FindObjectsOfTypeAll<TimelineAsset>();
            TimelineAsset[] configuredTimelines = _timelineAssets.Where(timelineAsset => timelineAsset.GetOutputTracks()
                    .Any(track => playableDirector.GetGenericBinding(track) != null))
                .ToArray();

            foreach (TimelineAsset timelineAsset in configuredTimelines)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(20);
                GUI.enabled = false;
                EditorGUILayout.ObjectField(timelineAsset, typeof(TimelineAsset), false);
                GUI.enabled = true;
            
                if (GUILayout.Button("Select"))
                {
                    playableDirector.playableAsset = timelineAsset;
                    TimelineEditor.Refresh(RefreshReason.ContentsModified);
                }
 
                GUILayout.EndHorizontal();
            }
        }
    }
}
