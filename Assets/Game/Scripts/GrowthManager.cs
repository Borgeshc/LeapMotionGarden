using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
    public bool isGrowing;

    public IEnumerator Growing()
    {
        isGrowing = true;
        yield return new WaitForSeconds(.5f);
        isGrowing = false;
    }
}
