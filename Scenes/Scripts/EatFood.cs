using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    // private OVRInput.Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        // controller = GetComponent<OVRControllerHelper>().m_controller;
    }

    /** 別のCollider(other)に触れている間実行 **/
    void OnTriggerStay(Collider other) {
        if (other.tag == "Food") {
            Destroy(other);
        }
    }
}
