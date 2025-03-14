using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    // 싱글톤
    private static Player instance;
    public static Player Instance { get { return instance; } }

    private Rigidbody rigid;

    public float RPM = 1;
    private float maxRPM = 9;
    public int currentGear = 1;
    public float[] gearRatios;
    public float[] maxSpeeds;
    public float rpmAcceleration = 0.1f;
    public float rpmDeceleration = 0.2f;

    public float defaultAccerlation = 5f;
    public float airDeceleration = 5f;

    public float roadSpeedFactor = 1f;

    public float speed;

    

    [SerializeField] private float power = 10f;


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
        CheckEngineRPM();
        if (left)
        {
            rigid.AddForce(Vector3.left * power);
        }
        if (right)
        {
            rigid.AddForce(Vector3.right * power);
        }
    }

// ============================== 이동 함수 ==============================
private void CheckEngineRPM()
{
    if (forward)
    {
        if(RPM < maxRPM)
        {
            RPM += rpmAcceleration * gearRatios[currentGear-1];
            speed = maxSpeeds[currentGear-1] * (RPM/maxRPM);
            if (RPM > 9)
            {
                RPM = 9;
                speed = maxSpeeds[currentGear-1];
            }
        }
    }
    else
    {
        if (RPM > 0)
        {
            RPM -= rpmDeceleration;
            speed = maxSpeeds[currentGear-1] * (RPM/maxRPM);
            if (RPM < 0)
            {
                RPM = 0;
                speed = 0;
            }
        }
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

    public void GearChange(InputAction.CallbackContext context)
    {
        if (context.started && !forward)
        {
            if (currentGear > 1)
            {
                float lastSpeed = speed;
                currentGear -= 1;
                RPM = maxRPM * (lastSpeed / maxSpeeds[currentGear]);
            }
            Debug.Log("Now Gear : " + currentGear);
        }
        else if (context.started && forward)
        {
            if (currentGear < 5)
            {
                float lastSpeed = speed;
                currentGear += 1;
                RPM = maxRPM * (lastSpeed / maxSpeeds[currentGear]);
            }
            Debug.Log("Now Gear : " + currentGear);
        }
    }

// ============================== 기타 함수 ==============================
    public float GetSpeed()
    {
        return speed;
    }

    public float GetSpeedFactor()
    {
        return roadSpeedFactor;
    }

}
