using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour

{
	public void LoadNextScene(){
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		int NextSceneIndex  = currentSceneIndex + 1;

		SceneManager.LoadScene(NextSceneIndex);
	}

	public void quitGame(){
		Application.Quit();
	}
}
