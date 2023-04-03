using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindowBuilder : MonoBehaviour
{
    


    public List<GameObject> WindowPrefabs;
    // Start is called before the first frame update
    float prevHealth;
    public float CurrentHealth;
    public float MaxHealth = 100;

    int prefabIndex;

    public Transform target;

    [TagSelector] public List<string> healTags;

    public GameObject currentWindowPrefeb;
    void Start()
    {

        prefabIndex = -1;
        
        SetCurrentWindowPrefab();
        prevHealth = CurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(prevHealth != CurrentHealth)
        {
            SetCurrentWindowPrefab();
        }
        
        prevHealth = CurrentHealth;
    }

    void SetCurrentWindowPrefab()
    {
        if (MaxHealth == 0) return;

        // Check if CurrentHealth is 0 and set currentWindowPrefab to null
        if (CurrentHealth == 0)
        {
            prefabIndex = -1;
            
            // Set the currentWindowPrefab to the selected prefab
            if (currentWindowPrefeb != null)
                Destroy(currentWindowPrefeb);
            
            currentWindowPrefeb = null;
            return;
        }

        // Calculate the health percentage
        float healthPercentage = CurrentHealth / MaxHealth;

        // Calculate the index of the prefab to use based on the health percentage
        int newPrefabIndex = Mathf.Clamp(Mathf.FloorToInt(healthPercentage * WindowPrefabs.Count) , 0, WindowPrefabs.Count - 1);

        // Set the currentWindowPrefab to the selected prefab if the prefab index has changed
        if (newPrefabIndex != prefabIndex)
        {
            prefabIndex = newPrefabIndex;

            // Set the currentWindowPrefab to the selected prefab
            if (currentWindowPrefeb != null)
                Destroy(currentWindowPrefeb);

            currentWindowPrefeb = Instantiate(WindowPrefabs[prefabIndex], transform.position, transform.rotation, transform);
            currentWindowPrefeb.transform.SetParent(transform);
        }
    }

    public void Damage(float damage)
    {
        CurrentHealth = CurrentHealth - damage < 0 ? 0 : CurrentHealth - damage;
    }

    public void Heal(float heal)
    {
        CurrentHealth = CurrentHealth + heal > MaxHealth ? MaxHealth : CurrentHealth + heal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (healTags.Contains(other.gameObject.tag))
        {
            Heal(20);
            Destroy(other.gameObject);
        }
    }

}
