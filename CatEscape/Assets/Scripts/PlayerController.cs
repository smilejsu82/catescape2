using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float radius = 1f;

    void Update()
    {
        bool isDownLeftArrow = Input.GetKeyDown(KeyCode.LeftArrow);

        bool isDownRightArrow = Input.GetKeyDown(KeyCode.RightArrow);

        if (isDownLeftArrow)
        {
            Debug.Log("���� ȭ��ǥ Ű�� �������ϴ�.");
            this.transform.Translate(-1, 0, 0);
        }
        else if (isDownRightArrow)
        {
            Debug.Log("������ ȭ��ǥ Ű�� �������ϴ�.");
            this.transform.Translate(1, 0, 0);
        }

        
    }

    private void OnDrawGizmos()
    {
        GizmosExtensions.DrawWireArc(this.transform.position, 360, radius);
    }
}
