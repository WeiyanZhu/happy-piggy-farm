using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    [SerializeField] private BoxCollider2D spawnArea;
    [SerializeField] private List<GameObject> foodPrefs = new List<GameObject>();
    [SerializeField] private float spawnIntervalMin = 0.1f;
    [SerializeField] private float spawnIntervalMax = 0.5f;
    private float timer = 0;
    private float spawnInterval;

    void Start()
    {
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval){
            timer -= spawnInterval;
            spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            SpawnFood();
        }
    }

    public void SpawnFood()
    {
        Vector2 xRange = new Vector2(spawnArea.bounds.center.x - spawnArea.bounds.extents.x,
                                    spawnArea.bounds.center.x + spawnArea.bounds.extents.x);
        Vector2 yRange = new Vector2(spawnArea.bounds.center.y - spawnArea.bounds.extents.y,
                                    spawnArea.bounds.center.y + spawnArea.bounds.extents.y);
        Vector2 spawnPos = new Vector2(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y));
        GameObject randomFoodPref = foodPrefs[Random.Range(0, foodPrefs.Count)];
        Instantiate(randomFoodPref, spawnPos, Quaternion.identity);
    }
}