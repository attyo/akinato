using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChildButton : ButtonCtrl {

    private List<string> boardgameList;
    private List<string> List;
    private IEnumerable<string> boardAnswer;
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
        var boardGameMasterTable = new BoardGameMasterTable();
        boardGameMasterTable.Load();
        foreach (var boardGameMaster in boardGameMasterTable.All)
        {
            Debug.Log(boardGameMaster.english);
        }

        kuttie = GetComponent<kutti>();
        boardgameList = new List<string>();

        kuttie.num_changed();
    }

    private void ChoicesButtonClick(string Clicked_button)
    {
        kuttie.menu_nam++;
        kuttie.num_changed();
        Debug.Log("Choices Click");
    }
    private void ReturnButtonClick()
    {
        if (kuttie.menu_nam > 0)
        {
            kuttie.menu_nam--;
            kuttie.num_changed();
            Debug.Log("もどる Click");
        }
    }
}