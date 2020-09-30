using UnityEngine;


public class OpenDoor : MonoBehaviour
{

	public float smooth = 2.0f;
	public float DoorOpenAngle = 90.0f;

	private Vector3 defaultRotation;
	private Vector3 openRotation;
	private bool open;
	private bool enter;


	void Start()
	{
		defaultRotation = transform.eulerAngles;
		openRotation = new Vector3(defaultRotation.x, defaultRotation.y + DoorOpenAngle, defaultRotation.z);
	}


	void Update()
	{
		if (open)
		{
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRotation, Time.deltaTime * smooth);
		}
		else
		{
			transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRotation, Time.deltaTime * smooth);
		}
		if (Input.GetKeyDown(KeyCode.E) && enter)
		{
			open = !open;
		}
	}


	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("Player"))
		{
			enter = true;
		}
	}


	void OnTriggerExit(Collider collider)
	{
		if (collider.CompareTag("Player"))
		{
			enter = false;
		}
	}
}