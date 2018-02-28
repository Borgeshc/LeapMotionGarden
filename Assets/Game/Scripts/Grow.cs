using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grow : MonoBehaviour
{
   
    public float maxTime;
    public float timeIncrease;

    Image waterMeter;

    bool scale;
    bool scaling;
    bool filling;

    bool ready;

    float currentTime;

    bool timer;

    PlantTrigger trigger;

    private void Start()
    {
        if (!ready)
            ready = true;

        currentTime = maxTime / 7;
    }

    private void Update()
    {
        if (scale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, .3f * Time.deltaTime);
        }

        if(ready && currentTime <= .1f)
        {
            PlantDied();
        }

        if(!timer)
        {
            timer = true;
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        currentTime--;
        UpdateWater();

        yield return new WaitForSeconds(1);
        timer = false;
    }

    public void SetWaterMeter(Image _waterMeter, PlantTrigger _trigger)
    {
        waterMeter = _waterMeter;
        trigger = _trigger;
    }

    void PlantDied()
    {
        trigger.PlantDied();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Water"))
        {

            if (currentTime < maxTime && !filling)
            {
                filling = true;
                StartCoroutine(Fill());
            }

            if (transform.localScale.x < 1 && !scaling)
            {
                scaling = true;
                scale = true;

                StartCoroutine(Scaling());
            }
        }
    }

    IEnumerator Scaling()
    {
        yield return new WaitForSeconds(.5f);
        scaling = false;
        scale = false;
    }

    IEnumerator Fill()
    {
        currentTime += timeIncrease;
        UpdateWater();
        yield return new WaitForSeconds(.5f);
        filling = false;
    }

    void UpdateWater()
    {
        waterMeter.fillAmount = (currentTime / maxTime);
    }
}
