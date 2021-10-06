using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

	public void ChooseCharacter(int characterIndex) {
		PlayerPrefs.SetInt ("SelectedCharacter", characterIndex);
		print ("The player you have selected is " + characterIndex);
	}

	public void LoadScene () {
		SceneManager.LoadScene ("Platformer_1");
	}
}