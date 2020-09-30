using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;

    private Vector3 _direction;

    private void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _direction.Normalize();

        var speed = (_direction.sqrMagnitude > 0) ? _speed : 0;

        speed = speed * Time.deltaTime;

        transform.position += transform.forward * speed;

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, _rotateSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(desiredForward);
    }
}
