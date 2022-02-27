using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
    public int hasFlower;

    private void Start()
    {
        hasFlower = 0;
    }

    public void PickupFlower()
    {
        hasFlower++;
    }

    public int RemoveAllFlowers()
    {
        int tmp = hasFlower;
        hasFlower = 0;
        return tmp;
    }

    public int checkFlower()
    {
        return hasFlower;
    }
}
