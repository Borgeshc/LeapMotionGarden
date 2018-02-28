using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeed : MonoBehaviour
{
    public GameObject seed;

    public void Activated()
    {
        Seed checkSeed = gameObject.GetComponentInChildren<Seed>();
        if (checkSeed == null)
        {
            GameObject newSeed = Instantiate(seed);
            newSeed.transform.parent = transform;
            newSeed.transform.localPosition = new Vector3(0, -1, 0);
            newSeed.transform.localRotation = Quaternion.identity;
            newSeed.transform.localScale = new Vector3(.5f, .5f, .5f);
        }
    }
}
