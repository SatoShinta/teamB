using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Header("player‚ÌˆÚ“®‘¬“x")] float _speed = 0;
    Vector3 _position;
    Vector2 _move;
    // Start is called before the first frame update
    void Start()
    {
        _position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            transform.Translate(0,1,0);
        }
        if(Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            transform.Translate(0,-1,0);
        }
        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            transform.Translate(-1,0,0);
        }
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            transform.Translate(1,0,0);
        }



    }
}
