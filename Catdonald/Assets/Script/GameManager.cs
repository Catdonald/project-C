using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 240821 ������
/// ���ӸŴ���, �̱��� 
/// ���� �Ŵ����� ���� �ٸ� �Ŵ��� �ν��Ͻ��� ����
/// </summary>


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PoolManager PoolManager;

    void Awake()
    {
        instance = this;
    }
}
