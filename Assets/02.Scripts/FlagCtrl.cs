using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlagCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            transform.SetParent(coll.transform);
            transform.position = transform.parent.position;
            transform.rotation = transform.parent.rotation;
            foreach (var mesh in GetComponentsInChildren<MeshRenderer>())
            {
                mesh.enabled = false;
            }
            GetComponentInChildren<TMP_Text>().enabled = true;
            //해당 오브젝트의 차일드로 들어간다.
            //깃발을 숨기고
            //해당 플레이어의 머리 위에 깃발 소유여부 표시!
        }
    }
}
