using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Nagao_AvatorMove : MonoBehaviourPunCallbacks
{
    private MeshRenderer mesh;
    public Material[] colors;
    private float moveSpeed = 20f;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            Vector3 v = new Vector3(
                Input.GetAxis("Horizontal") * moveSpeed*Time.deltaTime,
                0,
                Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

            //?ړ?????
            transform.position += v;


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                photonView.RPC(nameof(SetColor), RpcTarget.All, 0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                photonView.RPC(nameof(SetColor), RpcTarget.All, 1);

            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {

                photonView.RPC(nameof(SetColor), RpcTarget.All, 2);

            }
        }

    }

    [PunRPC]
    void SetColor(int colorNum)
    {
        mesh.material = colors[colorNum];
    }
}
