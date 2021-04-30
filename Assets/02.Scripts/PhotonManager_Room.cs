using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PhotonManager_Room : MonoBehaviourPunCallbacks
{
    public TMP_Text userId;

    void Awake()
    {
        userId.text = PhotonNetwork.NickName;
    }

    //방
    #region PHOTON_CALLBACKS
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("LobbyScene");
    }
    #endregion

    #region UI_BUTTON_CALLBACKS
    public void OnExitRoomClick()
    {
        PhotonNetwork.LeaveRoom();
    }
    #endregion
}
