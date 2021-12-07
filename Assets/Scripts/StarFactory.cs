using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StarFactory : MonoBehaviour
{
    public Transform player;
    public GameObject star;
    public GameObject star_holder;
    public int count;
    public float distance;

    // Stars are done by creating n spheres around the player character
    // These stars are then rendered by a seperate camera which is drawn behind
    // the main camera so they appear behind the terrain and appear far away


    // Start is called before the first frame update
    void Start()
    {
        double theta, phi = 0;
        for (int i = 0; i < count; i++)
        {
            // Generate a point on a sphere
            theta = 2 * Math.PI * UnityEngine.Random.Range(0.0f, 1.0f);
            phi = Math.Acos(2 * UnityEngine.Random.Range(0.0f, 1.0f) - 1.0);
            Vector3 pos = new Vector3();
            pos.x = (float)(Math.Cos(theta) * Math.Sin(phi));
            pos.y = (float)(Math.Sin(theta) * Math.Sin(phi));
            pos.z = (float)Math.Cos(phi);
            // Instance a star at that point
            pos += transform.position;
            GameObject new_star = Instantiate(star, pos, Quaternion.identity);
            new_star.transform.parent = gameObject.transform;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Make the stars follow the player to prevent parralax
        // Stars are not a child of the player to prevent rotation
        transform.position = player.position;
    }
}
