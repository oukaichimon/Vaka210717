using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Fukuda_AvatarMove : MonoBehaviourPunCallbacks
{

    private MeshRenderer mesh;

    public Material[] colors;

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
                Input.GetAxis("Horizontal") * Time.deltaTime,
                0,
                Input.GetAxis("Vertical") * Time.deltaTime);

            //ˆÚ“®‚·‚é
            transform.position += v;


            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                photonView.RPC("SetColor", RpcTarget.All, 0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                photonView.RPC("SetColor", RpcTarget.All, 0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                photonView.RPC("SetColor", RpcTarget.All, 0);
            }
        }

    }

    [PunRPC]
    void SetColor(int colorNum)
    {
        mesh.material = colors[colorNum];
    }
}
