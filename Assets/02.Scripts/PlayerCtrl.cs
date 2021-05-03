using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using Photon.Pun;
using Photon.Realtime;

public class PlayerCtrl : MonoBehaviour
{
    private Transform playerTr;
    private Animator plyerAnim;
    private Rigidbody playerRb;
    public float moveSpeed = 50.0f;
    public float rotateSpeed = 20.0f;
    public float jumpPower = 5.0f;

    //Get Hash
    private readonly int hashRun = Animator.StringToHash("isRun");
    private readonly int hashJump = Animator.StringToHash("triJump");
    private readonly int hashFall = Animator.StringToHash("isFall");

    //포톤
    private PhotonView pv;

    void Start()
    {
        playerTr = GetComponent<Transform>();
        plyerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();

        if (pv.IsMine)
        {
            Camera.main.GetComponent<SmoothFollow>().target = playerTr.transform;
        }
        else
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void Update()
    {
        if (pv.IsMine)
        {
            Move();
            Jump();
            Fall();
        }
    }

    #region PLAYER_ACTION_LOGICS
    void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        playerTr.Translate(Vector3.forward * Time.deltaTime * moveSpeed * v);
        playerTr.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * h);
        if (v >= 0.1f || v <= -0.1f)
        {
            plyerAnim.SetBool(hashRun, true);
        }
        else
        {
            plyerAnim.SetBool(hashRun, false);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (transform.position.y < 1.0f && transform.position.y > -1.0f)
                playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            plyerAnim.SetTrigger(hashJump);
        }

    }
    void Fall()
    {

        if (transform.position.y < -5.0f)
            plyerAnim.SetBool(hashFall, true);
        else
        {
            plyerAnim.SetBool(hashFall, false);
        }
    }
    #endregion
}
