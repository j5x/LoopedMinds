using UnityEngine;

public class TerminalCodeCheck : MonoBehaviour
{
    public string correctCode = "0420";
    public DoorController door;
    
    public void SubmitCode(string input)
    {
        if (input == correctCode)
        {
            door.OpenDoor();
        }
        else
        {
            Debug.Log("Incorrect code.");
        }
    }
}
