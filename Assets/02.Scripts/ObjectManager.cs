using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ObjectManager : MonoBehaviourPunCallbacks
{

    private string[] modelsList = new string[] { "cat", "dog", "rat", "turtle" };
    void Start()
    {
        GeneratePlayer();
    }
    void GeneratePlayer()
    {
        Vector3 pos = new Vector3(Random.Range(-10.0f, 10.0f), 5.0f, Random.Range(-10.0f, 10.0f));
        int model = Random.Range(0, 4);
        PhotonNetwork.Instantiate(modelsList[model], pos, Quaternion.identity, 0);
    }
}
