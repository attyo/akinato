using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodogeImage : MonoBehaviour {
    private Image boImage;
	// Use this for initialization
	void Start () {
        boImage = GetComponent<Image>();
        //ボドゲの画像を表示(Textchange.csの中にある変数bodoge_numを参照)
        boImage.sprite = Resources.Load<Sprite>("icons/p"+Textchange.bodoge_num);
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
