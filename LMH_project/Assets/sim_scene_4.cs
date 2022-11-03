using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sim_scene_4 : MonoBehaviour
{
    [SerializeField] GameObject box;
    [SerializeField] GameObject pivotPoint;
    [SerializeField] GameObject inputField;
    Rigidbody2D boxRigidBody;
    GameObject levelPassScreen;
    GameObject levelFailScreen;
    bool startedSimulation = false;
    float inputForce;
    float boxSpeed = 0;
    float boxRotation = 0;
    bool correct = false;

 
    // Start is called before the first frame update
    void Start()
    {
        boxRigidBody = box.GetComponent<Rigidbody2D>();
        levelPassScreen = GameObject.Find("NextScrene");
        levelFailScreen = GameObject.Find("FailScene");
        levelPassScreen.SetActive(false);
        levelFailScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(startedSimulation){
            if(inputForce < 186.39f){
                // show that its lower than acceptable answer
                // UI
            } else if (inputForce < 206.01f) {
                correct = true;
            }
            else if (boxRotation != -90){
                boxRotation -= (0.3f * inputForce - 58.86f) / 0.2926f * Time.deltaTime;
                boxRigidBody.rotation = boxRotation;
                if(boxRotation < -90){
                    boxRotation = -90;
                }
            }
            if(boxRotation != -90){
                boxSpeed += inputForce/20 * Time.deltaTime;
            }
            boxRigidBody.velocity = Vector2.right * boxSpeed;
        }
    }

    public void startSim(){
        Debug.Log(inputField.GetComponent<InputField>().text);
        inputForce = float.Parse(inputField.GetComponent<InputField>().text);
        startedSimulation = true;
        inputField.GetComponent<InputField>().interactable = false;
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
