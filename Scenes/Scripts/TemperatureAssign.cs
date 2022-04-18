using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureAssign : MonoBehaviour
{
    public float temperature_degree = 10f;
    [HideInInspector] public string cachedMaterialTag;
	[HideInInspector] public Color cachedColor;
}
