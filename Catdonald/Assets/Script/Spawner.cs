using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    bool isSpawning;
    Stack<GameObject> burgerStack;

    [Header("spawn info")]
    public int foodType;
    public int maxCount;
    public int foodCount;
    public float spawnSpeed;

    void Awake()
    {
        isSpawning = false;
        burgerStack = new Stack<GameObject>();

        foodType = 0;
        maxCount = 3;
        foodCount = 0;
        spawnSpeed = 3f;
    }

    void Start()
    {

    }

    void Update()
    {
        if (foodCount < maxCount && !isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnFood(foodType));
        }
    }

    IEnumerator SpawnFood(int index)
    {
        yield return new WaitForSeconds(spawnSpeed);

        GameObject food = GameManager.instance.PoolManager.Get(index);

        var height = food.GetComponent<Renderer>().bounds.size.y;

        Vector3 pos = transform.position;
        pos.y = transform.position.y + height * burgerStack.Count;
        food.transform.position = pos;

        burgerStack.Push(food);
        foodCount = burgerStack.Count;

        isSpawning = false;
    }

}
