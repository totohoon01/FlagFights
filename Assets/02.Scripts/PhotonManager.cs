using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "v1.0";

    public TMP_InputField userId;
    public GameObject roomPrefabs;
    public Transform scrollContents;

    private Dictionary<string, GameObject> roomDict = new Dictionary<string, GameObject>();

    void Awake()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    #region  PHOTON_CALLBACKS
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(); //로비로
    }
    public override void OnCreatedRoom()
    {
        print(PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("RoomScene"); //룸생성, 룸씬 로딩
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject tempRoom = null;
        foreach (var room in roomList)
        {
            if (room.RemovedFromList == true)
            {
                roomDict.TryGetValue(room.Name, out tempRoom);
                roomDict.Remove(room.Name);
                Destroy(tempRoom);
            }
            else
            {
                if (roomDict.ContainsKey(room.Name) == false)
                {
                    GameObject _room = Instantiate(roomPrefabs, scrollContents);
                    _room.GetComponent<RoomData>().Ro
                }
            }
        }
    }
    #endregion

    #region BUTTON_CALLBACKS
    public void OnCreateRoomClick()
    {
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 4;
        string roomName = $"ROOM_{Random.Range(0, 100)}";

        if (string.IsNullOrEmpty(userId.text))
        {
            PhotonNetwork.NickName = $"USER_{Random.Range(0, 100)}";
        }
        else
        {
            PhotonNetwork.NickName = userId.text;
        }
        print(PhotonNetwork.NickName);

        PhotonNetwork.CreateRoom(roomName, ro);
    }

    #endregion
}
