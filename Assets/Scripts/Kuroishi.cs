using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;//Unityでフォトンを使うため
using Photon.Realtime;//Photonになぐ



public class Kuroishi : MonoBehaviourPunCallbacks
{
    float move = 5f;
    Vector3 pos;
    float x;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            x = Input.GetAxis("Horizontal") * Time.deltaTime * move;
            z = Input.GetAxis("Vertical") * Time.deltaTime * move;
            pos = new Vector3(x, 0, z);
            transform.position += pos;

            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.localScale = new Vector3(2, 2, 2);
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
