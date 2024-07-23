using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float footstepInterval = 0.5f;
    [SerializeField] float footstepVolume = 1.0f;
    [SerializeField] AudioClip footstepSound;

    bool canMove = true;
    bool moveing;
    Vector2 input;
    Animator animator;
    PlayerState state;
    AudioSource audioSource;

    //壁判定のレイヤー
    [SerializeField] LayerMask solidObjects;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<PlayerState>();
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (!state.gameOver)
        {
            if (!moveing && canMove)
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");

                //斜め移動対策
                if (input.x != 0)
                {
                    input.y = 0;
                }

                if (input != Vector2.zero)
                {
                    //入力があったら向きを変える
                    animator.SetFloat("Movex", input.x);
                    animator.SetFloat("Movey", input.y);

                    //コルーチンを使用して徐々に目的地に近づける

                    Vector2 targetpos = transform.position;
                    targetpos += input;
                    if (IsWalkable(targetpos))
                    {
                        StartCoroutine(Move(targetpos));
                        PlayFootstepSound();
                        canMove = false;
                        StartCoroutine(EnableMovementAfterDelay(0.5f));
                    }
                }

            }
        }
        animator.SetBool("isMoving", moveing);

    }


    IEnumerator Move(Vector3 targetpos)
    {
        //移動中は入力を受け付けない
        moveing = true;

        float threshold = 0.01f;
        float elapsedTIme = 0f;
        float lastFootstepTime = 0f;

        // targetposとの差があるなら繰り返す
        while (Vector3.Distance(transform.position, targetpos) > threshold)
        {
            //  近づける
            transform.position = Vector3.MoveTowards(transform.position, targetpos, moveSpeed * Time.deltaTime);

            elapsedTIme += Time.deltaTime;
            if(elapsedTIme - lastFootstepTime >= footstepInterval)
            {
                lastFootstepTime = elapsedTIme;
            }

            yield return null;
        }
        transform.position = targetpos;
        moveing = false;
    }

    //targetposに移動可能か調べる
    bool IsWalkable(Vector2 targetpos)
    {
        bool hit = Physics2D.OverlapCircle(targetpos, 0.3f, solidObjects);
        return !hit;
    }

    void PlayFootstepSound()
    {
        if(footstepSound != null && audioSource != null)
        {
            audioSource.volume = footstepVolume;
            audioSource.PlayOneShot(footstepSound);
        }
    }

    IEnumerator EnableMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true; // 指定した時間後に操作を受け付けるようにする
    }
}
