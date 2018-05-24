using UnityEngine;
using System.Collections;

public class BoardGameMasterTable : MasterTableBase<BoardGameMaster>
{
    private static readonly string FilePath = "BoardGameDataForUnity";
    public void Load() { Load(FilePath); }
}

public class BoardGameMaster : MasterBase
{
    public string english { get; private set; }
    public string japanese { get; private set; }
    public string headcount { get; private set; }
    public string time { get; private set; }
    public string difficulty { get; private set; }
    public string lucky { get; private set; }
    public string communication { get; private set; }
    public string card { get; private set; }
    public string forBeginner { get; private set; }
}