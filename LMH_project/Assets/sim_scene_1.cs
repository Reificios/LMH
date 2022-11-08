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
    [SerializeField] GameObject invisBarrier;
    [SerializeField] GameObject arrow;
    Rigidbody2D footValveRigidBody;
    GameObject levelPassScreen;
    GameObject levelFailScreen;
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
        levelPassScreen = GameObject.Find("NextScrene");
        levelFailScreen = GameObject.Find("FailScene");
        levelPassScreen.SetActive(false);
        levelFailScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        xdist = (forceMan.transform.position.x - pivotPoint.transform.position.x - Mathf.Cos(70 * Mathf.PI / 180));

        displayDistance.text = "Distance from pivot point to forceman in X-Axis is " + xdist.ToString();
        // displayDistance.text = "Distance from forceman X to pivot point is" + xdist.ToString(); 
    }

    public void startSim(){
        arrow.SetActive(false);
            invisBarrier.SetActive(false);
            if(!startedSimulation){
                if (xdist > 1.827f && xdist < 2.020f){
                    correct = true;
                }
                if (xdist > 2.020f){
                    forceMan.GetComponent<Rigidbody2D>().mass = 40;
                } else {
                    forceMan.GetComponent<Rigidbody2D>().mass = 15;
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

    IEnumerator waiter(){
        yield return new WaitForSecondsRealtime(3);
        if(!correct){
            levelFailScreen.SetActive(true);
        } else {
            levelPassScreen.SetActive(true);
        }
    }
}
