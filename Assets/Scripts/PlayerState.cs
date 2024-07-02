using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject spawner;
    private GameObject[] objArray;
    private Animator animator = null;
    private BoxCollider2D Collider2d;
    private PlayerMove playerMove;
    private float gameOverTimer;
    public bool gameOver = false;
    private bool gameClear = false;
    private bool goal = false;
    private int treasureCounter;
    SpriteRenderer playerRenderer;
    YUKAcontroller[] yukaController;

    // Start is called before the first frame update
    void Start()
    {
        //objArray��Ground�^�O���������I�u�W�F�N�g�B��z��Ɋi�[������
        objArray = GameObject.FindGameObjectsWithTag("Ground");
        animator = GetComponent<Animator>();
        Collider2d = GetComponent<BoxCollider2D>();
        playerMove = GetComponent<PlayerMove>();
        playerRenderer = gameObject.GetComponent<SpriteRenderer>();

        //YUKAcontroller���擾����yukacontroller�z��Ɋi�[����
        yukaController = new YUKAcontroller[objArray.Length];
        for (int i = 0; i < objArray.Length; i++)
        {
            yukaController[i] = objArray[i].GetComponent<YUKAcontroller>();
        }


        Collider2d.enabled = true;
        playerMove.enabled = true;
    }

    private void Update()
    {
        if (Collider2d.enabled == false)
        {
            Debug.Log(gameOver);
            gameOverTimer += Time.deltaTime;
            Debug.Log(gameOverTimer);
            if (gameOverTimer >= 0.6f)
            {
                GameOver();
            }
        }

        if (gameOverTimer >= 1f)
        {
            Spawn();
            gameOverTimer = 0f;
        }


        if (treasureCounter >= 3)
        {
            gameClear = true;
            if (gameClear == true && goal == true)
            {
                Debug.Log("gameclear");
                playerMove.enabled = false;
                animator.SetBool("Right", false);
            }
        }
        else if (treasureCounter < 3 && goal == true)
        {
            Invoke("DelayedNomal", 0.1f);
            playerMove.enabled = false;
            animator.SetBool("Right", false);
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
                    Collider2d.enabled = false;
                    playerMove.enabled = false;
                }
            }
        }


        if (collision.gameObject.CompareTag("Treasure"))
        {
            treasureCounter++;
            Debug.Log(treasureCounter.ToString());
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            goal = true;
        }
    }



    public void GameOver()
    {
        Debug.LogWarning("�������`���b�^");
        animator.SetBool("GameOver", false);
        gameOver = true;
    }

    public void Spawn()
    {
        transform.position = spawner.transform.position;
        gameOver = false;
        Collider2d.enabled = true;
        playerMove.enabled = true;
        Debug.Log("umakuitta");
    }

    private void DelayedNomal()
    {
        goal = false;
        foreach (YUKAcontroller yuka1 in yukaController)
        {
            if (yuka1 != null)
            {
                yuka1.Nomal();
            }
        }
        transform.position = spawner.transform.position;
        Debug.Log("�������");
        playerMove.enabled = true;
    }
}
