using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float moveSpeed = 0.001f;
    private int dir = -1;
    public float radius = 1f;
    public Transform playerTrans;

    private void Start()
    {
        //길이 
        //Vector3 c = playerTrans.position - this.transform.position;
        //float d1 = c.magnitude;

        //float d2 = Mathf.Abs(playerTrans.position.y - this.transform.position.y);
    }

    void Update()
    {
        this.transform.Translate(0, dir * moveSpeed, 0);

        bool isCollided = this.CheckCollsion();

        if (isCollided) 
        {
            Object.Destroy(this.gameObject);
        }

        if (this.transform.position.y <= -6.36f)
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        GizmosExtensions.DrawWireArc(this.transform.position, 360, radius);
    }

    //충돌체크를 한후에 충돌이 되었다면 true를 반환 
    private bool CheckCollsion()
    {
        float distance = Vector3.Distance(playerTrans.position, this.transform.position);

        PlayerController playerController = this.playerTrans.gameObject.GetComponent<PlayerController>();

        float sumRadius = this.radius + playerController.radius;
        Debug.Log($"{distance}, {sumRadius}");

        if (distance <= sumRadius)
        {
            Debug.Log("충돌했습니다.");
            return true;
        }
        else
        {
            Debug.Log("충돌안했습니다.");
            return false;
        }
    }
}
