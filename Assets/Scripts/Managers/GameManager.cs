using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState { Initial, On, Over }
    public GameState CurrentGameState { get; protected set; }

    // there should be only one instance at all time, and should be reachable from all
    public static GameManager Instance { get; private set; }

    private int gameScore;

    private void Awake()
    {
        // Singleton init
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

        private void Start()
    {
        GameEvents.Instance.OnPickableItemActivated += OnPickableItemActivated;
        GameEvents.Instance.OnPlayerDied += EndGame;
        Time.timeScale = 1f;
        gameScore = 0;
        GUIManager.Instance.UpdateScoreText(gameScore);
        CurrentGameState = GameState.Initial;
    }

    private void OnPickableItemActivated(PickableItem pickableItem)
    {
        AddPoints(pickableItem.PointsBonus);
    }

    private void AddPoints(int pointsToAdd)
    {
        gameScore += pointsToAdd;
        GUIManager.Instance.UpdateScoreText(gameScore);
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        CurrentGameState = GameState.Over;
        GUIManager.Instance.SetDisplayOfGameOverPanal(true);
    }

    public void RestartGame()
    {
        GUIManager.Instance.SetDisplayOfGameOverPanal(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnPickableItemActivated -= OnPickableItemActivated;
        GameEvents.Instance.OnPlayerDied -= EndGame;
    }
}
