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

    [SerializeField] private WeaponContainer weaponContainer;
    [SerializeField] private GameStateEventManager gameStateEventManager;

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
        gameStateEventManager.Subscribe(GameState.PLAYING, globalEnemySpawner);
        gameStateEventManager.Subscribe(GameState.WAITING, globalEnemySpawner);
        gameStateEventManager.Subscribe(GameState.GAME_OVER, globalEnemySpawner);
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        UpdateGameState(GameState.WAITING);
        if (PlayerPrefs.HasKey("HighScore"))
        {
            int val = PlayerPrefs.GetInt("HighScore");
            highScore = val;
            highScoreText.text = "" + highScore;
        }
    }

    public void StartGame()
    {
        UpdateGameState(GameState.PLAYING);
        playerScore = 0;
        scoreText.text = "" + playerScore;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        UpdateGameState(GameState.GAME_OVER);
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore = playerScore;
            highScoreText.text = "" + highScore;
        }
    }

    private void UpdateGameState(GameState state)
    {
        currentGameState = state;
        gameStateEventManager.Notify(currentGameState);
    }

    internal void HandleEnemyDestroyed(EnemyHit enemyHit)
    {
        globalEnemySpawner.ReduceSpawnRate();

        float distanceFromPlayer = Vector3.Distance(enemyHit.transform.position, Vector3.zero);
        int bonusScore = (int)(enemyHit.scoreMultiplier * distanceFromPlayer);
        playerScore += bonusScore;
        scoreText.text = "" + playerScore;
        if (playerScore > 2000 && !weaponContainer.HasExtraAmmo())
        {
            Debug.Log("Adding extra ammo feature");
            weaponContainer.AddExtraAmmoFeature();
            SpawnTextPopup(enemyHit, distanceFromPlayer, "+25% Extra Ammo Chance");
        }
        if (playerScore > 4000 && !weaponContainer.HasExtraShot())
        {
            Debug.Log("Adding extra shot feature");
            weaponContainer.AddExtraShotFeature();
            SpawnTextPopup(enemyHit, distanceFromPlayer, "+25% Extra 3 Shots Chance");
        }
        SpawnScorePopup(enemyHit, distanceFromPlayer, bonusScore);

    }

    private void SpawnTextPopup(EnemyHit enemyHit, float distanceFromPlayer, string text)
    {
        scorePopupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        GameObject popUp = Instantiate(
            scorePopupCanvas,
            new Vector3(enemyHit.transform.position.x, enemyHit.transform.position.y + 5, enemyHit.transform.position.z + 5f),
            Quaternion.identity
        );
        popUp.transform.localScale = new Vector3(
            enemyHit.transform.localScale.x * distanceFromPlayer / 10,
            enemyHit.transform.localScale.y * distanceFromPlayer / 10,
            enemyHit.transform.localScale.z * distanceFromPlayer / 10
        );
    }

    private void SpawnScorePopup(EnemyHit enemyHit, float distanceFromPlayer, int bonusScore)
    {
        scorePopupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = bonusScore.ToString();
        GameObject popUp = Instantiate(
            scorePopupCanvas,
            new Vector3(enemyHit.transform.position.x, enemyHit.transform.position.y, enemyHit.transform.position.z + 5f),
            Quaternion.identity
        );
        popUp.transform.localScale = new Vector3(
            enemyHit.transform.localScale.x * distanceFromPlayer / 10,
            enemyHit.transform.localScale.y * distanceFromPlayer / 10,
            enemyHit.transform.localScale.z * distanceFromPlayer / 10
        );
    }

    internal void UnsubscribeFromEvents(GameState eventType, IEventListener shahedEnemy)
    {
        gameStateEventManager.Unsubscribe(eventType, shahedEnemy);
    }
}
