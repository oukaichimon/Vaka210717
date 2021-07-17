using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Kato_Color : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private MeshRenderer[] colorTargets;
    [SerializeField]
    private Material[] materials;

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                photonView.RPC(nameof(ColorChange1), RpcTarget.All);           
            }
    }
    [PunRPC]
    public void ColorChange1()
    {
        foreach(MeshRenderer mesh in colorTargets)
        {
            mesh.material = materials[Random.Range(0, materials.Length)];
        }  
    }
}
