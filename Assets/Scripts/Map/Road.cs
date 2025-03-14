using UnityEngine;
using UnityEngine.InputSystem;

public class Road : MonoBehaviour
{
    public float roadSpeedFactor;
    // 추후 Player의 속도에 맞춰 전진하도록 변경
    void LateUpdate()
    {
        roadSpeedFactor = Player.Instance.GetSpeedFactor();
        float roadSpeed = Player.Instance.GetSpeed() * roadSpeedFactor;

        transform.position += Vector3.back * roadSpeed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            transform.position += new Vector3(0, 0, 288f);
        }
    }
}
