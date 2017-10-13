
/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com
 * Facebook: https://facebook.com/appadvisory
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch
 ***********************************************************************************************************/




using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using MyThreadPriority = System.Threading.ThreadPriority;

#if APPADVISORY_ADS
using AppAdvisory.Ads;
#endif

#if VSGIF
using AppAdvisory.VSGIF;
#endif

#if APPADVISORY_LEADERBOARD
using AppAdvisory.social;
#endif

#if VSRATE
using AppAdvisory.VSRATE; 
#endif

#if VS_SHARE
using AppAdvisory.SharingSystem;
#endif

using AppAdvisory.Utils;


namespace AppAdvisory
{
	public class SettingsWindow : EditorWindow
	{

		Vector2 scrollPos;

		public static SettingsWindow InitWindow() 
		{
			SettingsWindow window = GetWindow<SettingsWindow>("AA - Settings");
			window.Show ();
			return window;
		}

		#region COMMON

		public CommonAppSettings commonAppSettings;

		public void SetCommonAppSettings(CommonAppSettings commonAppSettings) {
			this.commonAppSettings = commonAppSettings;
		}

		public void DisplayCommonSettings(bool isOpened) 
		{
			commonAppSettings.isCommonFoldoutOpened = isOpened;
		}

		public bool ANDROID_AMAZON {
			get {
				bool _bool = commonAppSettings.android_Amazon;

				return _bool;
			}

			set {
				bool _bool = commonAppSettings.android_Amazon;

				if (_bool == value)
					return;

				commonAppSettings.android_Amazon = value;

				SetScriptingSymbols ("ANDROID_AMAZON", value);
			}
		}
			
		#endregion
			
		#region ADS

		#if APPADVISORY_ADS

		public ADIDS adIDs;

		public void SetAdIDs(ADIDS adIds) 
		{
			this.adIDs = adIds;
		}

		public void DisplayAdsSettings(bool isOpened) 
		{
			adIDs.isAdsFoldoutOpened = isOpened;
		}

		public bool DEBUG
		{
			get
			{

				bool _bool = adIDs.DEBUG;

				return _bool;
			}

			set
			{

				bool _bool = adIDs.DEBUG;

				if(_bool == value)
					return;

				adIDs.DEBUG = value;

				SetScriptingSymbols("AADEBUG", value);
			}
		}
			
		public bool EnableChartboost
		{
			get
			{
				bool _bool = adIDs.EnableChartboost;

				return _bool;
			}

			set
			{

				bool _bool = adIDs.EnableChartboost;

				if(_bool == value)
					return;

				adIDs.EnableChartboost = value;

				SetScriptingSymbols("CHARTBOOST", value);
			}
		}

		public bool EnableAdmob
		{
			get
			{
				bool _bool = adIDs.EnableAdmob;

				return _bool;
			}

			set
			{
				bool _bool = adIDs.EnableAdmob;

				if(_bool == value)
					return;

				adIDs.EnableAdmob = value;

				SetScriptingSymbols("ENABLE_ADMOB", value);
			}
		}

		public bool EnableAdcolony
		{
			get
			{
				bool _bool = adIDs.EnableAdcolony;

				return _bool;
			}

			set
			{
				bool _bool = adIDs.EnableAdcolony;

				if(_bool == value)
					return;

				adIDs.EnableAdcolony = value;

				SetScriptingSymbols("ENABLE_ADCOLONY", value);
			}
		}

		public bool EnableFacebook
		{
			get
			{
				bool _bool = adIDs.EnableFacebook;

				return _bool;
			}

			set
			{
				bool _bool = adIDs.EnableFacebook;

				if(_bool == value)
					return;

				adIDs.EnableFacebook = value;

				SetScriptingSymbols("ENABLE_FACEBOOK", value);
			}
		}

		#endif

		#endregion

		#region GIFS

		#if VSGIF

		public GIFSettings gifSettings;

		public void SetGIFs(GIFSettings gifSettings) 
		{
			this.gifSettings = gifSettings;
		}

		public void DisplayGIFSettings(bool isOpened) 
		{
			gifSettings.isGIFFoldoutOpened = isOpened;
		}

		#endif

		#endregion

		#region LEADERBOARD

		#if APPADVISORY_LEADERBOARD

		public LEADERBOARDIDS leaderboardIDs;

		public void SetLeaderboardIDs(LEADERBOARDIDS leaderboardIDs) {
			this.leaderboardIDs = leaderboardIDs;
		}

		public void DisplayLeaderboardSettings(bool isOpened) 
		{
			leaderboardIDs.isLeaderboardIDsFoldoutOpened = isOpened;
		}

		public bool Enable_iOS
		{
			get
			{
				bool _bool = leaderboardIDs.ENABLE_IOS;

				return _bool;
			}

			set
			{
				bool _bool = leaderboardIDs.ENABLE_IOS;

				if(_bool == value)
					return;

				leaderboardIDs.ENABLE_IOS = value;

				SetScriptingSymbols("VSLEADERBOARD_ENABLE_IOS", value);
			}
		}

