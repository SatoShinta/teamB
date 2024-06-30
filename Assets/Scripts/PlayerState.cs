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
        //objArray��Ground�^�O���������I�u�W�F�N�g�B��z��Ɋi�[������
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
        //�z��̗v�f��obj�Ɏ擾
        foreach (GameObject obj in objArray)
        {
            //yuka�ɂ��ׂĂ̔z���YUKAcontroller���擾������
            YUKAcontroller yuka = obj.GetComponent<YUKAcontroller>();

            //yuka �ɃR���|�[�l���g������A playerInHole �t���O��ture�̎�
            if (yuka != null && yuka.playerInHole == true)
            {
                //player�̉��ɂ���I�u�W�F�N�g��obj�Ɋi�[����Ă�����̂Ɠ����ꍇ
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
        Debug.LogWarning("�������`���b�^");
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
