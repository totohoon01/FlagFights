using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerFall : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        //플레이어가 맵 밖으로 나갈경우, 깃발을 잃어버리고 깃발은 리스폰
        if (coll.collider.CompareTag("Player"))
        {
            coll.transform.position = new Vector3(0, 0, 0);
            if (coll.transform.Find("Flag"))
            {
                Transform flag = coll.transform.Find("Flag");
                flag.SetParent(null);
                flag.Translate(new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f)), Space.World);
                foreach (var mesh in flag.GetComponentsInChildren<MeshRenderer>())
                {
                    mesh.enabled = true;
                }
                flag.GetComponentInChildren<TMP_Text>().enabled = false;
            }
        }
    }
}
