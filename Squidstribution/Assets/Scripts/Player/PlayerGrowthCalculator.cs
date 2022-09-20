using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrowthCalculator : MonoBehaviour
{
    public int GrowthFactor { private set; get; }

    private void Start()
    {
        GrowthFactor = 1;
    }
}
