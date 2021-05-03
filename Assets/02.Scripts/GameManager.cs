using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityStandardAssets.Utility;

//게임 전체 관리하는 스크립트//
//싱글턴으로 사용//


public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private int timeLimit = 100;
    public static string flagOwner = "Nobody";
    public static bool isGameEnd = false;


    [Header("UI TEXTs")]
    public TMP_Text flagOwnerInfo;
    public TMP_Text timeInfo;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        PhotonNetwork.IsMessageQueueRunning = true;
        StartCoroutine(SetTimeInfo());
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
        GameEnd();
        isGameEnd = true;
        flagOwnerInfo.text = $"<color=#FF0000>\"{flagOwner}\"</color> Wins this Game!!!";
        Invoke("ReturnToLobby", 5.0f);
    }

    void GameEnd()
    {
        //승리한 플레이어 포커싱
        Camera.main.GetComponent<SmoothFollow>().target = GameObject.FindGameObjectWithTag("FLAG").GetComponentInParent<Transform>();
        Camera.main.GetComponent<SmoothFollow>().distance = 5.0f;
        GameObject.FindGameObjectWithTag("FLAG")?.GetComponentInParent<Animator>().SetTrigger("triWin");
    }
    void ReturnToLobby()
    {
        PhotonNetwork.LoadLevel("RoomScene");
    }
}
