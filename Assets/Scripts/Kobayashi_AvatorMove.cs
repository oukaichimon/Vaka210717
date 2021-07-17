using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Kobayashi_AvatorMove : MonoBehaviourPunCallbacks
{

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
        }
    }
}
