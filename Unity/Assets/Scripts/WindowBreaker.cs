using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreaker : MonoBehaviour
{
    public WindowBuilder windowBuilder;
    public TriggerCollider damageCollider;

    public float damageInterval = 1f;
    public float damagePerEnemy = 5f;
    private float timeSinceDamage = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Only damage the window builder if the time interval has passed
        // timeSinceDamage += Time.deltaTime;
        // if (timeSinceDamage >= damageInterval)
        // {

        //     foreach (GameObject obj in damageCollider.collidingObjects)
        //     {
        //         if (obj.activeSelf)
        //             windowBuilder.Damage(damagePerEnemy);
        //     }

        //     // Reset the time since damage
        //     timeSinceDamage = 0f;
        // }
    }
}
