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
        Debug.Log($"�÷��̾��� ü�� : {this.hp}/{this.maxHp}");

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
            //Debug.Log("���� ȭ��ǥ Ű�� �������ϴ�.");
            this.transform.Translate(-1, 0, 0);

            this.LimitPosition();
        }
        else if (isDownRightArrow)
        {
            //Debug.Log("������ ȭ��ǥ Ű�� �������ϴ�.");

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
        Debug.Log($"���ظ� �޾ҽ��ϴ�. {this.hp}/{this.maxHp}");

        //=====> 90/100

        if (hp <= 0)
        {
            hp = 0;
            Debug.Log("<color=yellow>���� ����</color>");
            isGameOver = true;
            arrowGenerator.StopGenerate();
        }

        //���� ü�� / �ִ� ü�� 
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
