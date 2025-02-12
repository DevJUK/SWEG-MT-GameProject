﻿using UnityEngine;
using UnityEditor;

public class JTools : EditorWindow
{
	/* Booleans for if the windows are open */
	private bool IsMeshMaterialOpen;

	/* Custom Colours */
	private Color32 LightGreen1 = new Color32(70, 193, 64, 255);
	private Color32 LightRed1 = new Color32(255, 177, 177, 255);

	/* Editor Window Directory Location */
	[MenuItem("Window/J-Tools _j")]
	public static void ShowWindow()
	{
		GetWindow<JTools>("J-Tools");
	}

	/* What shows on the GUI */
	private void OnGUI()
	{
		Header();
		OpenWindows();
	}

	/* Header Function */
	private void Header()
	{
		GUILayout.Space(10f);
		EditorGUILayout.HelpBox("A selection of tools that I've developed to make life easier where a tool didn't already exsits or didn't do exactly what I needed it to do.", MessageType.None);
		GUILayout.Space(10f);
	}

	/* Function that shows the tools and the buttons to open them */
	private void OpenWindows()
	{
		EditorGUILayout.LabelField("Mesh Material Apply Tool   (Shift-M)", EditorStyles.boldLabel);
		GUILayout.Space(10f);
		EditorGUILayout.HelpBox("A tool to apply materials to multiple copies of the same mesh at once.", MessageType.None);
		GUILayout.Space(2.5f);

		GUILayout.BeginHorizontal();

		GUI.color = LightGreen1;

		if (GUILayout.Button("Open Tool", GUILayout.MaxWidth(100)))
		{
			GetWindow<MeshMaterialTool>();
			IsMeshMaterialOpen = true;
		}

		GUI.color = LightRed1;

		if (GUILayout.Button("Close Tool", GUILayout.MaxWidth(100)))
		{
			if (IsMeshMaterialOpen)
			{
				GetWindow<MeshMaterialTool>().Close();
				IsMeshMaterialOpen = false;
			}
		}

		GUILayout.EndHorizontal();
	}
}
