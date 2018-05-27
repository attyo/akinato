using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChildButton : ButtonCtrl {
    private kutti kuttie;

    protected override void OnTap(string objectName)
    {
        if (objectName == "もどる")
            ReturnButtonClick();
        else
            ChoicesButtonClick(objectName);
    }
    
    private void Start()
    {
        kuttie = GetComponent<kutti>();
        kuttie.num_changed();
    }

    private void ChoicesButtonClick(string Clicked_button)
    {
        // 条件を設定
        kuttie.setQuary(Clicked_button);
        // メニュー番号を進める
        kuttie.menu_nam++;
        // メニュー番号によってUIを切り替える
        kuttie.num_changed();
        //Debug.Log("Choices Click");
    }
    private void ReturnButtonClick()
    {
        if (kuttie.menu_nam > 0)
        {
            // メニュー番号を戻す
            kuttie.menu_nam--;
            // メニュー番号によってUIを切り替える
            kuttie.num_changed();
            //Debug.Log("もどる Click");
        }
    }
}