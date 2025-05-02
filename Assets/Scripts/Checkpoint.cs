using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimerReset timerReset = other.GetComponent<TimerReset>();

            if (timerReset != null)
            {
                timerReset.SetCheckpoint(transform);
                Debug.Log("Checkpoint reached: " + transform.position);
            }
        }
    }
}
