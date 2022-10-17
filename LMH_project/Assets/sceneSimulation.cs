using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sceneSimulation : MonoBehaviour
{
    [SerializeField] GameObject obj1;
    // [SerializeField] GameObject obj2;
    // [SerializeField] GameObject obj3;
    [SerializeField] TextMeshProUGUI startStatusText;

    Rigidbody2D rigid1;
    // Rigidbody2D rigid2;
    // Rigidbody2D rigid3;


    void Start() {
        rigid1 = obj1.GetComponent<Rigidbody2D>();
        // rigid2 = obj2.GetComponent<Rigidbody2D>();
        // rigid3 = obj3.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            rigid1.bodyType = RigidbodyType2D.Dynamic;
            rigid1.gravityScale = 0;
            startStatusText.text = "Simulation Status : Started";
        }
    }
}
