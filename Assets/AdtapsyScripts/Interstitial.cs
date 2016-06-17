using UnityEngine;
using System.Collections;

public class Interstitial : MonoBehaviour {

	void Start () {
		//AdTapsy.ShowInterstitial();         
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			/* AdTapsy.CloseAd returns whether an interstitial ad was closed.
		* If so, don't do anything, else handle your events
		*/
			bool adClosed = AdTapsy.CloseAd();
			if(!adClosed){
				/* Handle your game lifecycle here -
			 return to previous scene, exit game, close popup, etc. */
			}
		}
	}

	public void ShowInterstitial() {
		if (AdTapsy.IsInterstitialReadyToShow()) {
			Debug.Log("Ad is ready to be shown");
			AdTapsy.ShowInterstitial();
		} else {
			Debug.Log("Ad is not ready to be shown");
		}
	}                                                               
	
	void OnApplicationPause(bool pauseStatus) {   
		if (!pauseStatus) {                                     
			AdTapsy.ShowInterstitial();                   
		}                                                              
	}
}
