
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{

    [SerializeField] private float healthvalue;
    [SerializeField] private AudioClip pickupSound;


    private void OnTriggerEnter2D(Collider2D collission) {
        if (collission.tag == "Player") {
            SoundManager.instance.PlaySound(pickupSound);
            collission.GetComponent<Health>().AddHealth(healthvalue);
            gameObject.SetActive(false);
        }
    }
}
