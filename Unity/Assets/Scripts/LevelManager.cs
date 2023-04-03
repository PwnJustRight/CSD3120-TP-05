using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;

    public int currentLevelIndex = 0;
    

    public void CycleLevels()
    {
        KillSpawners();
        /*if (levels.Count >= 2)
        {
            // Activate the next level
            currentLevelIndex = (currentLevelIndex + 1) % levels.Count;
            levels[currentLevelIndex].SetActive(true);

            // Deactivate the previous level
            int prevLevelIndex = (currentLevelIndex - 1 + levels.Count) % levels.Count;
            levels[prevLevelIndex].SetActive(false);
        }*/
        if(currentLevelIndex == 0)
        {
            SceneManager.LoadScene("Gameplay2");
        }
        else
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    public void KillSpawners()
    {
        Spawner.KillAllZombies();
    }
}
