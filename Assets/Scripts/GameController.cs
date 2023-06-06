using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Instance { get; private set; }

    [SerializeField] private GlobalEnemySpawner globalEnemySpawner;

    [Header("Score text on display")]
    [SerializeField] private TMP_Text scoreText;

    [Header("Score text on enemy kill")]
    [SerializeField] private GameObject scorePopupCanvas;

    [Header("Game Over menu")]
    [SerializeField] private GameObject gameOverMenu;

    [Header("HighScore text on display")]
    [SerializeField] private TMP_Text highScoreText;

    public enum GameState
    {
        WAITING,
        PLAYING,
        GAME_OVER
    }
    public static GameState currentGameState;
    private int highScore = 0;
    private int playerScore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        currentGameState = GameState.WAITING;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            int val = PlayerPrefs.GetInt("HighScore");
            highScore = val;
            highScoreText.text = "" + highScore;
        }
    }

    public void StartGame()
    {
        currentGameState = GameState.PLAYING;
        globalEnemySpawner.EnableSpawners(true);
        playerScore = 0;
        scoreText.text = "" + playerScore;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        currentGameState = GameState.GAME_OVER;
        globalEnemySpawner.EnableSpawners(false);
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore = playerScore;
            highScoreText.text = "" + highScore;
        }
    }

    internal void HandleEnemyDestroyed(EnemyHit enemyHit)
    {
        globalEnemySpawner.ReduceSpawnRate();

        float distanceFromPlayer = Vector3.Distance(enemyHit.transform.position, Vector3.zero);
        int bonusScore = (int)(enemyHit.scoreMultiplier * distanceFromPlayer);
        playerScore += bonusScore;
        scoreText.text = "" + playerScore;
        SpawnScorePopup(enemyHit, distanceFromPlayer, bonusScore);
    }

    private void SpawnScorePopup(EnemyHit shahedHit, float distanceFromPlayer, int bonusScore)
    {
        scorePopupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = bonusScore.ToString();
        GameObject popUp = Instantiate(
            scorePopupCanvas,
            new Vector3(shahedHit.transform.position.x, shahedHit.transform.position.y, shahedHit.transform.position.z + 5f),
            Quaternion.identity
        ) ;
        popUp.transform.localScale = new Vector3(
            shahedHit.transform.localScale.x * distanceFromPlayer / 10,
            shahedHit.transform.localScale.y * distanceFromPlayer / 10,
            shahedHit.transform.localScale.z * distanceFromPlayer / 10
        );
    }
}
