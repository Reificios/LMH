using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScene : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI congratText ;

	public void ShowFinalText(){
		congratText.text = "Congratulation!!!\n You already clear the game";
	}
        
}
