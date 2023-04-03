using System.Collections;
using System.Collections.Generic;
using Tilia.Interactions.SnapZone;
using UnityEngine;

public class AtomSpawner : MonoBehaviour
{
    public GameObject carbonPrefab;
    public GameObject oxygenPrefab;
    public GameObject hydrogenPrefab;

    public List<SnapZoneFacade> snappers;
    
    public void SpawnCarbon()
    {
        Instantiate(carbonPrefab, transform.position, Quaternion.identity);
    }
    public void SpawnOxygen()
    {
        Instantiate(oxygenPrefab, transform.position, Quaternion.identity);
    }

    public void SpawnHydrogen()
    {
        Instantiate(hydrogenPrefab, transform.position, Quaternion.identity);
    }
    public void DestroyAllAtoms()
    {
        foreach (SnapZoneFacade snapper in snappers)
        {
            snapper.Unsnap();
        }
        
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Oxygen");

        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            objectToDestroy.SetActive(false);
            Destroy(objectToDestroy);
        }

        objectsToDestroy = GameObject.FindGameObjectsWithTag("Carbon");

        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            objectToDestroy.SetActive(false);
            Destroy(objectToDestroy);
        }

        objectsToDestroy = GameObject.FindGameObjectsWithTag("Hydrogen");
        
        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            objectToDestroy.SetActive(false);
            Destroy(objectToDestroy);
        }
    }
}
