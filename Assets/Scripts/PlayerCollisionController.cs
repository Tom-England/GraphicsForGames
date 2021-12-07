using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    public UIController uIController;

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "HouseVolume")
        {
            uIController.direction = 1;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.name == "HouseVolume")
        {
            uIController.direction = -1;
        }
    }
}
