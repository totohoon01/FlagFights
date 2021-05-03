using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/*
    GameInfoScene에 포함
    씬이 로딩될때 생성됨.
*/

public class ObjectManager : MonoBehaviourPunCallbacks
{
    private string[] modelList = new string[] { "cat", "dog", "rat", "turtle" };
    void Start()
    {
        GeneratePlayer();
    }

    void GeneratePlayer()
    {
        Vector3 pos = new Vector3(Random.Range(-30.0f, 30.0f), 5.0f, Random.Range(-30.0f, 30.0f));
        int idx = Random.Range(0, 4);
        PhotonNetwork.Instantiate(modelList[idx], pos, Quaternion.identity, 0);
    }
}
