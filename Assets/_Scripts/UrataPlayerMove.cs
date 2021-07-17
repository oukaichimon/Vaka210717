using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UrataPlayerMove : MonoBehaviourPunCallbacks
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotSpeed = 100f;

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

        Quaternion rot = Quaternion.AngleAxis(Time.deltaTime * rotSpeed, Vector3.up);
        transform.rotation = rot * transform.localRotation;
    }
}
