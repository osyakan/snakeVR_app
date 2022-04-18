using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Biting : MonoBehaviour
{
    float sum_time;
    bool Enable_Acceration;
    bool Go_Acceration;
    public float Acceration_time = 0.3f;
    public GameObject bite_effect;
    CharacterController m_controller;
    Vector3 v_toward;
    // Start is called before the first frame update
    void Start()
    {
        m_controller = this.GetComponent<CharacterController>();
        sum_time = 0f;
        Enable_Acceration = true;
        Go_Acceration = false;
        bite_effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One) && Enable_Acceration)
        {
            Go_Acceration = true;
            Enable_Acceration = false;
            v_toward = this.transform.forward*10;
            bite_effect.SetActive(true);
        }
        if (Go_Acceration)
        {
            accel_f();
        }

    }

    private void accel_f()
    {
        sum_time += Time.deltaTime;
        if (sum_time>=Acceration_time)
        {
            Go_Acceration = false;
            Enable_Acceration = true;
            sum_time = 0f;
            m_controller.Move(Vector3.zero);
            bite_effect.SetActive(false);
            return;
        }
        m_controller.Move(v_toward*((float)(1-Math.Pow((sum_time/Acceration_time)-0.5f, 2))));
        return;
    }
}
