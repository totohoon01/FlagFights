using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlagCtrl : MonoBehaviour
{

    //중립 깃발 획득로직, 0.2초로 딜레이줌
    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            StartCoroutine(TakeFlag(coll));

            //현재 깃발가진사람
            GameManager.flagOwner = coll.transform.name;
        }
    }
    IEnumerator TakeFlag(Collider coll)
    {
        yield return new WaitForSeconds(0.2f);
        transform.SetParent(coll.transform);
        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
        foreach (var mesh in GetComponentsInChildren<MeshRenderer>())
        {
            mesh.enabled = false;
        }
        GetComponentInChildren<TMP_Text>().enabled = true;
    }
}
