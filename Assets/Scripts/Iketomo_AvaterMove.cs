using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Iketomo_AvaterMove : MonoBehaviourPunCallbacks
{
    [SerializeField] private float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            var v3 = new Vector3(
                Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed,
                0,
                Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);

            transform.position += v3;
        }   
    }
}
