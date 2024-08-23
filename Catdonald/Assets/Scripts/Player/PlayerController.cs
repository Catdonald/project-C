using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5.0f;
    [SerializeField]
    GameObject characterRoot;
    [SerializeField]
    GameObject touchController;

    private bool isClicked = false;
    private Vector3 mouseClickedPos;
    private JoyStickController joystickController;

    // Start is called before the first frame update
    void Start()
    {
        joystickController = touchController.GetComponentInChildren<JoyStickController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isClicked)
            {
                isClicked = true;
                mouseClickedPos = Input.mousePosition;
                // touchController UI Ȱ��ȭ
                touchController.SetActive(true);
                Vector3 touchControllerPos = new Vector3(mouseClickedPos.x - Screen.width / 2, mouseClickedPos.y - Screen.height / 2, mouseClickedPos.z);
                touchController.GetComponent<RectTransform>().localPosition = touchControllerPos;
            }
            else
            {
                // Ŭ���� ��ġ�� ���� Ŀ�� ��ġ�� ���� �̵� ���� ���ϱ�
                Vector3 mousePos = Input.mousePosition;
                //Debug.Log(mousePos);
                Vector3 mouseDelta = mousePos - mouseClickedPos;              
                Debug.Log(mouseDelta);
                // max padSizeX = 35.0f
                Vector3 mouseDeltaNorm = new Vector3(mouseDelta.x / 35.0f, mouseDelta.y / 35.0f, mouseDelta.z);
                if(mouseDeltaNorm.magnitude > 1.0f)
                {
                    mouseDeltaNorm = mouseDelta.normalized;
                }
                Vector3 moveVec = new Vector3(mouseDeltaNorm.x, 0.0f, mouseDeltaNorm.y);
                transform.position += moveVec * Time.deltaTime * moveSpeed;
                // �̵��ϴ� ���� �ٶ󺸱�
                if (moveVec.magnitude > 0.0f)
                {
                    characterRoot.transform.forward = moveVec;
                }

                // ���콺 ��ġ ��ȭ�� ���� JoyStickController�� �Ѱ��ֱ�
                joystickController.mouseDelta = mouseDelta;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
            // touchController UI ��Ȱ��ȭ
            touchController.SetActive(false);
        }
    }

}
