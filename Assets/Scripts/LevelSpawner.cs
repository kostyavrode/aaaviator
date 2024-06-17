using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public static LevelSpawner instance;
    public GameObject[] levelPrefabs;
    public float spawnDelay;
    public float spawnRange;
    private List<GameObject> spawnedParts = new List<GameObject>();
    private void Awake()
    {
        instance = this;
    }
    public void StartCreate()
    {
        StartCoroutine(this.SpawnPart());
    }
    private IEnumerator SpawnPart()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnLevelPart();
    }
    public void SpawnLevelPart()
    {
        if (spawnedParts.Count - 1 >= 0)
        {
            GameObject newPart = Instantiate(levelPrefabs[Random.Range(0, levelPrefabs.Length)]);
            newPart.transform.position = new Vector3(spawnedParts[spawnedParts.Count - 1].transform.position.x, spawnedParts[spawnedParts.Count - 1].transform.position.y, spawnedParts[spawnedParts.Count - 1].transform.position.z + spawnRange);
            spawnedParts.Add(newPart);
        }
        else
        {
            GameObject newPart = Instantiate(levelPrefabs[0]);
            spawnedParts.Add(newPart);
            newPart.transform.position = new Vector3(0.5f, -11.5f, 115f);

        }
        if (GameManager.instance.isGamePlaying)
        {
            StartCoroutine(SpawnPart());
        }
    }
}
