using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class sim_scene_1 : MonoBehaviour
{
    [SerializeField] GameObject footValve;
    [SerializeField] GameObject forceMan;
    [SerializeField] GameObject pivotPoint;
    [SerializeField] TextMeshProUGUI displayDistance;
    [SerializeField] TextMeshProUGUI resultText;
    Rigidbody2D footValveRigidBody;
    float dist = 0f;
    float xdist = 0f;
    bool startedSimulation = false;
    bool correct = false;

	// wave 
	public bool isComplete ;
	public bool isPass;
	
    // Start is called before the first frame update
    void Start()
    {
        footValveRigidBody = footValve.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xdist = (forceMan.transform.position.x - pivotPoint.transform.position.x - Mathf.Cos(70 * Mathf.PI / 180));
        dist = xdist / (Mathf.Cos(20 * Mathf.PI / 180));

        displayDistance.text = "Distance from forceman X is " + xdist.ToString() + " aka real dist = " + dist.ToString() + " correction " + correct;
        // displayDistance.text = "Distance from forceman X to pivot point is" + xdist.ToString(); 

        if(Input.GetKeyDown("space") && !startedSimulation)
        {
            if(!startedSimulation){
                if (dist > 1.827f && dist < 2.020f){
                    correct = true;
                }
            }
            startedSimulation = true;
            forceMan.GetComponent<forcemanMovement>().enabled = false;
            if(!correct){
                footValveRigidBody.bodyType = RigidbodyType2D.Dynamic;
                footValveRigidBody.gravityScale = 0;
            }

            // wait 3 sec to show result screen
            StartCoroutine(waiter());
            
        }
    }

    IEnumerator waiter(){
        yield return new WaitForSecondsRealtime(4);
        if(correct){
                resultText.text = "Correct!";
            } else {
                resultText.text = "Failed";
            }
        yield return new WaitForSecondsRealtime(1);
        if(!correct){
            SceneManager.LoadScene("level_1"); 
        }
    }
}
