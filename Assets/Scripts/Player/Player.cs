using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // 싱글톤
    private static Player instance;
    public static Player Instance { get { return instance; } }

    private Rigidbody rigid;

    private float speed;
    private float rpm;
    private int gear;

    [SerializeField]
    private float power = 10f;

    // Input System 2차원 입력을 참고하여 코드 다시 짤 것
    bool forward;
    bool left;
    bool right;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Init();
    }

    public void Init()
    {
        rigid = GetComponent<Rigidbody>();
        forward = false;
        left = false;
        right = false;
    }

    void LateUpdate()
    {
        if (left)
        {
            rigid.AddForce(Vector3.left * power);
        }
        if (right)
        {
            rigid.AddForce(Vector3.right * power);
        }
    }

// ============================== 조작 함수 ==============================
    // Input System 2차원 입력을 참고하여 코드 다시 짤 것
    public void MoveForward(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            forward = true;
        }
        if (context.canceled)
        {
            forward = false;
        }
    }
    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            left = true;
        }
        if (context.canceled)
        {
            left = false;
        }
    }
    public void MoveRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            right = true;
        }
        if (context.canceled)
        {
            right = false;
        }
    }

// ============================== 기타 함수 ==============================

}
