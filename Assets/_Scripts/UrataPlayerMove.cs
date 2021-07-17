using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UrataPlayerMove : MonoBehaviourPunCallbacks
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotSpeed = 100f;

    private MeshRenderer meshRenderer;
    [SerializeField] float duration = 2f;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
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

            Quaternion rot = Quaternion.AngleAxis(Time.deltaTime * rotSpeed, Vector3.up);
            transform.rotation = rot * transform.localRotation;

            photonView.RPC("SetColor", RpcTarget.All);
        }

    }

    [PunRPC]
    void SetColor()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amp = Mathf.Cos(phi) * .5f + .5f;
        meshRenderer.material.color = Color.HSVToRGB(amp, 1, 1);
    }
}