		public bool Enable_Android
		{
			get
			{
				bool _bool = leaderboardIDs.ENABLE_ANDROID;

				return _bool;
			}

			set
			{
				bool _bool = leaderboardIDs.ENABLE_ANDROID;

				if(_bool == value)
					return;

				leaderboardIDs.ENABLE_ANDROID = value;

				SetScriptingSymbols("VSLEADERBOARD_ENABLE_ANDROID", value);
			}
		}

		#endif

		#endregion

		#region RATE

		#if VSRATE
		public RateUsSettings rateUsSettings;

		public void SetRateUsSettings(RateUsSettings rateUsSettings) 
		{
			this.rateUsSettings = rateUsSettings;
		}

		public void DisplayRateSettings(bool isOpened) 
		{
			rateUsSettings.isRateUsFoldoutOpened = isOpened;
		}

		#endif
	
		#endregion

		#region SHARE

		#if VS_SHARE

		public ShareSettings shareSettings;

		public void SetShareSettings(ShareSettings shareSettings)
		{
			this.shareSettings = shareSettings;
		}

		public void DisplayShareSettings(bool isOpened) 
		{
			shareSettings.isShareFoldoutOpened = isOpened;
		}

		#endif

		#endregion

		void OnGUI () {

			#if !UNITY_IOS && !UNITY_ANDROID
			EditorWindowUtils.Space (5);
			EditorGUILayout.LabelField("PLEASE SWITCH PLATFORM TO iOS OR ANDROID IN THE BUILD SETTINGS");
			EditorWindowUtils.Space (5);
			return;
			#endif

			scrollPos = EditorGUILayout.BeginScrollView (scrollPos);

			DisplayCommonSettings ();

			DisplayGIFSettings ();

			DislayAdsSettings ();

			DisplayLeaderboardSettings ();

			DisplayRateUsSettings ();

			DisplayShareSettings ();

			EditorWindowUtils.Space (2);

			EditorGUILayout.EndScrollView ();
		}

		#region COMMON SETTINGS

		void DisplayCommonSettings() 
		{
			EditorWindowUtils.Space (2);
			commonAppSettings.isCommonFoldoutOpened = EditorGUILayout.Foldout(commonAppSettings.isCommonFoldoutOpened, "COMMON SETTINGS");

			if(commonAppSettings.isCommonFoldoutOpened) 
			{

				EditorWindowUtils.Space (2);
				ANDROID_AMAZON = EditorGUILayout.BeginToggleGroup (EditorWindowUtils.CreateGUIContentFromDescriptionAndTooltip("ANDROID_AMAZON", "check it if you want to target the Amazon app shop"), ANDROID_AMAZON);
				EditorGUILayout.EndToggleGroup ();

				EditorWindowUtils.CreateLabelField (ref commonAppSettings.iOS_ID, "iOS ID", "The iOS ID of your app"); 

				EditorWindowUtils.CreateLabelField (ref commonAppSettings.amazon_ID, "Amazon ID", "The Amazon ID of your app"); 

				EditorWindowUtils.CreateLabelField (ref commonAppSettings.shareTextBeforeUrl, "Share Text before URL", "The Text you want to display before your UR"); 

				EditorWindowUtils.CreateLabelField (ref commonAppSettings.shareTextAfterUrl, "Share Text after URL", "The Text you want to display after your URL"); 

			}

			if (GUI.changed)
			{
				EditorUtility.SetDirty(commonAppSettings); 

			}
		}

		#endregion

		#region ADS SETTINGS

