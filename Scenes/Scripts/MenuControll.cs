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
    // public TemperatureMaster tMaster;

    private void Awake()
    {
        // menu_obj = GameObject.Find("Canvas/menu");
        menu_obj.SetActive(false);
        // button_restart = GameObject.Find("Canvas/menu/Restart").GetComponent<Button>();
        // button_close = GameObject.Find("Canvas/menu/Delete").GetComponent<Button>();
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
//     public void GetDownSwitchVisible()
//     {
//         tMaster.OnStandSwitchingView();
//     }
}
