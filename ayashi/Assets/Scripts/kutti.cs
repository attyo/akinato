using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class kutti : MonoBehaviour {
    private Format format;
    public int menu_nam;
    private Vector3[] twice;
    private Vector3[] third;
    private GameObject prefab;
    private List<int> num_button;
    [SerializeField]
    private GameObject button;
    private GameObject parent;
    public int length;

    private const string strYes = "はい";
    private const string strNo = "いいえ";
    private const string strAgree = "そう思う";
    private const string strSoso = "中間くらい";
    private const string strDisagree = "そう思わない";

    private BOlist boardGameMasterTable;

    private string[] query;
    public static List<string> results;

    public void getResult() {
        results = new List<string>();
        foreach(var q in query) {
            Debug.Log(q);
        }
        boardGameMasterTable.sheets[0].list
            .FindAll(x => (query[0] == "" || x.headcount == query[0]) 
                && x.time == query[1]
                && x.difficulty == query[2]
                && x.lucky == query[3]
                && x.communication == query[4]
                && x.card == query[5]
                && x.forBeginner == query[6])
            .ForEach(x => results.Add(x.japanese));

        if(results.Count == 0) Debug.Log("No pattern");
        else foreach(var e in results)  Debug.Log(e);
    }

    private void Awake()
    {
        format = Resources.Load("format") as Format;
        DontDestroyOnLoad(format);
        boardGameMasterTable = Resources.Load("BoardGameDataForUnity") as BOlist;
        DontDestroyOnLoad(boardGameMasterTable);

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
        query = new string[length];
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
                prefab.name = strYes;
                prefab.transform.SetParent(parent.transform, false);
                prefab.transform.GetComponentInChildren<Text>().text = strYes;

                prefab = Instantiate(button, twice[1], Quaternion.identity);
                prefab.name = strNo;
                prefab.transform.SetParent(parent.transform, false);
                prefab.transform.GetComponentInChildren<Text>().text = strNo;
            }
            else if (format.sheets[0].list[menu_nam].num_button == 3)
            {
                prefab = Instantiate(button, third[0], Quaternion.identity);
                prefab.name = strAgree;
                prefab.transform.SetParent(parent.transform, false);
                prefab.transform.GetComponentInChildren<Text>().text = strAgree;

                prefab = Instantiate(button, third[1], Quaternion.identity);
                prefab.name = strSoso;
                prefab.transform.SetParent(parent.transform, false);
                prefab.transform.GetComponentInChildren<Text>().text = strSoso;

                prefab = Instantiate(button, third[2], Quaternion.identity);
                prefab.name = strDisagree;
                prefab.transform.SetParent(parent.transform, false);
                prefab.transform.GetComponentInChildren<Text>().text = strDisagree;
            }
        }
    }

    public void setQuary(string buttonName) {
        query[menu_nam] = "";
        switch(menu_nam) {
            case 0:
                if(buttonName == strAgree) {
                    query[menu_nam] = "many";
                } else if(buttonName == strSoso) {
                    query[menu_nam] = "";
                } else if(buttonName == strDisagree) {
                    query[menu_nam] = "aFew";
                }
                break;
            case 1:
                if(buttonName == strAgree) {
                    query[menu_nam] = "short";
                } else if(buttonName == strSoso) {
                    query[menu_nam] = "medium";
                } else if(buttonName == strDisagree) {
                    query[menu_nam] = "long";
                }
                break;
            case 2:
                if(buttonName == strAgree) {
                    query[menu_nam] = "hard";
                } else if(buttonName == strSoso) {
                    query[menu_nam] = "normal";
                } else if(buttonName == strDisagree) {
                    query[menu_nam] = "easy";
                }
                break;
            case 3:
                if(buttonName == strAgree) {
                    query[menu_nam] = "luck";
                } else if(buttonName == strSoso) {
                    query[menu_nam] = "medium";
                } else if(buttonName == strDisagree) {
                    query[menu_nam] = "skill";
                }
                break;
            case 4:
                if(buttonName == strAgree) {
                    query[menu_nam] = "individual";
                } else if(buttonName == strSoso) {
                    query[menu_nam] = "medium";
                } else if(buttonName == strDisagree) {
                    query[menu_nam] = "communicative";
                }
                break;
            case 5:
                if(buttonName == strYes) {
                    query[menu_nam] = "yes";
                } else if(buttonName == strNo) {
                    query[menu_nam] = "no";
                }
                break;
            case 6:
                if(buttonName == strYes) {
                    query[menu_nam] = "no";
                } else if(buttonName == strNo) {
                    query[menu_nam] = "yes";
                }
                break;
            default:
                Debug.Log("Error");
                break;
        }
        //Debug.Log(query[menu_nam]);
    } 
}
