using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float elapsedTime;  //����ð� 
    private float totalScore;

    void Update()
    {
        this.elapsedTime += Time.deltaTime;

        var score = Time.deltaTime / 0.001f * 0.01f;
        this.totalScore += score;

        var result = Mathf.FloorToInt(this.totalScore * 100f);

        //Debug.Log($"{elapsedTime}�� : {result}");
    }
}
