using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 5f;
    Vector3 rotation = new Vector3(0,0,1);

    void Update()
    {
        transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
    }
}
