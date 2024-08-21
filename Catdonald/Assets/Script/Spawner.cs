using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    PlayerTestMove player;
    Transform spawnPoint;

    public int foodType;
    public int foodCount;
    public int spawnSpeed;

    float timer;

    void Awake()
    {
        foodType = 0;
        foodCount = 0;
        spawnSpeed = 1;
    }

    void Start()
    {
        player = GetComponent<PlayerTestMove>();
        spawnPoint = spawnPoint.transform.parent.GetChild(0);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnSpeed)
        {
            GameObject food = GameManager.instance.PoolManager.Get(foodType);
            food.transform.position = spawnPoint.position;
        }
    }




}
