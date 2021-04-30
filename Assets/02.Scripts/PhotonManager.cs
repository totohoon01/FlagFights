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
    public override void OnJoinedLobby()
    {
        print("Joined to Lobby!");
    }
    public override void OnCreatedRoom()
    {
        print("방 생성");
        // PhotonNetwork.LoadLevel("RoomScene"); //룸생성, 룸씬 로딩
    }
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel("RoomScene"); //룸생성, 룸씬 로딩
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject tempRoom = null;
        foreach (var room in roomList)
        {
            //룸이 삭제된 경우 -> 딕셔너리에서 삭제, 프리팹 삭제
            if (room.RemovedFromList == true)
            {
                roomDict.TryGetValue(room.Name, out tempRoom);
                roomDict.Remove(room.Name);
                Destroy(tempRoom);
            }
            //룸 정보 변경, 갱신
            else
            {
                //처음 생성된 경우, 딕셔너리에 데이터 추가, 프리팹 생성
                if (roomDict.ContainsKey(room.Name) == false)
                {
                    GameObject _room = Instantiate(roomPrefabs, scrollContents);
                    _room.GetComponent<RoomData>().RommInfo = room;
                    roomDict.Add(room.Name, _room);
                }
                //아니면 룸 정보를 갱신
                else
                {
                    roomDict.TryGetValue(room.Name, out tempRoom);
                    tempRoom.GetComponent<RoomData>().RommInfo = room;
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
        // print(PhotonNetwork.NickName);

        PhotonNetwork.CreateRoom(roomName, ro);
    }
    #endregion
}
