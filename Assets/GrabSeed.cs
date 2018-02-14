using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSeed : MonoBehaviour
{
    GameObject currentItem;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Seed"))
        {
            currentItem = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Seed"))
        {
            currentItem = null;
        }
    }

    public void PickUpItem()
    {
        if(currentItem != null)
        {
            currentItem.GetComponent<Rigidbody>().useGravity = false;
            currentItem.GetComponent<Rigidbody>().isKinematic = true;
            currentItem.transform.parent = transform;
        }
    }

    public void DropItem()
    {
        if(currentItem != null)
        {
            currentItem.transform.parent = null;
            currentItem.GetComponent<Rigidbody>().isKinematic = false;
            currentItem.GetComponent<Rigidbody>().useGravity = true;
            currentItem = null;
        }
    }
}
