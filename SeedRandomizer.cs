using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedRandomizer : MonoBehaviour
{
    public NoiseData noiseData;

    // Start is called before the first frame update
    void Awake()
    {
        //Random.InitState(noiseData.seed);
        //Debug.Log(noiseData.seed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
