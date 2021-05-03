using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomData : MonoBehaviour
{
    private PhotonManager photonManager;

    private TMP_Text roomInfoText;
    private RoomInfo _roomInfo;
    public RoomInfo RommInfo
    {
        get
        {
            return _roomInfo;
        }
        set
        {
            _roomInfo = value;
            roomInfoText.text = $"{_roomInfo.Name} ({RommInfo.PlayerCount}/{RommInfo.MaxPlayers})";

            //Button Click Event
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnEnterRoom(_roomInfo.Name));
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        roomInfoText = GetComponentInChildren<TMP_Text>();
        photonManager = GameObject.Find("PhotonManager").GetComponent<PhotonManager>();
    }
    void OnEnterRoom(string roomName)
    {
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 4;

        PhotonNetwork.NickName = photonManager.userId.text;

        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
    }
}
