using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject whiteArrowPrefab;
    public GameObject redArrowPrefab;

    private const int MIN_DAMAGE = 1;
    private const int MAX_DAMAGE = 10;
    private const float MIN_MOVE_SPPED = 1f;
    private const float MAX_MOVE_SPPED = 1.5f;

    private float elapsedTime;  //경과시간 

    private bool isStop = false;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (isStop) return;

        this.elapsedTime += Time.deltaTime;

        //Debug.Log($"{this.elapsedTime}초 경과됨...");

        if (this.elapsedTime > 1f)
        {
            this.CreateArrow();
            this.elapsedTime = 0;
        }
    }

    private void CreateArrow()
    {
        float damage = Random.Range(MIN_DAMAGE, MAX_DAMAGE + 1);
        float moveSpeed = Random.Range(MIN_MOVE_SPPED, MAX_MOVE_SPPED);

        GameObject arrowGo = null;

        if (damage >= 10)
        {
            arrowGo = Object.Instantiate(redArrowPrefab);
        }
        else 
        {
            arrowGo = Object.Instantiate(whiteArrowPrefab);
        }
        
        ArrowController arrowController = arrowGo.GetComponent<ArrowController>();


        arrowController.Init(damage, moveSpeed);

        float randomPosX = Random.Range(-8.0f, 8.0f);
        arrowGo.transform.position = new Vector3(randomPosX, 6.5f, 0);
    }

    public void StartGenerate()
    {
        Debug.Log("화살 생성을 시작 합니다.");
    }

    public void StopGenerate()
    {
        this.isStop = true;
        Debug.Log("화살 생성을 종료 합니다.");
    }
}
