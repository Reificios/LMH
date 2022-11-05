using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelMeter : MonoBehaviour
{
    void Start()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        this.GetComponent<Slider>().value = y;
    }
}
