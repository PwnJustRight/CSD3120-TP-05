using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{
    public ZombieScript zs;
    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.tag == "ChokePoint" && zs.currAttackTime <= 0)
        {
            TriggerCollider tc = collision.gameObject.GetComponent<TriggerCollider>();

            tc.Damage(zs.Damage);
            zs.currAttackTime = zs.AttackCD;
        }
    }
}
