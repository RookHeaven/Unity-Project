using UnityEngine;


public class CameraScript : MonoBehaviour
{
    public GameObject Player;

    private Vector3 offset;
    private void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    private void Update()
    {
        transform.position = Player.transform.position + offset;
    }
}
