using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class suggest : MonoBehaviour {
    [SerializeField]
    private Text dataText;
    [SerializeField]
    private TextAsset textasset;
    [SerializeField]
    private Image boImage;

    private string loadtext;
    private string[] splitText;
    void Awake() {
        boImage.material.mainTexture = null;    
    }
    // Use this for initialization
    void Start () {
        //前のシーンでのボドゲナンバーを表示
        //GetComponent<Text>().text = Textchange.bodoge_num.ToString();
        dataText.text = "";
        kutti.results.ForEach(x => dataText.text = x);
        if(dataText.text == "") dataText.text = "…といって無いよ！残念！";
        else boImage.material.mainTexture = Resources.Load<Texture2D>("icons/" + dataText.text);

        Debug.Log(dataText.text);

        //loadtext = textasset.text;
        //splitText = loadtext.Split(char.Parse("\n"));

    }
	
	// Update is called once per frame
	void Update () {
        //dataText.text = splitText[Textchange.bodoge_num];

	}
}
