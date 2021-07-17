using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Nagao_AvatorMove : MonoBehaviourPunCallbacks
{
    [SerializeField] private float moveSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            Vector3 v3 = new Vector3(
                Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed,
                0,
                Input.GetAxis("Vertical")*Time.deltaTime*moveSpeed);
            transform.position += v3;
        };
    }
}
