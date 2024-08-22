using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatController : MonoBehaviour
{

    public Button btnR;

    void Start()
    {
        btnR.onClick.AddListener(() => {
            Debug.Log("오른쪽 버튼 클릭됨");

            this.transform.Translate(1, 0, 0);
        });
    }

    public void LeftButtonClick()
    {
        Debug.Log("왼쪽 버튼 클릭됨");
        this.transform.Translate(-1, 0, 0);
    }
}
