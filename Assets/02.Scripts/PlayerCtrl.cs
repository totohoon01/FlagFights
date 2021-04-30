using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Transform playerTr;
    private Animator plyerAnim;
    private Rigidbody playerRb;
    public float moveSpeed = 50.0f;
    public float rotateSpeed = 20.0f;
    public float jumpPower = 5.0f;
    public bool isWin = false;

    //Get Hash
    private readonly int hashRun = Animator.StringToHash("isRun");
    private readonly int hashJump = Animator.StringToHash("triJump");
    private readonly int hashFall = Animator.StringToHash("isFall");
    private readonly int hashWin = Animator.StringToHash("triWin");
    private readonly int hashLose = Animator.StringToHash("triLose");

    void Start()
    {
        playerTr = GetComponent<Transform>();
        plyerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
        Fall();

        //temp for anim check
        if (GameManager.isGameEnd)
        {
            GameEndAnim();
            GameManager.isGameEnd = false;
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

        if (transform.position.y < -2.0f)
            plyerAnim.SetBool(hashFall, true);

        if (playerTr.position.y < -20.0f)
        {
            plyerAnim.SetBool(hashFall, false);
        }
    }

    void GameEndAnim()
    {
        if (isWin)
        {
            plyerAnim.SetTrigger(hashWin);
        }
        else
        {
            plyerAnim.SetTrigger(hashLose);
        }
    }
    #endregion
}
