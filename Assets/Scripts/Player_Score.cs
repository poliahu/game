using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {

	private float timeLeft = 75;
	public static int playerScore = 0;
	public GameObject timeLeftUI;
	public GameObject playerScoreUI;

	void Start () {
		
		timeLeftUI = GameObject.Find("TimeLeft");
		playerScoreUI = GameObject.Find("Score");
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + timeLeft);
		playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
		if (timeLeft < 0.1f) {
			SceneManager.LoadScene ("Platformer_1");
		}	
	}
	void OnTriggerEnter2D (Collider2D trig){
		if (trig.gameObject.name == "LevelEnd") {
			CountScore ();
		}
		if (trig.gameObject.name == "Coin") {
			playerScore += 10;
			Destroy (trig.gameObject);
		}
	}
		void CountScore () {
			playerScore = playerScore + (int)(timeLeft * 10);
			Debug.Log (playerScore);
		}
	}




