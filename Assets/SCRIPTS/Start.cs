using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    public Button startButton;
    public TextMeshProUGUI buttonText;

    void Start()
    {
        if (buttonText != null)
        {
            buttonText.text = "You wake up in this hospital unaware of how you got here your goal is to escape. Make sure you do not become infected. Use WASD to move and space to shoot good luck...";
        }

        if (startButton != null)
        {
            startButton.onClick.AddListener(HideText);
        }
    }

    void HideText()
    {
        if (buttonText != null)
        {
            buttonText.gameObject.SetActive(false);
        }
    }
}