using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator = null;
    private int counter = 0;
    private float timer = 0;
    Rigidbody2D rb = null;
    PlayerState ply = null;
    [SerializeField] public float speed = 0f;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    // [SerializeField, Header("player‚ÌˆÚ“®‘¬“x")] float _speed = 0;
    //Vector3 _position;
    //Vector2 _move;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ply = GetComponent<PlayerState>();
        // _position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (ply.gameOver == false)
        {
            if (timer >= 0.2f)
            {
                if (!moveDown || !moveLeft || !moveRight)
                {
                    if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
                    {
                        animator.SetInteger("Direction", 2);
                        animator.SetBool("Up", true);
                        rb.AddForce(Vector2.up * speed);
                        counter++;
                        timer = 0f;
                        moveUp = true;
                    }
                    else
                    {
                        animator.SetBool("Up", false);
                        Stop();
                        moveUp = false;
                    }
                }

                if (!moveUp || !moveLeft || !moveRight)
                {
                    if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
                    {
                        animator.SetInteger("Direction", 1);
                        animator.SetBool("Down", true);
                        rb.AddForce(Vector2.down * speed);
                        counter++;
                        timer = 0f;
                        moveDown = true;
                    }
                    else
                    {
                        animator.SetBool("Down", false);
                        Stop();
                        moveDown = false;
                    }
                }

                if (!moveUp || !moveDown || !moveRight)
                {
                    if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
                    {
                        animator.SetInteger("Direction", 4);
                        animator.SetBool("Right2", true);
                        rb.AddForce(Vector2.left * speed);
                        transform.localScale = new Vector3(1, 1, 1);
                        timer = 0f;
                        moveLeft = true;
                    }
                    else
                    {
                        animator.SetBool("Right2", false);
                        Stop();
                        moveLeft = false;
                    }
                }


                if (!moveUp || !moveDown || !moveLeft)
                {
                    if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
                    {
                        animator.SetInteger("Direction", 3);
                        animator.SetBool("Right", true);
                        rb.AddForce(Vector2.right * speed);
                        transform.localScale = new Vector3(1, 1, 1);
                        timer = 0f;
                        moveRight = true;
                    }
                    else
                    {
                        animator.SetBool("Right", false);
                        Stop();
                        moveRight = false;
                    }
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            rb.AddForce(-rb.velocity * 250f);
        }
    }

    void Stop()
    {
        rb.velocity = Vector2.zero;
    }
}
