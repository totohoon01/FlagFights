using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 전체 관리하는 스크립트//
//싱글턴으로 사용//


public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private static int timeLimit = 300;
    public static string flagOwner = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
