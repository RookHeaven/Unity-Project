using UnityEngine;


public class OpenDoor : MonoBehaviour
{

	public float _smooth = 2.0f;
	public float _doorOpenAngle = 90.0f;

	private Vector3 _defaultRotation;
	private Vector3 _openRotation;
	private bool _open;
	private bool _enter;


	void Start()
	{
		_defaultRotation = transform.eulerAngles;
		_openRotation = new Vector3(_defaultRotation.x, _defaultRotation.y + _doorOpenAngle, _defaultRotation.z);
	}


	void Update()
	{
		if (_open)
		{
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, _openRotation, Time.deltaTime * _smooth);
		}
		else
		{
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, _defaultRotation, Time.deltaTime * _smooth);
		}
		if (Input.GetKeyDown(KeyCode.E) && _enter)
		{
			_open = !_open;
		}
	}


	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("Player"))
		{
			_enter = true;
		}
	}


	void OnTriggerExit(Collider collider)
	{
		if (collider.CompareTag("Player"))
		{
			_enter = false;
		}
	}
}