using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoleculeSpawner : MonoBehaviour
{
    public GameObject oxygenPrefab;
    public GameObject waterPrefab;
    public GameObject hydrogenPrefab;
    public GameObject methanePrefab;
    public GameObject COPrefab;
    public GameObject H2O2Prefab;
    public GameObject CO2Prefab;
    public GameObject C2H2Prefab;

    public TextMeshProUGUI nameUI;

    public void SpawnMolecule()
    {
        string nameText = nameUI.text;
        if (nameText == "Hydrogen Gas")
            Instantiate(hydrogenPrefab, transform.position, Quaternion.identity);
        else if (nameText == "Water")
            Instantiate(waterPrefab, transform.position, Quaternion.identity);
        else if (nameText == "Oxygen Gas")
            Instantiate(oxygenPrefab, transform.position, Quaternion.identity);
        else if (nameText == "Methane")
            Instantiate(methanePrefab, transform.position, Quaternion.identity);
        else if (nameText == "Carbon Monoxide")
            Instantiate(COPrefab, transform.position, Quaternion.identity);
        else if (nameText == "Hydrogen Peroxide")
            Instantiate(H2O2Prefab, transform.position, Quaternion.identity);
        else if (nameText == "Carbon Dioxide")
            Instantiate(CO2Prefab, transform.position, Quaternion.identity);
        else if (nameText == "Acetylene")
            Instantiate(C2H2Prefab, transform.position, Quaternion.identity);
    }


    public void DestroyAllMols()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("O2");

        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }

        objectsToDestroy = GameObject.FindGameObjectsWithTag("H2");

        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }

        objectsToDestroy = GameObject.FindGameObjectsWithTag("H2O");

        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }

        objectsToDestroy = GameObject.FindGameObjectsWithTag("H2O2");

        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }

        objectsToDestroy = GameObject.FindGameObjectsWithTag("C2H2");

        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }

        objectsToDestroy = GameObject.FindGameObjectsWithTag("CO");

        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }

        objectsToDestroy = GameObject.FindGameObjectsWithTag("CH4");

        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }

        objectsToDestroy = GameObject.FindGameObjectsWithTag("CO2");

        foreach (GameObject objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }
    }


}
