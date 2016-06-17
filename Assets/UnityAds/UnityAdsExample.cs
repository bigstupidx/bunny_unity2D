using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAdsExample : MonoBehaviour
{
	public Text debugText;

	void Start()
	{
		ShowAd ();
	}
	public void ShowAd()
	{
		if (Advertisement.IsReady ()) {
			Advertisement.Show ();
			debugText.text = "show";

		} else {
			print("failed");
			debugText.text = "failed";
		}
	}
}
