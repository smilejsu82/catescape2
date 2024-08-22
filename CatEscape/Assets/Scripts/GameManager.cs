using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public System.Action gameOverAction;

    public void Awake()
    {
        GameManager.Instance = this;
    }

    public void GameOver()
    {
        if (this.gameOverAction != null)
        {
            this.gameOverAction();
        }
        else 
        {
            Debug.LogError("gameOverAction을 찾을수 없습니다.");
        }
    }
}
