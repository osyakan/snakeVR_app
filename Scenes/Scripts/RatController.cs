// フィールド内にランダムにネズミを表示させる

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    // ratにはBeEatenをアサインされたプレハブを指定
    public GameObject rat;
    public bool destroy_flag;

    void Start()
    {

        rat = GameObject.Find("Rat");
        CreateRat();
        CreateRat();
        CreateRat();
        CreateRat();
    }

    // ネズミをランダムに生成させる関数
    public void CreateRat()
    {
        Vector3 coor;
        Vector3 player_coor = GameObject.Find("Player").transform.position;
        float r = 100f;

        // プレイヤー周辺の座標をランダム生成し、その座標にネズミを生成する
        do{
            coor.x = Random.Range(r, -r);
            coor.z = Random.Range(r, -r);
            coor.y = 0f;
        }while(Vector3.Distance(coor, player_coor)>=60);
        GameObject new_rat =  Instantiate(rat, coor, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        // new_rat.transform.position = coor;
    }
}
