using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class TestAnalytics : MonoBehaviour {

	int totalPotions = 5;
	int totalCoins = 100;
	string weaponID = "Weapon_102";

	void Start () {
		Analytics.CustomEvent("gameOver", new Dictionary<string, object>
		                      {
			{ "potions", totalPotions },
			{ "coins", totalCoins },
			{ "activeWeapon", weaponID }
		});
	}

	void Update () {
	
	}
}
