using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Textchange : MonoBehaviour {
    [SerializeField]
    private Text dataText;
    [SerializeField]
    private GameObject child;
    [SerializeField]
    private kutti Menue;
    public static int bodoge_num=4;
    private Format format;

    // Use this for initialization
    void Start () {
        dataText.text = "ここに質問がドバドバ";
        format = Resources.Load("format") as Format;
    }
	
	// Update is called once per frame
	void Update () {
        //とりあえず問題番号が今あるだけの質問の数を超えたらシーン遷移
        if (Menue.menu_nam >= Menue.length)
        {
            Debug.Log("次のシーンはボ提案フェイズ");
            //最終的におすすめするボドゲのナンバーを渡す
            //bodoge_num =;
            SceneManager.LoadScene("suggest");
            Menue.menu_nam = Menue.length - 1;
        }
        //問題番号がマイナス行かないようにする
        if (Menue.menu_nam < 0) Menue.menu_nam = 0;
        //表示してる質問
        dataText.text = format.sheets[0].list[Menue.menu_nam].content;

        //問題番号を表示
        child.GetComponent<Text>().text=Menue.menu_nam+1+"番目の質問";
        
	}
}
