using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Properties")]
    public float lifetime = 10.0f;
    float lifetimer;
    public GameObject hitParticle;

    // Start is called before the first frame update
    void Start()
    {
        lifetimer = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        // destroy projectile after a fixed duration for computer performance purpose
        lifetimer -= Time.deltaTime;
        if (lifetime <= 0.0f)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    // when colliding with other objects in valid physics layers
    void OnTriggerEnter(Collider other)
    {
        GameObject gobj = other.gameObject;
        
        if (other.GetComponent<Collider>().isTrigger == true) return;
        print("BULLET HIT " + gobj.name);

        Quaternion hitRotation = Quaternion.LookRotation(other.transform.position - transform.position, Vector3.up);

        // Spawn the particle effect and set its rotation
        GameObject spawnedObject = Instantiate(hitParticle, transform.position, hitRotation, null);
        ParticleSystem particleSystem = spawnedObject.GetComponent<ParticleSystem>();
        particleSystem.Play();

        Destroy(gameObject);
    }
}
