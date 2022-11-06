using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sim_scene_3 : MonoBehaviour
{
    [SerializeField] GameObject counterWeigth;
    [SerializeField] GameObject map;
    [SerializeField] GameObject forceMan;
    // [SerializeField] GameObject invisforceMan;
    [SerializeField] GameObject pivotPoint;
    [SerializeField] TextMeshProUGUI displayDistance;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject invisBarrier;
    Rigidbody2D mapRigidBody;
    Rigidbody2D counterWeighRigidBody;
    GameObject beam;
    GameObject levelPassScreen;
    GameObject levelFailScreen;
    InputField inputFieldReal;
    bool startedSimulation = false;
    bool correct = false;
    bool maxPos = false;
    float xdist;
    float xdistFinal;
    float inputForce;
    float wrongMagnitude = 0;
    bool isNum;

    void Start()
    {
        beam = map.transform.GetChild(0).gameObject;
        mapRigidBody = beam.GetComponent<Rigidbody2D>();
        counterWeighRigidBody = counterWeigth.GetComponent<Rigidbody2D>();
        levelPassScreen = GameObject.Find("NextScrene");
        levelFailScreen = GameObject.Find("FailScene");
        levelPassScreen.SetActive(false);
        levelFailScreen.SetActive(false);
        inputFieldReal = inputField.GetComponent<InputField>();
    }

    void Update()
    {
        xdist = Mathf.Abs(forceMan.transform.position.x - pivotPoint.transform.position.x);
        displayDistance.text = "Distance from joint to forceman in X-Axis is " + xdist.ToString();

        if(startedSimulation){
            if(!correct && !maxPos){
                wrongMagnitude = (xdistFinal - 4.5f) * Time.deltaTime;
                counterWeighRigidBody.transform.Translate(Vector3.up * wrongMagnitude * 0.5f);
                mapRigidBody.transform.RotateAround(pivotPoint.transform.position, Vector3.forward, wrongMagnitude * 3.5f);
                if(counterWeighRigidBody.transform.position.y >= 0.5 || mapRigidBody.transform.rotation.z < -0.22f){
                    maxPos = true;
                }
            }
        }

    }

    public void startSim(){
        // Debug.Log(inputField.GetComponent<InputField>().text);
        isNum = float.TryParse(inputField.GetComponent<InputField>().text, out inputForce);
        if(!isNum){
            return;
        }
        invisBarrier.SetActive(false);
        inputFieldReal.interactable = false;
            if (inputForce != 500) {
                levelFailScreen.SetActive(true);
                return;
            } else {
                if (xdist < 4.725 & xdist > 4.275) {
                        correct = true;
                }
            }
            forceMan.GetComponent<forcemanMovement>().enabled = false;
            startedSimulation = true;
            xdistFinal = xdist;
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
