using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanController : MonoBehaviour
{
    public Vector3 start;
    public Vector3 end;
    public float total_time;
    float current_time;

    void Start()
    {
        transform.position = start;
        current_time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        current_time += Time.deltaTime;
        if (current_time > total_time)
        {
            transform.position = start;
            current_time = 0f;
        }
        else
        {
            transform.position = Vector3.Lerp(start, end, current_time / total_time);
        }

    }
}
