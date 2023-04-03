using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombieScript : MonoBehaviour
{
    public GameObject Zombie;

    public float SpawnTime;
    public float SpawnRadius;

    private float currSpawnTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currSpawnTime += Time.deltaTime;
        if (currSpawnTime >= SpawnTime)
        {
            GameObject.Instantiate(Zombie, GetNewSpawnPoint(), new Quaternion());
            currSpawnTime = 0.0f;
        }
    }

    private Vector3 GetNewSpawnPoint()
    {
        // random point in circle based off starting position
        Vector3 currPos = transform.position;
        float randNum = Random.Range(0.0f, 1.0f);
        float radius = SpawnRadius * Mathf.Sqrt(randNum);
        float theta = randNum * 2 * Mathf.PI;
        float x = (float)(currPos.x + radius * Mathf.Cos(theta));
        float z = (float)(currPos.z + radius * Mathf.Sin(theta));
        Vector3 newWaypoint = new Vector3(x, currPos.y, z);
        return newWaypoint;
    }
}
