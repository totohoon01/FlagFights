using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SerialObject : MonoBehaviour, IPunObservable
{
    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();

    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
            stream.SendNext(tr.position);
        else
        {
            Vector3 receivePos = (Vector3)stream.ReceiveNext();
        }
    }
}
