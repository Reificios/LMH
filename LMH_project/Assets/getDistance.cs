using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class getDistance : MonoBehaviour
{
    [SerializeField] GameObject COM;
    [SerializeField] GameObject currentObject;
    [SerializeField] TextMeshProUGUI displayText;
    float value;
    Rigidbody2D myrigidbody;

    void Start() {
        myrigidbody = currentObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        value = currentObject.transform.position.x - COM.transform.position.x;
        displayText.text = "Distance from pivot point of " + currentObject.name +": " + Math.Abs(value).ToString("0.000") + " with force of " + myrigidbody.gravityScale * myrigidbody.mass;
    }
}
