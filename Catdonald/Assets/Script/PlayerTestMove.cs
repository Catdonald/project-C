using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 240822 ������
/// �÷��̾ �ӽ÷� �����̱� ���� ��ũ��Ʈ
/// </summary>

public class PlayerTestMove : MonoBehaviour
{
    public float speed = 6.0f;        // �÷��̾� �̵� �ӵ�
    public float gravity = -9.81f;    // �߷�
    public CharacterController controller;
    public burgerStack stack;

    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        stack = GetComponentInChildren<burgerStack>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * speed * Time.deltaTime);

        // �߷� ����
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // ���鿡 ���� �� Y�� �ӵ� �ʱ�ȭ
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.transform.tag)
        {
            case "kitchen":
                {
                    stack.OnEnterKitchen(0, other);
                }
                break;
            case "desk":
                {
                    stack.OnEnterTable(0, other);
                }
                break;
        }

    }

    void OnTriggerStay(Collider other)
    {
        switch (other.transform.tag)
        {
            case "kitchen":
                {
                    stack.TryGetBurger();
                }
                break;
            case "desk":
                {
                    stack.TrySetBurger();
                }
                break;
        }

    }

    void OnTriggerExit(Collider other)
    {
        switch (other.transform.tag)
        {
            case "kitchen":
                {

                    stack.OnExitKitchen();

                }
                break;
            case "desk":
                {
                    stack.OnExitTable();
                }
                break;
        }
    }
}
