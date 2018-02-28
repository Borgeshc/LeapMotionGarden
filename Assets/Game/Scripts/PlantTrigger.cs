using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantTrigger : MonoBehaviour
{
    public Animator anim;
    public GrowthManager growthManager;

    public GameObject succulent;
    public GameObject aloe;
    public GameObject miniCactus;
    public GameObject chrismasCactus;
    public GameObject flyTrap;

    public Image waterMeter;

    GameObject plant;

    bool hasPlant;

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlant || growthManager.isGrowing) return;

        StartCoroutine(growthManager.Growing());

        if(other.tag.Equals("Seed"))
        {
            Seed seed = other.GetComponent<Seed>();
            switch (seed.seedType)
            {
                case Seed.SeedType.Succulent:
                    plant = Instantiate(succulent);
                    break;
                case Seed.SeedType.Aloe:
                    plant = Instantiate(aloe);
                    break;
                case Seed.SeedType.MiniCactus:
                    plant = Instantiate(miniCactus);
                    break;
                case Seed.SeedType.ChrismasCactus:
                    plant = Instantiate(chrismasCactus); ;
                    break;
                case Seed.SeedType.FlyTrap:
                    plant = Instantiate(flyTrap);
                    break;
            }

            plant.transform.parent = transform;
            plant.transform.localRotation = Quaternion.identity;
            plant.transform.localPosition = Vector3.zero;

            plant.GetComponent<Grow>().SetWaterMeter(waterMeter, this);

            hasPlant = true;

            Destroy(other.gameObject);
            anim.SetTrigger("Grow");
        }
    }

    public void PlantDied()
    {
        hasPlant = false;
    }
}
