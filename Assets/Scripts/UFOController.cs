using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public float rotate_speed = 40f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, rotate_speed * Time.deltaTime, 0.0f, Space.Self);
    }
}
