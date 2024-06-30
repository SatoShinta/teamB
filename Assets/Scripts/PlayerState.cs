using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject spawner;
    private GameObject[] objArray;
    private Animator animator = null;
    private PlayerMove Player;
    private float gameOverTimer;
    public bool gameOver = false;
    public SpriteRenderer playerRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //objArrayにGroundタグを持ったオブジェクト達を配列に格納させる
        objArray = GameObject.FindGameObjectsWithTag("Ground");
        animator = GetComponent<Animator>();
        Player = GetComponent<PlayerMove>();
        playerRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Player.enabled == false)
        {
            Debug.Log(gameOver);
            gameOverTimer += Time.deltaTime;
            Debug.Log(gameOverTimer);
            if (gameOverTimer >= 1f)
            {
                GameOver();
            }
        }

        if(gameOver == true && gameOverTimer >= 1.4f)
        {
            Spawn();
        }
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
                }
            }
        }
    }

    public void GameOver()
    {
        Destroy(gameObject);
        Debug.LogWarning("ヤラレチャッタ");
        animator.SetBool("GameOver", false);
        gameOver = true;
    }

    public void Spawn()
    {
        Instantiate(player, spawner.transform.position, spawner.transform.rotation);
        gameOver = false;
        Player.enabled = true;
        Debug.Log("umakuitta");
    }
}
