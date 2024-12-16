using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InfectionSystem : MonoBehaviour
{
    public float maxInfection = 100f;
    public float currentInfection;
    public Slider infectionSlider;

    private GameOverManager gameOverManager;

    void Start()
    {
        currentInfection = 0;
        infectionSlider.maxValue = maxInfection;
        infectionSlider.value = currentInfection;

        gameOverManager = FindObjectOfType<GameOverManager>();
    }

    void Update()
    {
        if (currentInfection < maxInfection)
        {
            currentInfection += Time.deltaTime * 2;
        }

        infectionSlider.value = currentInfection;

        if (currentInfection >= maxInfection)
        {
            if (gameOverManager != null)
            {
                gameOverManager.GameOver();
            }
        }
    }

    public void RemoveInfection(float healingAmount)
    {
        currentInfection -= healingAmount;
        if (currentInfection < 0)
        {
            currentInfection = 0;
        }
        infectionSlider.value = currentInfection;
    }
}

