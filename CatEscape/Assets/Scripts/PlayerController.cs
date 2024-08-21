using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float radius = 1f;
    public GameDirector gameDirector;
    public ArrowGenerator arrowGenerator;
    private int hp;
    private int maxHp;
    private bool isGameOver = false;

    public bool IsGameOver
    {
        get {
            return this.isGameOver;
        }
    }

    private void Start()
    {
        this.maxHp = 100;
        this.hp = 10;
        Debug.Log($"플레이어의 체력 : {this.hp}/{this.maxHp}");

        float fillAmount = (float)this.hp / this.maxHp;
        this.gameDirector.UpdateHpGauge(fillAmount);
    }

    void Update()
    {
        if (isGameOver) return;

        bool isDownLeftArrow = Input.GetKeyDown(KeyCode.LeftArrow);

        bool isDownRightArrow = Input.GetKeyDown(KeyCode.RightArrow);

        if (isDownLeftArrow)
        {
            //Debug.Log("왼쪽 화살표 키를 눌렀습니다.");
            this.transform.Translate(-1, 0, 0);

            this.LimitPosition();
        }
        else if (isDownRightArrow)
        {
            //Debug.Log("오른쪽 화살표 키를 눌렀습니다.");

            this.transform.Translate(1, 0, 0);

            this.LimitPosition();
        }

        
    }

    private void OnDrawGizmos()
    {
        GizmosExtensions.DrawWireArc(this.transform.position, 360, radius);
    }

    public void HitDamage(float damage)
    {
        if (isGameOver) return;

        this.hp -= (int)damage;
        Debug.Log($"피해를 받았습니다. {this.hp}/{this.maxHp}");

        //=====> 90/100

        if (hp <= 0)
        {
            hp = 0;
            Debug.Log("<color=yellow>게임 오버</color>");
            isGameOver = true;
            arrowGenerator.StopGenerate();
        }

        //현재 체력 / 최대 체력 
        float fillAmount = (float)this.hp / this.maxHp;
        this.gameDirector.UpdateHpGauge(fillAmount);

    }

    private void LimitPosition()
    {
        float posX = Mathf.Clamp(this.transform.position.x, -7.78f, 7.78f);
        Vector3 pos = this.transform.position;
        pos.x = posX;
        this.transform.position = pos;
    }
}
