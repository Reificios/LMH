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
    Rigidbody2D mapRigidBody;
    Rigidbody2D counterWeighRigidBody;
    GameObject beam;
    bool startedSimulation = false;
    bool correct = false;
    bool maxPos = false;
    float xdist;
    float xdistFinal;
    float inputForce;
    float wrongMagnitude = 0;

    void Start()
    {
        beam = map.transform.GetChild(0).gameObject;
        mapRigidBody = beam.GetComponent<Rigidbody2D>();
        counterWeighRigidBody = counterWeigth.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xdist = Mathf.Abs(forceMan.transform.position.x - pivotPoint.transform.position.x);
        displayDistance.text = "Distance from forceman X is " + xdist.ToString();

        if(Input.GetKeyDown("space") && !startedSimulation){
            if(!startedSimulation){
                inputForce = float.Parse(inputField.GetComponent<InputField>().text);
                if (inputForce != 400) {
                    // fail
                } else {
                    if (xdist < 4.725 & xdist > 4.275) {
                        correct = true;
                        // pass
                    }
                }
            forceMan.GetComponent<forcemanMovement>().enabled = false;
            startedSimulation = true;
            xdistFinal = xdist;
            }
        }
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
}
