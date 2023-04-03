using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    static public int killCount = 0;
    static public int totalKills = 0;
    static public List<Spawner> spawners = new List<Spawner>(); 
    
    public GameObject[] enemyPrefabs;
    public GameObject[] moleculePrefabs;
    public string[] molecules;
    public WindowBuilder chokePointTarget;
    public int killThreshold;
    public int currentLimit;
    public int maxLimit;
    public float spawnTime;
    public float resize;
    public float limitMultiplier = 1.8f;

    private float timerToSpawn = 0;
    private int activeZombies;
    private List<GameObject> zombies = new List<GameObject>();
    private bool spawning = true;
    void Awake()
    {
        spawners.Add(this);
    }

    private void OnDestroy()
    {
        spawners.Remove(this);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //instantiate pool of enemies
        for (int i = 0; i < currentLimit * 2; ++i)
        {
            int rng = Random.Range(0, enemyPrefabs.Length);
            int rng2 = Random.Range(0, molecules.Length);
            GameObject clone = Instantiate(enemyPrefabs[rng], transform.position, transform.rotation);
            clone.transform.localScale = new Vector3(resize, resize, resize);
            clone.GetComponent<ZombieScript>().SetSpawner(this);
            clone.GetComponent<ZombieScript>().moleculeName = molecules[rng2];

            Vector3 molPos = clone.GetComponent<ZombieScript>().moleculePosition;
            GameObject mol = Instantiate(moleculePrefabs[rng2], transform.position, transform.rotation);
            mol.transform.SetParent(clone.transform);
            mol.transform.localPosition = molPos;
            mol.transform.localScale *= 3.5f;

            zombies.Add(clone);
            clone.SetActive(false);
        }

        SpawnZombie();
    }

    // Update is called once per frame
    void Update()
    {
        //spawn if limit have not reached
        if (spawning)
        {
            if (activeZombies < currentLimit)
            {
                timerToSpawn += Time.deltaTime;
                if (timerToSpawn >= spawnTime)
                {
                    SpawnZombie();
                    timerToSpawn = 0.0f;
                }
            }
        }
        
    }

    public void ToggleOn()
    {
        spawning = true;
    }

    public void ToggleOff()
    {
        spawning = false;
    }

    private void SpawnZombie()
    {
        for(int i = 0; i < zombies.Count; ++i)
        {
            //select random zombies to start test
            int rng = Random.Range(0, zombies.Count);
            if (zombies[rng].activeSelf == false)
            {
                zombies[rng].GetComponent<ZombieScript>().ReInit(chokePointTarget);
                ++activeZombies;
                break;
            }
        }
    }

    public void ZombieDead()
    {
        --activeZombies;
        ++killCount;
        ++totalKills;

        //increment the limit and spawn more zombies to pool
        if (killCount >= killThreshold)
        {
            killCount = 0;
            currentLimit = (int)(currentLimit * limitMultiplier);

            for (int i = zombies.Count; i < currentLimit * 2; ++i)
            {
                int rng = Random.Range(0, enemyPrefabs.Length);
                int rng2 = Random.Range(0, molecules.Length);
                GameObject clone = Instantiate(enemyPrefabs[rng], transform.position, transform.rotation);
                clone.transform.localScale = new Vector3(resize, resize, resize);
                clone.GetComponent<ZombieScript>().SetSpawner(this);
                clone.GetComponent<ZombieScript>().moleculeName = molecules[rng2];

                Vector3 molPos = clone.GetComponent<ZombieScript>().moleculePosition;
                GameObject mol = Instantiate(moleculePrefabs[rng2], transform.position, transform.rotation);
                mol.transform.SetParent(clone.transform);
                mol.transform.localPosition = molPos;
                mol.transform.localScale *= 3.5f;

                zombies.Add(clone);
                clone.SetActive(false);
            }
        }
    }

    private void KillAll()
    {
        for (int i = 0; i < zombies.Count; ++i)
        {
            zombies[i].SetActive(false);
            
        }

        activeZombies = 0;//deactivate self
    }

    public static void KillAllZombies()
    {
        foreach(Spawner sp in spawners){
            sp.KillAll();
        }
    }

    public static void ToggleAllSpawners()
    {
        foreach (Spawner sp in spawners)
        {
            sp.spawning = !sp.spawning;
        }
    }
}

