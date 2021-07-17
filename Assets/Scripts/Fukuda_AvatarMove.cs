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

            //�ړ�����
            transform.position += v;


            //PhotonView�ɑ΂��ă��b�Z�[�W���M
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //nameof�Ń��\�b�h�̕�������擾�ł���
                //RpcTarget.All�Ŏ������܂ޑS�ẴA�o�^�[�Ƀ��b�Z�[�W�𓊂���
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

    //PhotonView���烁�b�Z�[�W�󂯎��
    //PunRPC���������Ȃ��ƁA���b�Z�[�W���󂯎��Ȃ�
    [PunRPC]
    void SetColor(int colorNum)
    {
        mesh.material = colors[colorNum];
    }
}
