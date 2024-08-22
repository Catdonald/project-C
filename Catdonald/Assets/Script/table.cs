using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// <summary>
/// 240822 ������
/// �÷��̾��� ���Ÿ� �������� ������Ʈ ����
/// </summary>

public class table : MonoBehaviour
{
    public Stack<GameObject> burgers;
    private bool isDeleting = false;

    void Awake()
    {
        burgers = new Stack<GameObject>();
    }
    void Update()
    {
        if (burgers.Count > 0 && !isDeleting)
        {
            StartCoroutine(DeleteBurger());
        }
    }

    IEnumerator DeleteBurger()
    {
        isDeleting = true;

        yield return new WaitForSeconds(5f);

        GameManager.instance.PoolManager.Return(burgers.Pop());

        isDeleting = false;
    }

}
