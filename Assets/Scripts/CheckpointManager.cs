using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;
    public Transform currentCheckpoint;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;
        Debug.Log("Checkpoint set to: " + checkpoint.position);
    }

    public void ResetPlayer(GameObject player)
    {
        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null)
            {
                cc.enabled = false;  // disable to allow repositioning
                player.transform.position = currentCheckpoint.position;
                cc.enabled = true;   // re-enable after teleport
            }
else
{
    player.transform.position = currentCheckpoint.position;
}

    }
}
