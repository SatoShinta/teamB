using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private GameObject[] objArray;
    private Animator animator = null;
    private PlayerMove Player;

    // Start is called before the first frame update
    void Start()
    {
        //objArrayにGroundタグを持ったオブジェクト達を配列に格納させる
        objArray = GameObject.FindGameObjectsWithTag("Ground");
        animator = GetComponent<Animator>();
        Player = GetComponent<PlayerMove>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //配列の要素をobjに取得
        foreach (GameObject obj in objArray)
        {
            //yukaにすべての配列のYUKAcontrollerを取得させる
            YUKAcontroller yuka = obj.GetComponent<YUKAcontroller>();

            //yuka にコンポーネントがあり、 playerInHole フラグがtureの時
            if (yuka != null && yuka.playerInHole == true)
            {
                //playerの下にあるオブジェクトがobjに格納されているものと同じ場合
                if (collision.gameObject == obj)
                {
                    animator.SetBool("GameOver", true);
                    animator.SetBool("Up", false);
                    animator.SetBool("Down", false);
                    animator.SetBool("Right2", false);
                    animator.SetBool("Right", false);
                    Player.enabled = false;
                  break;
                    
                }
            }
        }
    }

    private void GameOver()
    {
        Destroy(gameObject);
        Debug.LogWarning("ヤラレチャッタ");
        animator.SetBool("GameOver", true);
    }
}
