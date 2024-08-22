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

            Debug.Log("������ ���� �Ǿ����ϴ�.");

        };
    }

    public void GameStart()
    {
        arrowGenerator.StartGenerate();
    }
}
