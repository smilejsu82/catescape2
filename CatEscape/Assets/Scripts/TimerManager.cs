using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float remainTime = 30f;
    public GameDirector gameDirector;
    public PlayerController playerController;

    void Update()
    {
        if (playerController.IsGameOver) return;

        this.remainTime -= Time.deltaTime;

        //Debug.Log($"남은 시간: {this.remainTime.ToString("0.00")}");

        this.gameDirector.UpdateRemainTimeUI(remainTime);
    }
}
