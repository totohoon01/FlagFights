using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

//게임 전체 관리하는 스크립트//
//싱글턴으로 사용//


public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private static int timeLimit = 10;
    public static string flagOwner = "Nobody";
    public static bool isGameEnd = false;

    //랜덤할당쓰
    public static string[] models = new string[] { "cat", "dog", "rat", "turtle" };


    [Header("UI TEXTs")]
    public TMP_Text flagOwnerInfo;
    public TMP_Text timeInfo;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        StartCoroutine(SetTimeInfo());
    }
    void Update()
    {
    }
    void SetOwnerInfo()
    {
        flagOwnerInfo.text = $"<color=#FF0000>\"{flagOwner}\"</color> has FLAG NOW!!";
    }
    IEnumerator SetTimeInfo()
    {
        while (timeLimit > 0)
        {
            yield return new WaitForSeconds(1.0f);
            SetOwnerInfo();
            timeLimit -= 1;
            timeInfo.text = $"Time : {timeLimit.ToString():000}";
        }
        isGameEnd = true;
        flagOwnerInfo.text = $"<color=#FF0000>\"{flagOwner}\"</color> Wins this Game!!!";
        Invoke("ReturnToLobby", 5.0f);
    }
    void ReturnToLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
