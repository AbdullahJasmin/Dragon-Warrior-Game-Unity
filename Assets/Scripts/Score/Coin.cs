
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private AudioClip coinSound;
    [SerializeField] private int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Update score
            FindObjectOfType<Score>().UpdateScore(value);
            //Play sound
            SoundManager.instance.PlaySound(coinSound); 

            //Destroy coin
            Destroy(gameObject);
        }
    }
}
