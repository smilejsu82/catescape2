using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public Image hpGauge;
    public Text remainTimeSecText;
    public Text remainTimeMilliSecText;

    public void UpdateHpGauge(float fillAmount)
    {
        this.hpGauge.fillAmount = fillAmount;
    }

    public void UpdateRemainTimeUI(float remainTime)
    {
        string strReaminTime = remainTime.ToString("0.00");
        string[] arr = strReaminTime.Split(".");

        this.remainTimeSecText.text = arr[0];
        this.remainTimeMilliSecText.text = $".{arr[1]}";
}
}
