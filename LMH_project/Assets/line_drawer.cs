using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class line_drawer : MonoBehaviour
{
    [SerializeField] GameObject startPos;
    [SerializeField] GameObject endPos;
    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.SetPosition(0, startPos.transform.position);
        lineRenderer.SetPosition(1, endPos.transform.position);
    }
}
