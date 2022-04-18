using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    public GameObject rat;
    public bool destroy_flag;
    // public GameObject player;
    
    void Start()
    {
        rat = GameObject.Find("Rat");
        CreateRat();
        CreateRat();
        CreateRat();
        CreateRat();
    }


    public void CreateRat()
    {
        //50
        Vector3 coor;
        Vector3 player_coor = GameObject.Find("Player").transform.position;
        float r = 100f;
        // do{
        //     coor.x = Random.Range(170f, -240f);
        //     coor.z = Random.Range(150f, -140f);
        //     coor.y = 0f;
        // }while(Vector3.Distance(coor, player_coor)>=30&&Vector3.Distance(coor, player_coor)<=100);
        do{
            coor.x = Random.Range(r, -r);
            coor.z = Random.Range(r, -r);
            coor.y = 0f;
        }while(Vector3.Distance(coor, player_coor)>=60);
        GameObject new_rat =  Instantiate(rat, coor, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        // new_rat.transform.position = coor;
    }
}
