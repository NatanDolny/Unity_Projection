using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Audio;
using UnityEngine.Rendering.HighDefinition;
using UnityEditor;

[CustomEditor(typeof(ProjectorHandler))]
public class ProjectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        ProjectorHandler handler = (ProjectorHandler)target;

        handler.projectorMode = (ProjectorHandler.Modes)EditorGUILayout.EnumPopup("Mode", handler.projectorMode);
        handler.lightShape = (SpotLightShape)EditorGUILayout.EnumPopup("Light Shape", handler.lightShape);
        handler.brightness = EditorGUILayout.Slider("Brightness", handler.brightness, 0.0f, 50000.0f);
        handler.aspectRatioFloat = EditorGUILayout.Slider("Aspect Ratio Float", handler.aspectRatioFloat, 0.0f, 20.0f);
        handler.range = EditorGUILayout.Slider("Range", handler.range, 0.0f, 100.0f);

        if (handler.projectorMode == ProjectorHandler.Modes.Image)
        {
            handler.lightTexture = (Texture2D)EditorGUILayout.ObjectField("Image Cookie", handler.lightTexture, typeof(Texture2D), false);
        }
        else if (handler.projectorMode == ProjectorHandler.Modes.Camera)
        {
            handler.renderTexture = (RenderTexture)EditorGUILayout.ObjectField("Camera Feed", handler.renderTexture, typeof(RenderTexture), false);
        }
        else if (handler.projectorMode == ProjectorHandler.Modes.Video)
        {
            handler.videoClip = (VideoClip)EditorGUILayout.ObjectField("Video Clip", handler.videoClip, typeof(VideoClip), false);
            handler.renderTexture = (RenderTexture)EditorGUILayout.ObjectField("Target texture", handler.renderTexture, typeof(RenderTexture), false);
            handler.audioOutputMode = (VideoAudioOutputMode)EditorGUILayout.EnumPopup("Audio Output Mode", handler.audioOutputMode);
            handler.aspectRatioEnum = (VideoAspectRatio)EditorGUILayout.EnumPopup("Aspect Ratio Enum", handler.aspectRatioEnum);
            handler.looping = (bool)EditorGUILayout.Toggle("Looping", handler.looping);
            handler.volume = EditorGUILayout.Slider("Volume", handler.volume, 0.0f, 1.0f);;
        }
    }
}
