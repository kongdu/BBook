﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public enum StageState { PRESTAGE, INGAME, ENDGAME, GAMEOVER }

    public Text timeText;
    public Text scoreText;
    public GameObject announcePanel;

    //밸런스 수치
    public float announceTime = 5f;
    public float deadline = 20f;
    public float scorePerTime = 10;
    public float scorePerStage = 2;

    public int stage = 1;
    public int booksToClear;
    
    public List<Dictionary<string, object>> stageData = null;

    float currTime;
    float score = 0;
    Coroutine timeRoutine;
    StageState _state = StageState.PRESTAGE;

    private void Awake()
    {
        stageData = CSVReader.Read("LibraryEarthquakeLevel");
    }

    private void Start()
    {
        int colorVari = (int)stageData[stage]["Color"];
        int languageVari = (int)stageData[stage]["Language"];
        BookManager.Instance.SetBooksProp(colorVari, languageVari);
    }

    public void PrestageStart()
    {
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        currTime = deadline;
        booksToClear = (int)stageData[stage]["DropBooks"];

        ShowAnnounce();
        yield return new WaitForSeconds(announceTime);
        StartCoroutine(CallEarthQuake());
        yield return new WaitForSeconds(2f);
        announcePanel.SetActive(false);
        //지진이 끝남을 받음
        StartStage();
    }

    void ShowAnnounce()
    {
        announcePanel.SetActive(true);
    }

    public void ClearBook()
    {
        if(_state == StageState.INGAME)
        {
            float stageScore = stage * scorePerStage;
            float timeScore = currTime * scorePerTime;
            score += stageScore + timeScore;
            scoreText.text = score.ToString("0");
            booksToClear--;
            if (booksToClear == 0)
            {
                StageClear();
            }
        }
    }
    
    /// <summary>
    /// 지진이펙트를 부르고, 거기에 떨어뜨릴 책의 수를 전달.
    /// </summary>
    IEnumerator CallEarthQuake()
    {
        //전달할 int는 (int)stageData[stage][DropBooks]
        yield return new WaitForSeconds(2f);
        Debug.Log("지진 끝");
    }

    void StartStage()
    {
        currTime = deadline;
        timeText.text = currTime.ToString("00.00");
        Debug.Log("스테이지 시작");
        _state = StageState.INGAME;
        timeRoutine = StartCoroutine(TimeCheck());
    }

    IEnumerator TimeCheck()
    {
        if(_state==StageState.INGAME)
        {
            while (currTime >= 0)
            {
                currTime -= Time.deltaTime;
                timeText.text = currTime.ToString("00.00");
                yield return new WaitForSeconds(0.01f);
            }
        }
        _state = StageState.GAMEOVER;
        GameOver();
    }

    public void StageClear()
    {
        StopCoroutine(timeRoutine);
        _state = StageState.ENDGAME;
        //GameManager에 score 전달
        Debug.Log("클리어");
    }

    public void NextStage()
    {
        _state = StageState.INGAME;
        stage++;
        currTime = deadline;
    }

    public void GameOver()
    {
        Debug.Log("게임오버");
        //GameManager에 score 전달. 스코어보드는 게임매니ㅏ저가?
    }
}
