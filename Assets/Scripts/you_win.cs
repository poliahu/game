using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class you_win : MonoBehaviour 
{
	[SerializeField]private string loadlevel;

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("triggered");
			if (other.CompareTag("Player"))
		{
			Debug.Log ("should load level");
			SceneManager.LoadScene (loadlevel);
		}
	}
}