		void DislayAdsSettings()
		{
			#if APPADVISORY_ADS

			EditorWindowUtils.Space (2);

			adIDs.isAdsFoldoutOpened = EditorGUILayout.Foldout(adIDs.isAdsFoldoutOpened, "ADS SETTINGS");

			if(adIDs.isAdsFoldoutOpened) 
			{
				EditorWindowUtils.Space (2);

				#region SDK BUTTONS

				EditorGUILayout.BeginHorizontal();
				if(GUILayout.Button("GET\nADMOB\nSDK",  GUILayout.Width(100), GUILayout.Height(50)))
				{
					Application.OpenURL("https://github.com/googleads/googleads-mobile-unity");
				}

				if(GUILayout.Button("GET\nCHARTBOOST\nSDK",  GUILayout.Width(100), GUILayout.Height(50)))
				{
					Application.OpenURL("https://answers.chartboost.com/hc/en-us/articles/201219745-Unity-SDK-Download");
				}

				if(GUILayout.Button("GET\nADCOLONY\nSDK",  GUILayout.Width(100), GUILayout.Height(50)))
				{
					Application.OpenURL("https://github.com/AdColony");
				}
				if(GUILayout.Button("GET\nFACEBOOK\nSDK",  GUILayout.Width(100), GUILayout.Height(50)))
				{
					Application.OpenURL("https://developers.facebook.com/docs/unity");
				}

				EditorGUILayout.EndHorizontal();			

				#endregion

				#region ADS OPTIONS TOGGLES

				EditorWindowUtils.Space (2);

				DEBUG = EditorGUILayout.BeginToggleGroup(EditorWindowUtils.CreateGUIContentFromDescriptionAndTooltip("DEBUG", "Check it iif you want to debug rewarded ads"), DEBUG);
				EditorGUILayout.EndToggleGroup();

				EditorWindowUtils.CreateToggleField (ref adIDs.LoadNextSceneWhenAdLoaded,"Load Next Scene When Ad(s) Ready ", "Check it if you want to use a loading scene and launch the game scene when ads are ready");

				EditorWindowUtils.CreateToggleField (ref adIDs.RandomizeNetworks, "Randomize Networks", "Check it if you want to randomize the order of the networks");

				EditorWindowUtils.CreateToggleField(ref adIDs.showInterstitialFirstRun, "Show interstitial at first run", "Check it if you want to display an Interstitial at the first run");

				EditorWindowUtils.CreateToggleField(ref adIDs.showBannerAtRun, "Show banner at run", "Check it if you want to show banner at run");

				EditorWindowUtils.CreateToggleField(ref adIDs.ShowIntertitialAtStart, "Show interstitial at start  [?]", "Check it if you want to display interstitals ads at launch");

				#endregion

				#region MEDIATION NETWORK TOGGLES

				adIDs.isMediationNetworkFoldoutOpened = EditorGUILayout.Foldout(adIDs.isMediationNetworkFoldoutOpened, "MEDIATION NETWORKS");

				if(adIDs.isMediationNetworkFoldoutOpened) 
				{
					EnableChartboost = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Chartboost    [?]", "Check it to use Chartboost. Download the Chartboost SDK here: https://answers.chartboost.com/hc/en-us/"), EnableChartboost);
					EditorGUILayout.EndToggleGroup();

					EnableAdcolony = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Adcolony    [?]", "Check it to use ADColony. Download the Adcolony SDK here: https://github.com/AdColony"), EnableAdcolony);
					EditorGUILayout.EndToggleGroup();

					EnableAdmob = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Admob    [?]", "Check it to use Admob (iAD will be disabled)"), EnableAdmob);
					EditorGUILayout.EndToggleGroup();

					EnableFacebook = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Facebook    [?]", "Check it to use Facebook (iAD will be disabled)"), EnableFacebook);
					EditorGUILayout.EndToggleGroup();
				}

				EditorWindowUtils.Space (2);

				#endregion

				#region ADS OPTION ENUM

				adIDs.interstitialNetworkToShowAtRun = (InterstitialNetwork)EditorGUILayout.EnumPopup ("Interstitial network to show at run", adIDs.interstitialNetworkToShowAtRun, GUILayout.Width (300));

				adIDs.bannerNetwork = (BannerNetwork) EditorGUILayout.EnumPopup("Banner network", adIDs.bannerNetwork, GUILayout.Width(300));


				#if ENABLE_FACEBOOK || ENABLE_ADMOB
				adIDs.childrenPrivacy = (ChildrenPrivacy) EditorGUILayout.EnumPopup("Children's Privacy", adIDs.childrenPrivacy, GUILayout.Width(300));
				#endif

				EditorWindowUtils.Space (2);

				#endregion


				#if ENABLE_FACEBOOK 
				if(adIDs.bannerNetwork == BannerNetwork.Facebook)
				{
					adIDs.FacebookBannerSize = (AudienceNetwork.AdSize) EditorGUILayout.EnumPopup("Facebook Banner Size", adIDs.FacebookBannerSize, GUILayout.Width(300));
					adIDs.FacebookBannerPosition = (FacebookBannerPosition) EditorGUILayout.EnumPopup("Facebook Banner Position", adIDs.FacebookBannerPosition, GUILayout.Width(300));
				}

				#endif

				#if ENABLE_ADMOB
				EditorWindowUtils.CreateToggleField (ref adIDs.lookForGameAds, "Look for Game Ads", "Check it if you want to add Game as one of your ads keyword ");

				if(adIDs.bannerNetwork == BannerNetwork.Admob)
				{
					//adIDs.AdmobBannerSize = (GoogleMobileAds.Api.AdSize) EditorGUILayout.EnumPopup("Admob Banner Size", adIDs.AdmobBannerSize, GUILayout.Width(300));
					adIDs.AdmobBannerPosition = (GoogleMobileAds.Api.AdPosition) EditorGUILayout.EnumPopup("Admob Banner Position", adIDs.AdmobBannerPosition, GUILayout.Width(300));
				}
				#endif

				#region BANNER NETWORKS

				EditorWindowUtils.Space (2);

				adIDs.IsBannerNetworksOpened = EditorGUILayout.Foldout(adIDs.IsBannerNetworksOpened, "BANNER NETWORKS");

				if (adIDs.IsBannerNetworksOpened) 
				{
			#if ENABLE_ADMOB
					adIDs.useAdmobAsBannerNetwork = EditorGUILayout.BeginToggleGroup(new GUIContent("Admob     [?]", "Check it if you want to use Admob as one of your BANNER network"), adIDs.useAdmobAsBannerNetwork);
			EditorGUILayout.EndToggleGroup();
			#endif
					

			#if ENABLE_FACEBOOK
			adIDs.useFacebookAsBannerNetwork = EditorGUILayout.BeginToggleGroup(new GUIContent("Facebook   [?]", "Check it if you want to use Facebook as one of your BANNER network"), adIDs.useFacebookAsBannerNetwork);
			EditorGUILayout.EndToggleGroup();
			#endif
				}

				#endregion

				EditorWindowUtils.Space (2);

				adIDs.IsInterstitialNetworksOpened = EditorGUILayout.Foldout(adIDs.IsInterstitialNetworksOpened, "INTERSTITIAL NETWORKS");

				if (adIDs.IsInterstitialNetworksOpened) 
				{
			#if ENABLE_ADMOB
					adIDs.useAdmobAsInterstitialNetwork = EditorGUILayout.BeginToggleGroup(new GUIContent("Admob   [?]", "Check it if you want to use Admob as one of your INTERSTITIAL network"), adIDs.useAdmobAsInterstitialNetwork);
			EditorGUILayout.EndToggleGroup();
			#endif

			#if CHARTBOOST
					EditorWindowUtils.CreateToggleField (ref adIDs.useChartboostAsInterstitialNetwork, "Chartboost", "Check it if you want to use Chartboost as one of your INTERSTITIAL network");
			#endif

			#if ENABLE_FACEBOOK
			adIDs.useFacebookAsInterstitialNetwork = EditorGUILayout.BeginToggleGroup(new GUIContent("Facebook    [?]", "Check it if you want to use Facebook as one of your INTERSTITIAL network"), adIDs.useFacebookAsInterstitialNetwork);
			EditorGUILayout.EndToggleGroup();
			#endif
				}

				EditorGUILayout.Space();
				EditorGUILayout.Space();

				adIDs.IsVideoNetworksOpened = EditorGUILayout.Foldout(adIDs.IsVideoNetworksOpened, "VIDEO NETWORKS");

				if (adIDs.IsVideoNetworksOpened) 
				{
			#if UNITY_ADS
			t.useUnityAdsAsBannerNetwork = EditorGUILayout.BeginToggleGroup(new GUIContent("Unity Ads   [?]", "Check it if you want to use Unirt Ads as one of your VIDEO network"), t.useUnityAdsAsBannerNetwork);
			EditorGUILayout.EndToggleGroup();
			#endif

			#if ENABLE_ADCOLONY
					EditorWindowUtils.CreateToggleField(ref adIDs.useAdColonyAsBannerNetwork, "AdColony", "Check it if you want to use AdColony as one of your VIDEO network");
			#endif
				}

				EditorGUILayout.Space();
				EditorGUILayout.Space();

				adIDs.IsRewardedVideoNetworksOpened = EditorGUILayout.Foldout(adIDs.IsRewardedVideoNetworksOpened, "REWARDED VIDEO NETWORKS");

				if (adIDs.IsRewardedVideoNetworksOpened) 
				{
			#if ENABLE_ADMOB
					adIDs.useAdmobAsRewardedVideoNetwork = EditorGUILayout.BeginToggleGroup(new GUIContent("Admob  [?]", "Check it if you want to use Admob as one of your REWARDED VIDEO network"), adIDs.useAdmobAsRewardedVideoNetwork);
			EditorGUILayout.EndToggleGroup();
			#endif

			#if UNITY_ADS
			t.useUnityAdsAsRewardedVideoNetwork = EditorGUILayout.BeginToggleGroup(new GUIContent("Unity Ads     [?]", "Check it if you want to use Unity Ads  as one of your REWARDED VIDEO network"), t.useChartboostAsRewardedVideoNetwork);
			EditorGUILayout.EndToggleGroup();
			#endif

			#if CHARTBOOST
					EditorWindowUtils.CreateToggleField (ref adIDs.useChartboostAsRewardedVideoNetwork, "Chartboost", "Check it if you want to use Chartboost as one of your REWARDED VIDEO network");
			#endif

			#if ENABLE_ADCOLONY
					EditorWindowUtils.CreateToggleField(ref adIDs.useAdColonyAsRewardedVideoNetwork, "AdColony", "Check it if you want to use AdColony as one of your REWARDED VIDEO network");

			#endif

				}

				EditorGUILayout.Space();
				EditorGUILayout.Space();


			#if ENABLE_ADMOB



				adIDs.IsAdmobSettingsOpened = EditorGUILayout.Foldout(adIDs.IsAdmobSettingsOpened, "ADMOB");

				if(adIDs.IsAdmobSettingsOpened)
			{
					adIDs.IsAdmobIOSSettingsOpened = EditorGUILayout.Foldout(adIDs.IsAdmobIOSSettingsOpened, "     iOS ADMOB IDs");
					if(adIDs.IsAdmobIOSSettingsOpened)
			{
			EditorGUILayout.LabelField(new GUIContent("Admob Banner Id iOS    [?]", "Please enter your Admob BANNER Id for iOS"));
						adIDs.AdmobBannerIdIOS = EditorGUILayout.TextArea(adIDs.AdmobBannerIdIOS);
			EditorGUILayout.LabelField(new GUIContent("Admob Interstitial Id iOS    [?]", "Please enter your Admob INTERSTITIAL Id for iOS"));
						adIDs.AdmobInterstitialIdIOS = EditorGUILayout.TextArea(adIDs.AdmobInterstitialIdIOS);
			EditorGUILayout.LabelField(new GUIContent("Admob Rewarded Video Id iOS    [?]", "Please enter your Admob REWARDED VIDEO Id for iOS"));
						adIDs.AdmobRewardedVideoIdIOS = EditorGUILayout.TextArea(adIDs.AdmobRewardedVideoIdIOS);
			}
					adIDs.IsAdmobANDROIDSettingsOpened = EditorGUILayout.Foldout(adIDs.IsAdmobANDROIDSettingsOpened, "     ANDROID ADMOB IDs");
					if(adIDs.IsAdmobANDROIDSettingsOpened)
			{
			EditorGUILayout.LabelField(new GUIContent("Admob Banner Id Android    [?]", "Please enter your Admob BANNER Id for ANDROID"));
						adIDs.AdmobBannerIdANDROID = EditorGUILayout.TextArea(adIDs.AdmobBannerIdANDROID);
			EditorGUILayout.LabelField(new GUIContent("Admob Interstitial Id Android    [?]", "Please enter your Admob INTERSTITIAL Id for ANDROID"));
						adIDs.AdmobInterstitialIdANDROID = EditorGUILayout.TextArea(adIDs.AdmobInterstitialIdANDROID);
			EditorGUILayout.LabelField(new GUIContent("Admob Rewarded Video Id Android    [?]", "Please enter your Admob REWARDED VIDEO Id for Android"));
						adIDs.AdmobRewardedVideoIdANDROID = EditorGUILayout.TextArea(adIDs.AdmobRewardedVideoIdANDROID);
			}
					adIDs.IsAdmobAMAZONSettingsOpened = EditorGUILayout.Foldout(adIDs.IsAdmobAMAZONSettingsOpened, "     ANDROID AMAZON IDs");
					if(adIDs.IsAdmobAMAZONSettingsOpened)
			{
			EditorGUILayout.LabelField(new GUIContent("Admob Banner Id Amazon    [?]", "Please enter your Admob BANNER Id for AMAZON - Could be the same as Android"));
						adIDs.AdmobBannerIdAMAZON = EditorGUILayout.TextArea(adIDs.AdmobBannerIdAMAZON);
			EditorGUILayout.LabelField(new GUIContent("Admob Interstitial Id Amazon    [?]", "Please enter your Admob INTERSTITIAL Id for AMAZON - Could be the same as Android"));
						adIDs.AdmobInterstitialIdAMAZON = EditorGUILayout.TextArea(adIDs.AdmobInterstitialIdAMAZON);
			EditorGUILayout.LabelField(new GUIContent("Admob Rewarded Video Id Amazon    [?]", "Please enter your Admob REWARDED VIDEO Id for Amazon"));
						adIDs.AdmobRewardedVideoIdAMAZON = EditorGUILayout.TextArea(adIDs.AdmobRewardedVideoIdAMAZON);
			}
			}
			EditorGUILayout.Space();
			EditorGUILayout.Space();


			#endif


			#if ENABLE_FACEBOOK

			adIDs.IsFacebookSettingsOpened = EditorGUILayout.Foldout(adIDs.IsFacebookSettingsOpened, "FACEBOOK");

			if(adIDs.IsFacebookSettingsOpened) {

			adIDs.IsFacebookIOSSettingsOpened = EditorGUILayout.Foldout(adIDs.IsFacebookIOSSettingsOpened, "     iOS FACEBOOK Placement IDs");
			if(adIDs.IsFacebookIOSSettingsOpened)
			{
			EditorGUILayout.LabelField(new GUIContent("Facebook Banner Placement Id iOS    [?]", "Please enter your Facebook BANNER Placement Id for iOS"));
			adIDs.FacebookBannerIdIOS = EditorGUILayout.TextArea(adIDs.FacebookBannerIdIOS);
			EditorGUILayout.LabelField(new GUIContent("Facebook Interstitial Placement Id iOS    [?]", "Please enter your Facebbok INTERSTITIAL Placement Id for iOS"));
			adIDs.FacebookInterstitialIdIOS = EditorGUILayout.TextArea(adIDs.FacebookInterstitialIdIOS);
			}

			adIDs.IsFacebookANDROIDSettingsOpened = EditorGUILayout.Foldout(adIDs.IsFacebookANDROIDSettingsOpened, "     ANDROID FACEBOOK Placement IDs");
			if(adIDs.IsFacebookANDROIDSettingsOpened)
			{
			EditorGUILayout.LabelField(new GUIContent("Facebook Banner Placement Id Android    [?]", "Please enter your Facebook BANNER Placement Id for ANDROID"));
			adIDs.FacebookBannerIdANDROID = EditorGUILayout.TextArea(adIDs.FacebookBannerIdANDROID);
			EditorGUILayout.LabelField(new GUIContent("Facebook Interstitial Placement Id Android    [?]", "Please enter your Facebook INTERSTITIAL Placement Id for ANDROID"));
			adIDs.FacebookInterstitialIdANDROID = EditorGUILayout.TextArea(adIDs.FacebookInterstitialIdANDROID);
			}

			adIDs.IsFacebookAMAZONSettingsOpened = EditorGUILayout.Foldout(adIDs.IsFacebookAMAZONSettingsOpened, "     AMAZON FACEBOOK Placement IDs");
			if(adIDs.IsFacebookAMAZONSettingsOpened)
			{
			EditorGUILayout.LabelField(new GUIContent("Facebook Banner Placement Id Amazon    [?]", "Please enter your Facebbok BANNER Placement Id for AMAZON"));
			adIDs.FacebookBannerIdAMAZON = EditorGUILayout.TextArea(adIDs.FacebookBannerIdAMAZON);
			EditorGUILayout.LabelField(new GUIContent("Facebook Interstitial Id Amazon    [?]", "Please enter your Facebook INTERSTITIAL Placement Id for AMAZON"));
			adIDs.FacebookInterstitialIdAMAZON = EditorGUILayout.TextArea(adIDs.FacebookInterstitialIdAMAZON);
			}
			}

			#endif


			#if UNITY_ADS

			adIDs.IsUnityAdsSettingsOpened = EditorGUILayout.Foldout(adIDs.IsUnityAdsSettingsOpened, "UNITY ADS");

			if(adIDs.IsUnityAdsSettingsOpened)
			{
			EditorGUILayout.LabelField(new GUIContent("Rewarded video zonèe unity ads    [?]", "If you don't know what it is, have a look to the Unity Ads documentation: https://unityads.unity3d.com"));
			adIDs.rewardedVideoZoneUnityAds = EditorGUILayout.TextField(adIDs.rewardedVideoZoneUnityAds);
			}
			EditorGUILayout.Space();
			EditorGUILayout.Space();

			#endif


				EditorWindowUtils.Space(2);


			#if CHARTBOOST

				adIDs.IsChartboostSettingsOpened = EditorGUILayout.Foldout(adIDs.IsChartboostSettingsOpened, "Chartboost");

				if(adIDs.IsChartboostSettingsOpened)
			{
			
					EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(new GUIContent("Chartboost App ID iOS  [?]", "Find it on Chartboost.com"));
			EditorGUILayout.LabelField(new GUIContent("Chartboost App Signature iOS   [?]", "Find it on Chartboost.com"));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
					adIDs.ChartboostAppIdIOS = EditorGUILayout.TextField(adIDs.ChartboostAppIdIOS);
					adIDs.ChartboostAppSignatureIOS = EditorGUILayout.TextField(adIDs.ChartboostAppSignatureIOS);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(new GUIContent("Chartboost App ID Android  [?]", "Find it on Chartboost.com"));
			EditorGUILayout.LabelField(new GUIContent("Chartboost App Signature Android   [?]", "Find it on Chartboost.com"));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
					adIDs.ChartboostAppIdAndroid = EditorGUILayout.TextField(adIDs.ChartboostAppIdAndroid);
					adIDs.ChartboostAppSignatureAndroid = EditorGUILayout.TextField(adIDs.ChartboostAppSignatureAndroid);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(new GUIContent("Chartboost App ID Amazon  [?]", "Find it on Chartboost.com"));
			EditorGUILayout.LabelField(new GUIContent("Chartboost App Signature Amazon   [?]", "Find it on Chartboost.com"));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
					adIDs.ChartboostAppIdAmazon = EditorGUILayout.TextField(adIDs.ChartboostAppIdAmazon);
					adIDs.ChartboostAppSignatureAmazon = EditorGUILayout.TextField(adIDs.ChartboostAppSignatureAmazon);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			}
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			#endif





			#if ENABLE_ADCOLONY
				adIDs.IsADColonySettingsOpened = EditorGUILayout.Foldout(adIDs.IsADColonySettingsOpened, "ADCOLONY");

				if(adIDs.IsADColonySettingsOpened)
			{

			#if ENABLE_ADCOLONY

			EditorGUILayout.LabelField(new GUIContent("ADColony App ID iOS    [?]", "Please enter your ADColony App ID for iOS"));
					adIDs.AdColonyAppID_iOS = EditorGUILayout.TextField(adIDs.AdColonyAppID_iOS);

			EditorGUILayout.Space();
			EditorGUILayout.Space();


			EditorGUILayout.LabelField(new GUIContent("ADColony App ID ANDROID    [?]", "Please enter your ADColony App ID for ANDROID"));
					adIDs.AdColonyAppID_ANDROID = EditorGUILayout.TextField(adIDs.AdColonyAppID_ANDROID);

			EditorGUILayout.Space();
			EditorGUILayout.Space();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone Key iOS   [?]", "ADColony Interstitial Video Zone Key iOS"));
			EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone ID iOS   [?]", "ADColony Interstitial Video Zone ID iOS"));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
					adIDs.AdColonyInterstitialVideoZoneKEY_iOS = EditorGUILayout.TextField(adIDs.AdColonyInterstitialVideoZoneKEY_iOS);
					adIDs.AdColonyInterstitialVideoZoneID_iOS = EditorGUILayout.TextField(adIDs.AdColonyInterstitialVideoZoneID_iOS);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();

			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone Key Android   [?]", "ADColony Interstitial Video Zone Key Android"));
			EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone ID Android   [?]", "ADColony Interstitial Video Zone OD Android"));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
					adIDs.AdColonyInterstitialVideoZoneKEY_ANDROID = EditorGUILayout.TextField(adIDs.AdColonyInterstitialVideoZoneKEY_ANDROID);
					adIDs.AdColonyInterstitialVideoZoneID_ANDROID = EditorGUILayout.TextField(adIDs.AdColonyInterstitialVideoZoneID_ANDROID);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();





			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone Key iOS   [?]", "ADColony Rewarded Video Zone Key iOS"));
			EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone ID iOS   [?]", "ADColony Rewarded Video Zone ID iOS"));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
					adIDs.AdColonyRewardedVideoZoneKEY_iOS = EditorGUILayout.TextField(adIDs.AdColonyRewardedVideoZoneKEY_iOS);
					adIDs.AdColonyRewardedVideoZoneID_iOS = EditorGUILayout.TextField(adIDs.AdColonyRewardedVideoZoneID_iOS);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();


			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone Key Android   [?]", "ADColony Rewarded Video Zone Key Android"));
			EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone ID Android   [?]", "ADColony Rewarded Video Zone OD Android"));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
					adIDs.AdColonyRewardedVideoZoneKEY_ANDROID = EditorGUILayout.TextField(adIDs.AdColonyRewardedVideoZoneKEY_ANDROID);
					adIDs.AdColonyRewardedVideoZoneID_ANDROID = EditorGUILayout.TextField(adIDs.AdColonyRewardedVideoZoneID_ANDROID);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();


			#endif

			}


			#endif


			#if ENABLE_ADMOB || CHARTBOOST || IAD || ADCOLONY_INTERSTITIAL || ENABLE_FACEBOOK

			EditorGUILayout.Space();
			EditorGUILayout.Space();


			EditorGUILayout.Space();

			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.Space();

			#endif

			
			}

			if (GUI.changed)
			{
				EditorUtility.SetDirty(adIDs); 

			}

			#endif
		}

