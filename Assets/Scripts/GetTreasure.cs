using System.Collections;
using UnityEngine;

public class GetTreasure : MonoBehaviour
{
    [SerializeField] AudioClip getSound;
    AudioSource AudioSource;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DestroyTreasure());
        }

    }

   

    IEnumerator DestroyTreasure()
    {
        AudioSource.PlayOneShot(getSound);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
