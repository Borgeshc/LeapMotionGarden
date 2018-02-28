using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject waterDroplet;

    bool startToWater;
    bool watering;

    private void Update()
    {
        if(startToWater)
        {
            if(!watering)
            {
                watering = true;
                StartCoroutine(StartWatering());
            }
        }
    }

    public void Watering()
    {
        startToWater = true;
    }

    public void StoppedWatering()
    {
        startToWater = false;
    }

    IEnumerator StartWatering()
    {
        yield return new WaitForSeconds(.25f);

        for (int i = 0; i < 4; i++)
        {
            //Vector3 newPos = new Vector3(Random.Range(-.01f, .01f), Random.Range(-.01f, .01f), Random.Range(-.01f, .01f));
            Instantiate(waterDroplet, spawnPoint.transform.position, Quaternion.identity);
        }
        watering = false;
    }
}
