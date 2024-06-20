using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class PlayerMove : MonoBehaviour
{
    private Animator animator = null;
    private int counter = 0;

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
        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            animator.SetInteger("Direction", 2);
            transform.Translate(0,1,0);
            counter++;
        }
    

        if(Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            animator.SetInteger("Direction", 1);
            transform.Translate(0,-1,0);
            counter++;
         
        }
     

        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            animator.SetInteger("Direction", 3);
            transform.Translate(-1,0,0);
            transform.localScale = new Vector3(-1,1,1);
        }
      
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            animator.SetInteger("Direction", 3);
            transform.Translate(1,0,0);
            transform.localScale = new Vector3(1,1,1);
        }
     


    }
}
