using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControll : MonoBehaviour
{
    public Button button_restart;
    public Button button_close;
    public GameObject menu_obj;

    private void Awake()
    {
        menu_obj.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
            menu_obj.SetActive(!menu_obj.activeSelf);
    }

    // Start is called before the first frame update
    public void GetDownRestart()
    {
        SceneManager.LoadScene("WildArea");
    }

    public void GetDownClose()
    {
        menu_obj.SetActive(false);
    }
}
