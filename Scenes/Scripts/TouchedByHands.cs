// 食べられるネズミにアサインする
// プレイヤー（"OVRCameraRig"Collider）に触れられると消滅する
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchedByHands : MonoBehaviour
{
    RatController controller;
    Text obj;

    void Awake()
    {
        controller = GameObject.Find("RatController").GetComponent<RatController>();
        obj = GameObject.Find("Player/OVRCameraRig/TrackingSpace/CenterEyeAnchor/Canvas/Stock/Number").GetComponent<Text>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "OVRCameraRig")
        {
            Destroy(this.gameObject);            
            int tmp = int.Parse(obj.text) + 1;
            obj.text = tmp.ToString();
            controller.CreateRat();            
        }
    }
}
