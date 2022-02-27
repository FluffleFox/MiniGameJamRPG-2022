using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlower : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, .5f);
        other.gameObject.GetComponent<FlowerController>().PickupFlower();
    }
}
