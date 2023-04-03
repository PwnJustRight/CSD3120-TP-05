using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [Header("Life Duration Properties")]
    public float lifetime = 2.0f;
    private float lifetimer;

    // Start is called before the first frame update
    void Start()
    {
        lifetimer = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        lifetimer -= Time.deltaTime;
        if (lifetime <= 0.0f)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
