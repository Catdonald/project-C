using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// 240822 오수안
/// 버거를 생성하고 플레이어에게 주는 오브젝트 유형
/// </summary>
public class Spawner : MonoBehaviour
{
    bool isSpawning;
    public Stack<GameObject> burgerStack;

    [Header("spawn info")]
    public int foodType;
    public int maxCount;
    public int foodCount;
    public float spawnSpeed;
    public float foodHeight;

    void Awake()
    {
        isSpawning = false;
        burgerStack = new Stack<GameObject>();

        foodType = 0;
        maxCount = 3;
        spawnSpeed = 3f;
    }
    void OnEnable()
    {
        GameObject food = GameManager.instance.PoolManager.Get(foodType);
        foodHeight = food.GetComponent<Renderer>().bounds.size.y;
        GameManager.instance.PoolManager.Return(food);
    }

    void Start()
    {

    }

    void Update()
    {
        if (burgerStack.Count < maxCount && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnFood(foodType));
        }
    }

    IEnumerator SpawnFood(int index)
    {
        yield return new WaitForSeconds(spawnSpeed);

        GameObject food = GameManager.instance.PoolManager.Get(index);

        Vector3 pos = transform.position;
        pos.y = transform.position.y + foodHeight * burgerStack.Count;
        food.transform.position = pos;

        burgerStack.Push(food);

        isSpawning = false;
    }

}
