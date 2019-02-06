using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeshMaterialTool : EditorWindow
{


	[SerializeField]
	private Material ApplyMaterial;

	[SerializeField]
	private Material[] Mats = new Material[0];

	[SerializeField]
	private Material[] SelectMats = new Material[0];

	public int SelectElementLength;







	[MenuItem("Window/MeshMaterialEditor")]
	public static void ShowWindow()
	{
		GetWindow<MeshMaterialTool>("Mesh Material Editor");
	}



	private void OnGUI()
	{
		Header();
		Tool();
	}


	private void Header()
	{
		GUILayout.Space(10f);
		GUILayout.Label("Mesh material Editor", EditorStyles.boldLabel);
	}



	private void Tool()
	{

		EditorGUILayout.HelpBox("Add materials to selected gameobjects", MessageType.Info);


		if (GUILayout.Button("Find", GUILayout.MaxWidth(100)))
		{

			if (Mats.Length == 0)
			{
				// Makes the Array 1 Bigger
				Material[] TempArrayPlus1 = new Material[1];
				Mats.CopyTo(TempArrayPlus1, 0);
				Mats = TempArrayPlus1;
			}

			if (Selection.gameObjects.Length == 1)
			{
				foreach (GameObject I in Selection.gameObjects)
				{
					if (I.GetComponent<MeshRenderer>())
					{
						foreach (Material Mat in I.GetComponent<MeshRenderer>().sharedMaterials)
						{
							if (Mats[0] != null)
							{
								// Makes the Array 1 Bigger
								Material[] TempArray = new Material[Mats.Length + 1];
								Mats.CopyTo(TempArray, 0);
								Mats = TempArray;
							}

							Mats[Mats.Length - 1] = Mat;
						}
					}
					else if (I.GetComponentInChildren<MeshRenderer>())
					{
						foreach (Material Mat in I.GetComponentInChildren<MeshRenderer>().sharedMaterials)
						{
							if (Mats[0] != null)
							{
								// Makes the Array 1 Bigger
								Material[] TempArray = new Material[Mats.Length + 1];
								Mats.CopyTo(TempArray, 0);
								Mats = TempArray;
							}

							Mats[Mats.Length - 1] = Mat;
						}
					}
				}
			}
			else
			{
				foreach (GameObject I in Selection.gameObjects)
				{
					if (I.GetComponent<MeshRenderer>())
					{
						foreach (Material Mat in I.GetComponent<MeshRenderer>().sharedMaterials)
						{
							for (int i = 0; i < Mats.Length; i++)
							{
								if (!ArrayUtility.Contains(Mats, Mat))
								{
									if (Mats[0] != null)
									{
										// Makes the Array 1 Bigger
										Material[] TempArray = new Material[Mats.Length + 1];
										Mats.CopyTo(TempArray, 0);
										Mats = TempArray;
									}

									Mats[Mats.Length - 1] = Mat;
								}
							}
						}
					}
					else if (I.GetComponentInChildren<MeshRenderer>())
					{
						foreach (Material Mat in I.GetComponentInChildren<MeshRenderer>().sharedMaterials)
						{
							for (int i = 0; i < Mats.Length; i++)
							{
								if (!ArrayUtility.Contains(Mats, Mat))
								{
									if (Mats[0] != null)
									{
										// Makes the Array 1 Bigger
										Material[] TempArray = new Material[Mats.Length + 1];
										Mats.CopyTo(TempArray, 0);
										Mats = TempArray;
									}

									Mats[Mats.Length - 1] = Mat;
								}
							}
						}
					}
				}
			}


			// Setup Select array tobe the same size as the mats array
			Material[] MatsToSelect = new Material[Mats.Length];
			SelectMats.CopyTo(MatsToSelect, 0);
			SelectMats = MatsToSelect;

		}


		// Bit of code that makes the array visable
		ScriptableObject Target = this;
		SerializedObject SO = new SerializedObject(Target);
		SerializedProperty Array = SO.FindProperty("Mats");

		EditorGUILayout.PropertyField(Array, true);
		SO.ApplyModifiedProperties();
		// end of bit of code that does the thing stated above


		// Bit of code that makes the array visable
		ScriptableObject Target2 = this;
		SerializedObject SO2 = new SerializedObject(Target2);
		SerializedProperty Array2 = SO2.FindProperty("SelectMats");

		EditorGUILayout.PropertyField(Array2, true);
		SO2.ApplyModifiedProperties();
		// end of bit of code that does the thing stated above



		if (GUILayout.Button("Apply", GUILayout.MaxWidth(100)))
		{
			foreach (GameObject I in Selection.gameObjects)
			{
				if (I.GetComponent<MeshRenderer>())
				{
					ApplyToSelection(I.GetComponent<MeshRenderer>().sharedMaterials, SelectMats);
				}
				else if (I.GetComponentInChildren<MeshRenderer>())
				{
					foreach (MeshRenderer Mesh in I.GetComponentsInChildren<MeshRenderer>())
					{
						ApplyToSelection(Mesh.GetComponent<MeshRenderer>().sharedMaterials, SelectMats);
					}
				}
			}


			ClearArray(Mats);
			ClearArray(SelectMats);

			Material[] TempArray = new Material[0];
			Mats = TempArray;

			Material[] TempArrayV2 = new Material[0];
			SelectMats = TempArrayV2;
		}
	}






	private void ClearArray(Material[] Array)
	{
		for (int i = 0; i < Array.Length; i++)
		{
			Array[i] = null;
		}
	}


	private void ApplyToSelection(Material[] InputArray, Material[] SelectionArray)
	{
		for (int i = 0; i < InputArray.Length; i++)
		{
			if (SelectionArray[i] == null)
			{
				SelectionArray[i] = InputArray[i];
			}
		}




		foreach (GameObject I in Selection.gameObjects)
		{
			if (I.GetComponent<MeshRenderer>())
			{
				I.GetComponent<MeshRenderer>().sharedMaterials = SelectMats;
			}
			else if (I.GetComponentInChildren<MeshRenderer>())
			{
				foreach (MeshRenderer Mesh in I.GetComponentsInChildren<MeshRenderer>())
				{
					Mesh.GetComponentInChildren<MeshRenderer>().sharedMaterials = SelectMats;
				}
			}
		}
	}
}
