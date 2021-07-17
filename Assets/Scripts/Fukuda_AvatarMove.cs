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

            //移動する
            transform.position += v;


            //PhotonViewに対してメッセージ発信
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //nameofでメソッドの文字列を取得できる
                //RpcTarget.Allで自分を含む全てのアバターにメッセージを投げる
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

    //PhotonViewからメッセージ受け取り
    //PunRPC属性をつけないと、メッセージを受け取れない
    [PunRPC]
    void SetColor(int colorNum)
    {
        mesh.material = colors[colorNum];
    }
}
