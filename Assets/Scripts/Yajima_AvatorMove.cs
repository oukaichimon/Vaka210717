using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class Yajima_AvatorMove : MonoBehaviourPunCallbacks
{
    [SerializeField] private float moveSpeed = 5f;
    private MeshRenderer mesh;
    public Material[] colors;


    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }


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
