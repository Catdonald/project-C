using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 240821 ������ <PoolManager>
/// ��� ������Ʈ�� ������Ʈ Ǯ���� ���
/// Inspector ���� �迭�� Ǯ���Ϸ��� ������Ʈ�� �߰��Ѵ�
/// </summary>

public class PoolManager : MonoBehaviour
{
    [Header("Pooling objects")]
    [Tooltip("add list of gameobject for pooling")]
    public GameObject[] prefabs;
    List<GameObject>[] pools;
    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }
    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject obj in pools[index])
        {
            if (!obj.activeSelf)
            {
                select = obj; 
                obj.SetActive(true);
                break;
            }
        }

        if(!select)
        {
            select = Instantiate(prefabs[index], this.transform);
            pools[index].Add(select);
        }

        return select;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(this.transform);
    }
}
