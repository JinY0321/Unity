using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;  // 현재 입력 값
    public float jumpPower;
    public LayerMask groundLayerMask;  // 레이어 정보

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;  // 최소 시야각
    public float maxXLook;  // 최대 시야각
    private float camCurXRot;
    public float lookSensitivity; // 카메라 민감도

    private Vector2 mouseDelta;  // 마우스 변화값

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //게임 화면에서 커서가 보이지 않도록 하는 화면.    
    }

    // Update is called once per frame
    void FixedUpdate() //물리연산시에는 fix사용하는것이 좋음.
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    void Move()
    {
        // 현재 입력의 y 값은 z 축(forward, 앞뒤)에 곱한다.
        // 현재 입력의 x 값은 x 축(right, 좌우)에 곱한다.
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;  // 방향에 속력을 곱해준다.
        dir.y = _rigidbody.velocity.y;  // y값은 velocity(변화량)의 y 값을 넣어준다.

        _rigidbody.velocity = dir;  // 연산된 속도를 velocity(변화량)에 넣어준다.
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot,minXLook,maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        if(context.phase == InputActionPhase.Performed) //키보드 눌렀을 때.
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled) //키보드 손 뗐을 때.
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            GetComponent<Rigidbody>().AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {

                return true;
            }
        }
        return false;
    }
}
