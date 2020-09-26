using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        float VectorX = Input.GetAxis("Horizontal");
        float VectorZ = Input.GetAxis("Vertical");

        transform.position += transform.forward * _speed * VectorZ * Time.deltaTime;
        transform.position += transform.right * _speed * VectorX * Time.deltaTime;
    }
}
