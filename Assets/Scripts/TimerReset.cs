using UnityEngine;
using UnityEngine.UI;

public class TimerReset : MonoBehaviour
{
    public float timeLimit = 30f;
    private float currentTime;

    public Text timerText;
    public Transform resetLocation;
    public AudioClip resetClip;

    private AudioSource audioSource;
    private CharacterController characterController;

    void Start()
    {
        currentTime = timeLimit;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        characterController = GetComponent<CharacterController>();

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        UpdateUI();

        if (currentTime <= 0f)
        {
            ResetPlayerPosition();
            currentTime = timeLimit;
        }
    }

    void UpdateUI()
    {
        if (timerText != null)
            timerText.text = Mathf.Ceil(currentTime).ToString();
    }

    void ResetPlayerPosition()
    {
        if (resetClip != null)
            audioSource.PlayOneShot(resetClip);

        if (resetLocation != null)
        {
            if (characterController != null)
                characterController.enabled = false;

            transform.position = resetLocation.position;

            if (characterController != null)
                characterController.enabled = true;
        }
        else
        {
            Debug.LogWarning("Reset location is not assigned.");
        }
    }
    public void SetCheckpoint(Transform newCheckpoint)
    {
        resetLocation = newCheckpoint;
    }

    
}
