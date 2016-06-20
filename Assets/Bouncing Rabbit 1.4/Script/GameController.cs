using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	private int score; //For count score
	public Text scoreText; //For show score
	public Text newHighScoreText; //For show when player got high score
	public Text gameoverScoreText; //For show score when gameover
	public Text gameoverHighscoreText; //For show highscore when gameover
	public Canvas gameoverGUI; //For show GUI of gameover
	public Canvas ingameGUI;  //For show GUI when play (pause button ,scoreText)
	public Canvas pauseGUI; //For show GUI when pause
	public static GameController instance; //Instance

	//Ads
	public Text debugText;
	public Text debugText2;
	public int i;
	public int adsShow;
	public string gameId; // Set this value from the inspector.
	public bool enableTestMode = true;
	public bool adsShowing = true;

	void Awake(){
		instance = this;

		CheckPlayTime ();

//		if (Advertisement.isSupported) { // If runtime platform is supported...
//			Advertisement.Initialize(gameId, enableTestMode); // ...initialize.
//		}
	}

	void CheckPlayTime()
	{
		if (PlayerPrefs.HasKey ("PlayTime") == false) {
			PlayerPrefs.SetInt("PlayTime",1);
			i=1;
		}

		debugText.text = "Play Time " + i;

		i = PlayerPrefs.GetInt ("PlayTime");
		
		i++;
		
		PlayerPrefs.SetInt("PlayTime",i);

		debugText.text = "Play Time " + i;
	}

	public void addScore(){
		score++; //Plus score
		scoreText.text = score.ToString (); //Change scoreText to current score
	}

	public void GameOver(){

		CheckHighScore ();
		gameoverScoreText.text = score.ToString(); //Set score to gameoverScoreText
		gameoverHighscoreText.text = PlayerPrefs.GetInt ("highscore", 0).ToString(); //Set high score to gameoverHighscoreText
		gameoverGUI.gameObject.SetActive(true); //Show gameover's GUI
		ingameGUI.gameObject.SetActive(true); //Hide ingame's GUI

		//ads here
		//interstitial.ShowInterstitial ();
		adsShow = PlayerPrefs.GetInt ("PlayTime");
		debugText2.text = "Play Time " + adsShow;
		if (adsShow > 5 && adsShowing) 
		{
			PlayerPrefs.SetInt("PlayTime",1);
			adsShowing = false;
			return;
			// Wait until Unity Ads is initialized,
			//  and the default ad placement is ready.
		}

	}

	public void CheckHighScore(){
		if( score > PlayerPrefs.GetInt("highscore",0) ){ //If score > highscore
			PlayerPrefs.SetInt("highscore",score); //Save a new highscore
			newHighScoreText.gameObject.SetActive(true); //Enable newHighScoreText
		}
	}

	public void Pause(){
		Time.timeScale = 0; //Change timeScale to 0
		pauseGUI.gameObject.SetActive (true); //Show pauseGUI
	}

	public void Resume(){
		Time.timeScale = 1; //Change timeScale to 1
		pauseGUI.gameObject.SetActive (false); //Hide pauseGUI
	}
}
