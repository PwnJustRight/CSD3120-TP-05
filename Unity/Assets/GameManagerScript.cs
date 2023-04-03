using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Light WorldLight;

    private float maxIntensity = 1.39f;
    private float currIntensity = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        WorldLight.intensity = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        currIntensity += Time.deltaTime * 0.03f;
        if (currIntensity >= maxIntensity)
        {
            currIntensity = maxIntensity;

            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
            foreach(GameObject spawn in spawners)
            {
                spawn.SetActive(false);
            }
        }

        WorldLight.intensity = currIntensity;
    }
}
