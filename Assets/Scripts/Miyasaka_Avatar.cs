using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Miyasaka_Avatar : MonoBehaviourPunCallbacks
{
    [SerializeField] private float MoveSpeed = 5f;
    // Update is called once per frame

    public MeshRenderer mesh;

    public Material[] colors;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (photonView.IsMine)
        {
            Vector3 v = new Vector3(
                Input.GetAxis("Horizontal") * Time.deltaTime,
                0,
                Input.GetAxis("Vertical") * Time.deltaTime);


            transform.position += v;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                photonView.RPC("SetColor", RpcTarget.All, 0);
                SetColor(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                photonView.RPC("SetColor", RpcTarget.All, 1);
                SetColor(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                photonView.RPC("SetColor", RpcTarget.All, 2);
                SetColor(2);
            }
        }
    }

    [PunRPC]
    void SetColor(int colorNum)
    {
        mesh.material = colors[colorNum];
    }
}