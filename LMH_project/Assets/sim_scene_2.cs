using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class sim_scene_2 : MonoBehaviour
{
    [SerializeField] GameObject map;
    [SerializeField] GameObject forceMan;
    // [SerializeField] GameObject invisforceMan;
    [SerializeField] GameObject pivotPoint;
    [SerializeField] TextMeshProUGUI displayDistance;
    [SerializeField] TextMeshProUGUI resultText;
    Rigidbody2D mapRigidBody;
    Rigidbody2D invisRigidBody;
    float xdist = 0f;
    bool startedSimulation = false;
    bool correct = false;
    // Start is called before the first frame update
    void Start()
    {
        mapRigidBody = map.GetComponent<Rigidbody2D>();
        // invisRigidBody = invisforceMan.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xdist = forceMan.transform.position.x - pivotPoint.transform.position.x;

        displayDistance.text = "Distance from forceman X is " + xdist.ToString();
        // displayDistance.text = "Distance from forceman X to pivot point is" + xdist.ToString(); 

        if(Input.GetKeyDown("space") && !startedSimulation)
        // if(!startedSimulation)
        {
            if(!startedSimulation){
                if (xdist > 6.107f && xdist < 6.75f){
                    correct = true;
                }
            }
            startedSimulation = true;
            forceMan.GetComponent<forcemanMovement>().enabled = false;
            if(!correct){
                // invisRigidBody.bodyType = RigidbodyType2D.Dynamic;
                mapRigidBody.bodyType = RigidbodyType2D.Dynamic;
                // mapRigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
                mapRigidBody.gravityScale = 0;
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
            SceneManager.LoadScene("level_2"); 
        }
    }
}