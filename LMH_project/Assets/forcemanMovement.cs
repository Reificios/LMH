using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcemanMovement : MonoBehaviour
{
    [SerializeField] GameObject forceman;
    [SerializeField] float movespeed = 5;
    Rigidbody2D myrigidbody;
    int dir;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = forceman.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = 0;
        if(Input.GetKey(KeyCode.D)){
            dir = 1;
        } else if(Input.GetKey(KeyCode.A)){
            dir = -1;
        }
        Vector2 playerVelocity = new Vector2 (dir * movespeed, myrigidbody.velocity.y);
        myrigidbody.velocity = playerVelocity;
    }
}