		#endregion

		#region GIFSETTINGS

		void DisplayGIFSettings() 
		{
			#if VSGIF

			EditorWindowUtils.Space (2);
			gifSettings.isGIFFoldoutOpened = EditorGUILayout.Foldout(gifSettings.isGIFFoldoutOpened, "GIFs SETTINGS");

			if (gifSettings.isGIFFoldoutOpened) 
			{
				EditorWindowUtils.Space (2);

				gifSettings.width = EditorGUILayout.IntSlider("Width", gifSettings.width, 8, 4096, GUILayout.Width(400));

				gifSettings.framePerSecond = EditorGUILayout.IntSlider("Frame Per Second", gifSettings.framePerSecond, 1, 30, GUILayout.Width(400));

				gifSettings.repeat = EditorGUILayout.IntSlider("Repeat", gifSettings.repeat, -1, 10, GUILayout.Width(400));

				gifSettings.quality = EditorGUILayout.IntSlider("Quality", gifSettings.quality, 1, 100, GUILayout.Width(400));

				gifSettings.bufferSize = EditorGUILayout.Slider ("Buffer Size", gifSettings.bufferSize, 0.1f, 10f, GUILayout.Width(400));

				gifSettings.WorkerPriority = (MyThreadPriority)EditorGUILayout.EnumPopup ("Worker Priority", gifSettings.WorkerPriority, GUILayout.Width (300));
			}

			if (GUI.changed)
			{
				EditorUtility.SetDirty(gifSettings); 

			}

			#endif
		}

