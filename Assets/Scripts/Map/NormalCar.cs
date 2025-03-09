using UnityEngine;

public class NormalCar : MonoBehaviour
{
    // 추후 Player의 속도에 맞춰 전진하도록 변경
    // Player의 속도가 0이면 10f 속도로 전진해야 할 것 같음 : offset = 10f
    // Truck은 이 객체를 상속받을 것
    void LateUpdate()
    {
        transform.position += new Vector3(0, 0, -1f) * Time.deltaTime * 10f;
    }
}
