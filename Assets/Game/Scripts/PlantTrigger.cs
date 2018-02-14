using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTrigger : MonoBehaviour
{
    public Animator anim;

    public GameObject succulent;
    public GameObject aloe;
    public GameObject miniCactus;
    public GameObject chrismasCactus;
    public GameObject flyTrap;

    private void OnTriggerEnter(Collider other)
    {
        print("Seed Detected");
        if(other.tag.Equals("Seed"))
        {
            Seed seed = other.GetComponent<Seed>();
            switch (seed.seedType)
            {
                case Seed.SeedType.Succulent:
                    succulent.SetActive(true);
                    break;
                case Seed.SeedType.Aloe:
                    aloe.SetActive(true);
                    break;
                case Seed.SeedType.MiniCactus:
                    miniCactus.SetActive(true);
                    break;
                case Seed.SeedType.ChrismasCactus:
                    chrismasCactus.SetActive(true);
                    break;
                case Seed.SeedType.FlyTrap:
                    flyTrap.SetActive(true);
                    break;
            }

            Destroy(other);
            anim.SetTrigger("Grow");
        }
    }
}
