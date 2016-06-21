using UnityEngine;
using System.Collections;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AppodealTest : MonoBehaviour {

	#if UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE
	string appKey = "";
	#elif UNITY_ANDROID
	string appKey = "402ecb7cadd155a1541788881caa14907b5d3502de55b6ff";
	#elif UNITY_IPHONE
	string appKey = "722fb56678445f72fe2ec58b2fa436688b920835405d3ca6";
	#else
	string appKey = "";
	#endif

	void Start () {
		Appodeal.initialize (appKey, Appodeal.INTERSTITIAL | Appodeal.BANNER);
		BannerAds ();
	}

	public void BannerAds()
	{
		Debug.Log("BannerAds is showing");
		Appodeal.show (Appodeal.BANNER_BOTTOM);
	}

	public void InterstitialAds()
	{
		Appodeal.show (Appodeal.INTERSTITIAL);
	}
}
