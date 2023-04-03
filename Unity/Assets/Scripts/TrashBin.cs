using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Oxygen"
            || other.gameObject.tag == "Carbon"
            || other.gameObject.tag == "Hydrogen"
            || other.gameObject.tag == "O2"
            || other.gameObject.tag == "H2"
            || other.gameObject.tag == "H2O"
            || other.gameObject.tag == "CH4"
            || other.gameObject.tag == "CO"
            || other.gameObject.tag == "H2O2"
            || other.gameObject.tag == "C2H2"
            || other.gameObject.tag == "CO2"
            || other.gameObject.tag == "C2H4")
        {
            Destroy(other.gameObject);
        }
    }
}
