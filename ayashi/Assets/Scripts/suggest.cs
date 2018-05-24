using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class suggest : MonoBehaviour {
    [SerializeField]
    private Text dataText;
    [SerializeField]
    private TextAsset textasset;

    private string loadtext;
    private string[] splitText;
    // Use this for initialization
    void Start () {
        //前のシーンでのボドゲナンバーを表示
        //GetComponent<Text>().text = Textchange.bodoge_num.ToString();
        loadtext = textasset.text;
        splitText = loadtext.Split(char.Parse("\n"));

    }
	
	// Update is called once per frame
	void Update () {
        dataText.text = splitText[Textchange.bodoge_num];

	}
}
