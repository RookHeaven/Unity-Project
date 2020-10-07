using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _jumpSpeed;

    private Vector3 _direction;
    private float _jump;
    private bool _onGround;

    private void Update()
    {
        if (_onGround)
        {
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            _jump = Input.GetAxis("Jump") * Time.deltaTime * _jumpSpeed;

            GetComponent<Rigidbody>().AddForce(transform.up * _jump, ForceMode.Impulse);
        }

        _direction.Normalize();

        var speed = (_direction.sqrMagnitude > 0) ? _speed : 0;

        speed = speed * Time.deltaTime;

        transform.position += transform.forward * speed;

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, _rotateSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _onGround = false;
        }
    }
}
