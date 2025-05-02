using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Vector3 openOffset = new Vector3(0, 3f, 0); // how high it lifts
    public float openSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;
    }

    void Update()
    {
        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, openSpeed * Time.deltaTime);
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
    }
}
