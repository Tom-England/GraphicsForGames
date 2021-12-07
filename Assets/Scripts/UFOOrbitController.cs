using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOOrbitController : MonoBehaviour
{

    float speed = 1f;
    float t;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        float x = Mathf.Cos(t);
        float y = Mathf.Sin(t);
        float z = 0;
        transform.localPosition = new Vector3(x * 10, y * 10, z);
    }
}
