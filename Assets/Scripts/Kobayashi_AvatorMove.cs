using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Kobayashi_AvatorMove : MonoBehaviourPunCallbacks
{

    private MeshRenderer mesh;
    public Material[] colors;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (photonView.IsMine)
        {
            Vector3 v = new Vector3(
                Input.GetAxis("Horizontal") * Time.deltaTime,
                0,
                Input.GetAxis("Vertical") * Time.deltaTime);

            //à⁄ìÆÇ∑ÇÈÇ±Å[Ç«
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
