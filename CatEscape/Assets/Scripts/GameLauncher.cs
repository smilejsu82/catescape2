using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLauncher : MonoBehaviour
{
    public PlayerController playerController;
    public GameDirector gameDirector;
    public TimerManager timerManager;
    public ScoreManager scoreManager;
    public ArrowGenerator arrowGenerator;

    public bool IsGameOver { get; }

    private void Start()
    {
        GameManager.Instance.gameOverAction = () => {

            Debug.Log("게임이 종료 되었습니다.");

        };
    }

    public void GameStart()
    {
        arrowGenerator.StartGenerate();
    }
}
