using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject gameOver_panal;

    // there should be only one instance at all time, and should be reachable from all
    public static GUIManager Instance { get; private set; }

    private void Awake()
    {
        // Singleton init
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        healthBar.minValue = 0;
        healthBar.maxValue = 1000;
        SetDisplayOfGameOverPanal(false);
    }

    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score " + newScore;
    }

    public void UpdateHealthBar(int newHealth)
    {
        healthBar.value = newHealth;
    }

    public void SetDisplayOfGameOverPanal(bool state)
    {
        gameOver_panal.SetActive(state);
    }
}
