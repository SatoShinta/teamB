using UnityEngine;

public class YUKAcontrollerBrack : MonoBehaviour
{
    PlayerState playerState;
    [SerializeField] GameObject Player;
    

    public void Start()
    {
        playerState = Player.GetComponent<PlayerState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerState.YUKABlack();
    }

}
