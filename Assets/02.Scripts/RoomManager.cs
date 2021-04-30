using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviourPunCallbacks
{
    // // 방에 입장함!
    //USER_ID 옆에 있는 텍스트 유저 이름으로 변경.
    //EXIT Room 누르면 방을 나감(로비 씬으로 전환)
    //들어와있는 유저 표시 유저 목록 받아서 유저 이름으로 전환 없으면 빈칸.
    //START버튼 누르면 유저에게 각각 아바타 할당, MAP씬, INFO씬 로딩

    public TMP_Text userIDText;
    public TMP_Text[] playerSeat = null;
    private int playerCount = 0;

    void Awake()
    {
        if (string.IsNullOrEmpty(PhotonNetwork.NickName))
        {
            PhotonNetwork.NickName = $"USER_{Random.Range(0, 100)}";
        }
        userIDText.text = PhotonNetwork.NickName;
    }
    #region PHOTON_CALLBACKS
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print(newPlayer.NickName);
        foreach (var seat in playerSeat)
        {
            if (string.IsNullOrEmpty(seat.text))
            {
                //비어있으면!
                seat.text = newPlayer.NickName;
                break;
            }
        }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        foreach (var seat in playerSeat)
        {
            if (seat.text == otherPlayer.NickName)
            {
                seat.text = null;
                break;
            }
        }
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("LobbyScene"); //리브룸이랑 따로호출할것 느림
    }
    #endregion

    #region UI_BUTTON_CALLBACKS
    public void OnExitButtonClick()
    {
        PhotonNetwork.LeaveRoom();
        // PhotonNetwork.Disconnect();
    }
    #endregion
}
