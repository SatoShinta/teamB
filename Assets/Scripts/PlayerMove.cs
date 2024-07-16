using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    bool moveing;
    Vector2 input;
    Animator animator;
    PlayerState state;

    //�ǔ���̃��C���[
    [SerializeField] LayerMask solidObjects;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<PlayerState>();
    }


    private void Update()
    {
        if (!state.gameOver)
        {
            if (!moveing)
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");

                //�΂߈ړ��΍�
                if (input.x != 0)
                {
                    input.y = 0;
                }

                if (input != Vector2.zero)
                {
                    //���͂��������������ς���
                    animator.SetFloat("Movex", input.x);
                    animator.SetFloat("Movey", input.y);

                    //�R���[�`�����g�p���ď��X�ɖړI�n�ɋ߂Â���

                    Vector2 targetpos = transform.position;
                    targetpos += input;
                    if (IsWalkable(targetpos))
                    {
                        StartCoroutine(Move(targetpos));
                    }
                }

            }
        }
        animator.SetBool("isMoving", moveing);

    }


    IEnumerator Move(Vector3 targetpos)
    {
        //�ړ����͓��͂��󂯕t���Ȃ�
        moveing = true;

        float threshold = 0.01f;

        // targetpos�Ƃ̍�������Ȃ�J��Ԃ�
        while (Vector3.Distance(transform.position, targetpos) > threshold)
        {
            //  �߂Â���
            transform.position = Vector3.MoveTowards(transform.position, targetpos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetpos;
        moveing = false;
    }

    //targetpos�Ɉړ��\�����ׂ�
    bool IsWalkable(Vector2 targetpos)
    {
        bool hit = Physics2D.OverlapCircle(targetpos, 0.3f, solidObjects);
        return !hit;
    }
}
