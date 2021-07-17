using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Kat_Move : MonoBehaviourPunCallbacks
{
    [SerializeField] private float MoveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            var v3 = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * MoveSpeed,
                0,
                Input.GetAxis("Vertical") * Time.deltaTime * MoveSpeed);
            transform.position += v3;
        }
    }
}
