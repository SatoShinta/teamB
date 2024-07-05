using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator = null;
    private int counter = 0;
    private float timer = 0;

    // [SerializeField, Header("player‚ÌˆÚ“®‘¬“x")] float _speed = 0;
    //Vector3 _position;
    //Vector2 _move;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // _position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.2f)
        {
            if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
                animator.SetInteger("Direction", 2);
                animator.SetBool("Up", true);
                transform.Translate(0, 1, 0);
                counter++;
                timer = 0f;
            }
            else
            {
                animator.SetBool("Up", false);
            }


            if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
            {
                animator.SetInteger("Direction", 1);
                animator.SetBool("Down", true);
                transform.Translate(0, -1, 0);
                counter++;
                timer = 0f;
            }
            else
            {
                animator.SetBool("Down", false);
            }


            if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                animator.SetInteger("Direction", 4);
                animator.SetBool("Right2", true);
                transform.Translate(-1, 0, 0);
                transform.localScale = new Vector3(1, 1, 1);
                timer = 0f;
            }
            else
            {
                animator.SetBool("Right2", false);
            }

            if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
                animator.SetInteger("Direction", 3);
                animator.SetBool("Right", true);
                transform.Translate(1, 0, 0);
                transform.localScale = new Vector3(1, 1, 1);
                timer = 0f;
            }
            else
            {
                animator.SetBool("Right", false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {

        }
    }
}
