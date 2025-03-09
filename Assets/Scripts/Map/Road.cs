using UnityEngine;

public class Road : MonoBehaviour
{
    // 추후 Player의 속도에 맞춰 전진하도록 변경
    void LateUpdate()
    {
        transform.position += new Vector3(0, 0, -1f) * Time.deltaTime * 20f;
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            transform.position += new Vector3(0, 0, 288f);
        }
    }
}
