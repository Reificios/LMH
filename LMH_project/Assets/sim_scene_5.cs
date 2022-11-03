using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sim_scene_5 : MonoBehaviour
{
    [SerializeField] GameObject cart;
    [SerializeField] GameObject vase;
    [SerializeField] GameObject inputField;
    Rigidbody2D cartRigidBody;
    Rigidbody2D vaseRigidBody;
    GameObject endingScreen;
    GameObject levelFailScreen;
    bool startedSimulation = false;
    float inputForce;
    float cartAccel = 0;
    float cartSpeed = 0;
    float vaseSpeed = 0;
    float vaseRotation = 0;
    bool correct = false;

 
    // Start is called before the first frame update
    void Start()
    {
        cartRigidBody = cart.GetComponent<Rigidbody2D>();
        vaseRigidBody = vase.GetComponent<Rigidbody2D>();
        endingScreen = GameObject.Find("EndScene");
        levelFailScreen = GameObject.Find("FailScene");
        endingScreen.SetActive(false);
        levelFailScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(startedSimulation){
            if(inputForce < 217.55f){
                cartAccel = (inputForce/140);
                cartSpeed += cartAccel * Time.deltaTime;
                vaseSpeed += cartAccel * Time.deltaTime;
                // show that failed too low
            } else {
                cartAccel = (inputForce/140);
                if (inputForce < 240.45f){
                    correct = true;
                    cartSpeed += cartAccel * Time.deltaTime;
                    vaseSpeed += cartAccel * Time.deltaTime;
                } else if (cartAccel < 3.924f){
                    vaseRotation += (39.24f - 24 * cartAccel) * Time.deltaTime;
                    vaseRigidBody.rotation = vaseRotation;
                    cartSpeed += cartAccel * Time.deltaTime;
                    if(vaseRotation < 20){
                    vaseSpeed += cartAccel * Time.deltaTime;
                    }
                } else {
                    vaseRotation += (39.24f - 24 * cartAccel) * Time.deltaTime;
                    vaseRigidBody.rotation = vaseRotation;
                    cartSpeed += cartAccel * Time.deltaTime;
                    if(vaseRotation < 20){
                        vaseSpeed += 3.924f * Time.deltaTime;
                    }
                }
            }
            cartRigidBody.velocity = Vector2.left * cartSpeed;
            vaseRigidBody.velocity = Vector2.left * vaseSpeed;
        }
    }

    public void startSim(){
        // Debug.Log(inputField.GetComponent<InputField>().text);
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
            endingScreen.SetActive(true);
        }
    }
}
