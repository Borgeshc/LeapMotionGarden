using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMenu : MonoBehaviour
{
    public SpawnSeed[] seeds;

    private void OnEnable()
    {
        for(int i = 0; i < seeds.Length; i++)
        {
            seeds[i].Activated();
        }
    }
}
