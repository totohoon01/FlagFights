using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    //START버튼 누르면 유저에게 각각 아바타 할당, MAP씬, INFO씬 로딩

    public TMP_Text masterIDText;
    public TMP_Text userIDText;
    public TMP_Text[] playerSeat = null;


    void Awake()
    {
        if (string.IsNullOrEmpty(PhotonNetwork.NickName))
        {
            PhotonNetwork.NickName = $"USER_{Random.Range(0, 100)}";
        }
        masterIDText.text = PhotonNetwork.MasterClient.NickName;
        userIDText.text = PhotonNetwork.NickName;
    }
    void LateUpdate()
    {
        RefreshUsers();
    }
    void RefreshUsers()
    {
        int count = 0;
        foreach (var player in PhotonNetwork.PlayerList)
        {
            playerSeat[count].text = player.NickName;
            count += 1;
        }

    }
    #region PHOTON_CALLBACKS
    // public override void OnPlayerEnteredRoom(Player newPlayer)
    // {
    //     foreach (var seat in playerSeat)
    //     {
    //         if (string.IsNullOrEmpty(seat.text))
    //         {
    //             //비어있으면!
    //             seat.text = newPlayer.NickName;
    //             break;
    //         }
    //     }
    // }
    // public override void OnPlayerLeftRoom(Player otherPlayer)
    // {
    //     foreach (var seat in playerSeat)
    //     {
    //         if (seat.text == otherPlayer.NickName)
    //         {
    //             seat.text = null;
    //             break;
    //         }
    //     }
    // }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("LobbyScene"); //리브룸이랑 따로호출할것 느림
    }
    #endregion

    #region UI_BUTTON_CALLBACKS
    public void OnExitButtonClick()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void OnStartButtonClick()
    {
        photonView.RPC("LoadGameScene", RpcTarget.All, null);
    }

    [PunRPC]
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("GameInfoScene", LoadSceneMode.Additive);
    }
    #endregion
}
