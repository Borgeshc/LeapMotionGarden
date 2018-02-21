using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject dirtObject;
    public int numberOfDirtObjects;

    private IEnumerator Start()
    {
        for(int i = 0; i < numberOfDirtObjects; i++)
        {
            Instantiate(dirtObject, transform.localPosition, Quaternion.identity, transform);
            yield return new WaitForSeconds(.005f);
        }
    }
}