		#endregion

		#region LEADERBOARD SETTINGS

		void DisplayLeaderboardSettings() 
		{
			#if APPADVISORY_LEADERBOARD

			EditorWindowUtils.Space (2);
			leaderboardIDs.isLeaderboardIDsFoldoutOpened = EditorGUILayout.Foldout(leaderboardIDs.isLeaderboardIDsFoldoutOpened, "LEADERBOARD SETTINGS");

			if (leaderboardIDs.isLeaderboardIDsFoldoutOpened) 
			{
				if(leaderboardIDs.FIRST_TIME)
				{
					Debug.Log("*********** APP_ADVISORY_FIRST_TIME_LEADERBORD ***********");

					PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, SetString("VSLEADERBOARD"));

					PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, SetString("VSLEADERBOARD"));

					leaderboardIDs.FIRST_TIME = false;
				}

				#region BUTTON

				EditorWindowUtils.Space(2);

				EditorGUILayout.BeginHorizontal();
				if(GUILayout.Button("GET\nGoogle Play Game\nSDK",  GUILayout.Width(150), GUILayout.Height(50)))
				{
					Application.OpenURL("https://github.com/playgameservices/play-games-plugin-for-unity");
				}
				EditorGUILayout.EndHorizontal();

				#endregion

				EditorWindowUtils.Space(2);

