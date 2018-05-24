using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kutti : MonoBehaviour {
    private BOlist bolist;
    private Format format;
    public int menu_nam;
    private Vector3[] twice;
    private Vector3[] third;
    private GameObject prefab;
    private List<string> question;
    private List<int> num_button;
    [SerializeField]
    private GameObject button;
    private GameObject parent;
    public int length;

    private void Awake()
    {
        format = Resources.Load("format") as Format;
        DontDestroyOnLoad(format);

        twice = new Vector3[] { new Vector3(-70, -120, 0), new Vector3(70, -120, 0) };
        third = new Vector3[] { new Vector3(-90, -120, 0), new Vector3(0, -120, 0), new Vector3(90, -120, 0) };

    }
    // Use this for initialization
    void Start() {
        menu_nam = 0;
        num_button = new List<int>();
        format.sheets[0].list.ForEach(x => {//各Listに列が入る
            num_button.Add(x.num_button);
        });
        length = format.sheets[0].list.Count;
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void num_changed()
    {
        length = format.sheets[0].list.Count; // Error 処理
        if (menu_nam < length)
        {
            Destroy(parent);
            parent = new GameObject("Parent");
            parent.transform.SetParent(GameObject.Find("Canvas").transform, false);

            if (format.sheets[0].list[menu_nam].num_button == 2)
            {
                prefab = Instantiate(button, twice[0], Quaternion.identity);
                prefab.transform.SetParent(parent.transform, false);
                prefab.transform.GetComponentInChildren<Text>().text = "はい";
                prefab = Instantiate(button, twice[1], Quaternion.identity);
                prefab.transform.SetParent(parent.transform, false);
                prefab.transform.GetComponentInChildren<Text>().text = "いいえ";
            }
            else if (format.sheets[0].list[menu_nam].num_button == 3)
            {
                prefab = Instantiate(button, third[0], Quaternion.identity);
                prefab.transform.SetParent(parent.transform, false);
                prefab.transform.GetComponentInChildren<Text>().text = "そう思う";
                prefab = Instantiate(button, third[1], Quaternion.identity);
                prefab.transform.SetParent(parent.transform, false);
                prefab.transform.GetComponentInChildren<Text>().text = "中間ぐらい";
                prefab = Instantiate(button, third[2], Quaternion.identity);
                prefab.transform.SetParent(parent.transform, false);
                prefab.transform.GetComponentInChildren<Text>().text = "そう思わない";
            }
        }
    }
}
