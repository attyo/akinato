using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : MonoBehaviour {

    public ButtonCtrl button;

    private void Start()
    {
        button = GameObject.Find("ChildButtonCtrl").GetComponent<ChildButton>();
    }

    public void OnTap()
    {
        if (button == null)
        {
            throw new System.Exception("Button instance is null!!");
        }
        // 自身のオブジェクト名を渡す
        button.OnTap(this.gameObject.name);
    }

    protected virtual void OnTap(string objectName)
    {
        // 呼ばれることはない
        Debug.Log("Base Button");
    }
}