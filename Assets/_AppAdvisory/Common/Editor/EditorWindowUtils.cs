
/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com
 * Facebook: https://facebook.com/appadvisory
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch
 ***********************************************************************************************************/




using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


namespace AppAdvisory.Utils
{
	public class EditorWindowUtils  
	{

		private static readonly string TOOLTIPSYMBOL = "    [?]";

		public static GUIContent CreateGUIContentFromDescriptionAndTooltip (string description, string tooltip = "") {
			GUIContent guiContent;
			if (String.IsNullOrEmpty (tooltip)) 
			{
				guiContent = new GUIContent (description);
			} else 
			{
				guiContent = new GUIContent (description + TOOLTIPSYMBOL, tooltip);
			}
			return guiContent;

		}

		public static void Space(uint spacing = 1) 
		{
			for (uint i = 0; i < spacing; i++) 
			{
				EditorGUILayout.Space ();
			}
		}

		public static void CreateLabelField(ref string text, string description, string tooltip = "", uint spacing = 1) 
		{

			GUIContent guiContent = CreateGUIContentFromDescriptionAndTooltip (description, tooltip);

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField (guiContent);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
			text = EditorGUILayout.TextField(text);
			EditorGUILayout.EndHorizontal();
			Space (spacing);
		}


		public static void CreateToggleField(ref bool boolean, string description, string tooltip = "")
		{
			GUIContent guiContent = CreateGUIContentFromDescriptionAndTooltip (description, tooltip);

			boolean = EditorGUILayout.BeginToggleGroup (guiContent, boolean);
			EditorGUILayout.EndToggleGroup ();
			EditorGUILayout.Space();
		}

	}
}