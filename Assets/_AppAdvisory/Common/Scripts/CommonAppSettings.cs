
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

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace AppAdvisory
{
	public class CommonAppSettings : ScriptableObject 
	{
		#region SETTABLE IN INSPECTOR

		public bool android_Amazon = false;
		public string iOS_ID;
		public string amazon_ID;
		public string android_Bundle_ID;

		public string shareTextBeforeUrl;
		public string shareTextAfterUrl;

		#endregion

		#region URLS

		private static readonly string URL_IOS = "https://itunes.apple.com/us/app/id";
		private static readonly string URL_ANDROID = "https://play.google.com/store/apps/details?id=";
		private static readonly string URL_AMAZON = "https://www.amazon.fr/dp/"; 

		private string url_ios
		{
			get 
			{
				return URL_IOS + iOS_ID;
			}
		}

		private string url_android
		{
			get
			{
				return URL_ANDROID + android_Bundle_ID; 
			}
		}

		private string url_amazon
		{
			get
			{
				return URL_AMAZON + amazon_ID;
			}
		}

		public string URL_STORE
		{
			get
			{
				string URL = "";

				#if UNITY_IOS
				URL = url_ios;
				#else
				URL = url_android;
				if(isAmazon)
					URL = url_amazon;
				#endif

				return URL;
			}
		}

		public bool isAmazon
		{
			get
			{
				return android_Amazon;
			}
		}

		#endregion

		public string ShareText
		{
			get
			{
				return shareTextBeforeUrl + URL_STORE + shareTextAfterUrl;
			}
		}

		#region EDITOR

		public bool isCommonFoldoutOpened = false;

		public static readonly string PATH = "Assets/_AppAdvisory/Common/";
		public static readonly string NAME = "CommonAppSettings";

		private static string PathToAsset 
		{
			get 
			{
				return PATH + NAME + ".asset";
			}
		}

		#if UNITY_EDITOR

		[MenuItem("Assets/Create/CommonAppSettings")]
		public static void CreateCommonAppSettings()
		{
			CommonAppSettings asset = ScriptableObject.CreateInstance<CommonAppSettings>();

			AssetDatabase.CreateAsset(asset, PathToAsset);
			AssetDatabase.SaveAssets();

			EditorUtility.FocusProjectWindow();

			Selection.activeObject = asset;
		}

		#endif

		#endregion
	}

}