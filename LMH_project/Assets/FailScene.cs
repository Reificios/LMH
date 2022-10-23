using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using TMPro ;
using UnityEngine.SceneManagement ;

public class FailScene : MonoBehaviour

{
	public void LoadCurrentScene(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
