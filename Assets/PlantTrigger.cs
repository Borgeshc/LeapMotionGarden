using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTrigger : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Seed"))
        {
            Destroy(other);
            anim.SetTrigger("Grow");
        }
    }
}
