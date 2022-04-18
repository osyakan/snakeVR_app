using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeEaten : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag.ToString());
        if (other.gameObject.tag == "Snake") {
            Destroy(other.gameObject);
        }
    }
}
