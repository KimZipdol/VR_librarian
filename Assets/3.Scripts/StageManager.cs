using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static StageManager _instance = null;
    public static StageManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(StageManager)) as StageManager;

                if (_instance == null)
                {
                    Debug.LogError("There's no active StageManager Object");
                }
            }
            return _instance;
        }
    }

    public enum StageState { PRESTAGE, ANNOUNCE, EARTHQUAKE, GAME, RESULT, CLEAR, GAMEOVER }

    public float announceTime = 5f;
    public float deadline = 20f;
    public int stage = 1;
    public StageState stageState = StageState.PRESTAGE;

    List<Dictionary<string, object>> stageData = null;

    private void Awake()
    {
        stageData = CSVReader.Read("LibraryEarthquakeLevel");
    }

    private void Start()
    {
        BookManager.Instance.SetBooksProp((int)stageData[stage]["Color"], (int)stageData[stage]["Language"]);
    }

    void GameStart()
    {
        CallEarthQuake();
    }
    
    /// <summary>
    /// 지진이펙트를 부르고, 거기에 떨어뜨릴 책의 수를 전달.
    /// </summary>
    void CallEarthQuake()
    {
        //전달할 int는 (int)stageData[stage][DropBooks]
    }

    
}
