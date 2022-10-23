using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class GameManger : MonoBehaviour
{

	sim_scene_1 problem ; 

	NextScene  nextScene ;
	FailScene  failScene;
	EndScene   endScene;

	void Awake(){
		nextScene = FindObjectOfType<NextScene>();
		failScene = FindObjectOfType<FailScene>();
		endScene  = FindObjectOfType<EndScene>();
	}

    void Start()
    {
        
    }

    void Update()
    {
		// isPass
		if (problem.isPass){

			problem.gameObject.SetActive(false);
			nextScene.gameObject.SetActive(true);
			failScene.gameObject.SetActive(false);
			endScene.gameObject.SetActive(false);

		}	
		else {

			problem.gameObject.SetActive(false);
			nextScene.gameObject.SetActive(false);
			failScene.gameObject.SetActive(true);
			endScene.gameObject.SetActive(false);

		}	

		// isComplete ?
		if (problem.isComplete){

			problem.gameObject.SetActive(false);
			nextScene.gameObject.SetActive(false);
			failScene.gameObject.SetActive(false);
			endScene.gameObject.SetActive(true);

			endScene.ShowFinalText();
		}
    }
	
	public void OnReplayLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) ;
	}
}