				Enable_iOS = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable iOS Game Center   [?]", "Activate if you want to use Game Center Leaderboard"), Enable_iOS);
				EditorGUILayout.EndToggleGroup();

				Enable_Android = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Android Google Play Game Services   [?]", "Activate if you want to use Google Play Game Services Leaderboard"), Enable_Android);
				EditorGUILayout.EndToggleGroup();

			#if VSLEADERBOARD_ENABLE_IOS
			var stringIos = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);
			if(!stringIos.Contains("APPADVISORY_LEADERBOARD"))
			{
			stringIos = "APPADVISORY_LEADERBOARD" + ";" + stringIos;

			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,stringIos);
			}
			#endif

			#if VSLEADERBOARD_ENABLE_ANDROID
			var stringAndroid = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);
			if(!stringAndroid.Contains("APPADVISORY_LEADERBOARD"))
			{
			stringAndroid = "APPADVISORY_LEADERBOARD" + ";" + stringAndroid;

			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,stringAndroid);
			}
			#endif

				EditorWindowUtils.Space(2);

			#if VSLEADERBOARD_ENABLE_IOS
			EditorGUILayout.LabelField(new GUIContent("Game Center Leaderboard Id   [?]", "Find it on Itunes Connect console"));
			leaderboardIDs.LEADERBOARDID_IOS = EditorGUILayout.TextField(leaderboardIDs.LEADERBOARDID_IOS);
			#endif

				EditorWindowUtils.Space(2);

			#if VSLEADERBOARD_ENABLE_ANDROID
			EditorGUILayout.LabelField(new GUIContent("Google Play Game Leaderboard Id   [?]", "Find it on Google Play Game console"));
			leaderboardIDs.LEADERBOARDID_ANDROID = EditorGUILayout.TextField(leaderboardIDs.LEADERBOARDID_ANDROID);
			#endif
			}

			if (GUI.changed)
			{
				EditorUtility.SetDirty(leaderboardIDs); 

			}

			#endif		
		}

		#endregion

		#region RATE US SETTINGS

		void DisplayRateUsSettings() 
		{
			#if VSRATE

			EditorWindowUtils.Space (2);
			rateUsSettings.isRateUsFoldoutOpened = EditorGUILayout.Foldout(rateUsSettings.isRateUsFoldoutOpened , "RATE US SETTINGS");

			if (rateUsSettings.isRateUsFoldoutOpened) 
			{

				EditorWindowUtils.Space (1);

				EditorGUILayout.LabelField("Number of Stars to Accept Review");

				rateUsSettings.numberOfStarsToAcceptReview = EditorGUILayout.Slider(rateUsSettings.numberOfStarsToAcceptReview, 1f, 5f, GUILayout.Width(250)); 

				EditorWindowUtils.Space(1);

				EditorWindowUtils.CreateLabelField(ref rateUsSettings.email, "email", "The email adress");

				EditorWindowUtils.CreateLabelField(ref rateUsSettings.subject, "subject", "The subect of the email");

				EditorWindowUtils.CreateLabelField(ref rateUsSettings.body, "body", "The body of the email");
			}

			if (GUI.changed)
			{
				EditorUtility.SetDirty(rateUsSettings); 

			}

			#endif
		}

		#endregion

		#region SHARE SETTINGS

		void DisplayShareSettings() 
		{
			#if VS_SHARE

			EditorWindowUtils.Space (2);
			shareSettings.isShareFoldoutOpened = EditorGUILayout.Foldout(shareSettings.isShareFoldoutOpened , "SHARE SETTINGS");

			if (shareSettings.isShareFoldoutOpened) 
			{
				EditorWindowUtils.Space (2);

				EditorWindowUtils.CreateToggleField(ref shareSettings.androidForceSDCardPermission, "Android Force SDCard Permission", "Check it to force the SD Card Permission on Android");

				EditorWindowUtils.CreateToggleField(ref shareSettings.showButtonShareWhenSceneRestartIfScreenshotAvailable, "Show Share Button When Scene Restart If Screenshot Available", "Check it to show the share button when the scene restarts ff the screenshot is available");

				shareSettings.state = (ButtonShareState) EditorGUILayout.EnumPopup("Share Button State", shareSettings.state, GUILayout.Width(300));
			}

			if (GUI.changed)
			{
				EditorUtility.SetDirty(shareSettings); 

			}

			#endif
		}

		#endregion


		#region SCRIPTING SYMBOLS

		void SetScriptingSymbols(string symbol, bool isActivate)
		{
			SetScriptingSymbol(symbol, BuildTargetGroup.Android, isActivate);

			#if UNITY_5 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3_OR_NEWER
			SetScriptingSymbol(symbol, BuildTargetGroup.iOS, isActivate);
			#else
			SetScriptingSymbol(symbol, BuildTargetGroup.iPhone, isActivate);
			#endif 
		}
			
		void SetScriptingSymbol(string symbol, BuildTargetGroup target, bool isActivate)
		{
			var s = PlayerSettings.GetScriptingDefineSymbolsForGroup(target);

			if(isActivate && (s.Contains(symbol) || s.Contains(symbol + ";")))
				return;

			s = s.Replace(symbol + ";","");

			s = s.Replace(symbol,"");

			if(isActivate)
				s = symbol + ";" + s;

			PlayerSettings.SetScriptingDefineSymbolsForGroup(target,s);
		}


		string SetString(string stringIOS)
		{
			stringIOS = stringIOS.Replace(stringIOS + ";","");

			stringIOS = stringIOS.Replace(stringIOS,"");

			return stringIOS;
		}

		#endregion


	}
}