using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject victoryCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            victoryCanvas.SetActive(true);
            EndGame();
        }
    }

    private void EndGame()
    {
        Time.timeScale = 0;
    }
}
