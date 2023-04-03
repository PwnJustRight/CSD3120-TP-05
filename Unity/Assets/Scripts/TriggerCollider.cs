using UnityEngine;
using System.Collections.Generic;

public class TriggerCollider : MonoBehaviour
{
    // List to hold colliding objects
    [ReadOnly]
    public List<GameObject> collidingObjects = new List<GameObject>();

    [TagSelector] public string triggertags;

    public WindowBuilder windowBuilder;

    // Called when a collider enters the trigger volume
    void OnTriggerEnter(Collider other)
    {
        // Add the colliding object to the list
        if (other.gameObject.CompareTag(triggertags))
            collidingObjects.Add(other.gameObject);
    }

    // Called when a collider exits the trigger volume
    void OnTriggerExit(Collider other)
    {
        // Remove the colliding object from the list
        if (other.gameObject.CompareTag(triggertags))
            collidingObjects.Remove(other.gameObject);
    }

   // public void 
    public void Damage(float dmg)
    {
        windowBuilder.Damage(dmg);
    }

}
