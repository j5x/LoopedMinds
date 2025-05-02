using UnityEngine;
using UnityEngine.UI;

public class TerminalUI : MonoBehaviour
{
    public GameObject uiCanvas;
    public InputField codeInput;
    public Button submitButton;
    public TerminalCodeCheck codeCheck;

    void Start()
    {
        uiCanvas.SetActive(false);
        submitButton.onClick.AddListener(OnSubmit);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void OnSubmit()
    {
        string input = codeInput.text;
        codeCheck.SubmitCode(input);
        uiCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
