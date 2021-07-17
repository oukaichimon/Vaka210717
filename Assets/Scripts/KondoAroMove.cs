using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
    
public class KondoAroMove : MonoBehaviourPunCallbacks
{
    [SerializeField] private float MoveSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            Vector3 v = new Vector3(
                Input.GetAxis("Horizontal") * Time.deltaTime,
                0,
                Input.GetAxis("Vertical") * Time.deltaTime);


            transform.position += v;
        }
    }
}
