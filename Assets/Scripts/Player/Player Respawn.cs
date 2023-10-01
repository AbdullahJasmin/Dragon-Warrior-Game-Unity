
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; //Sound that we'll play when picking up a new checkpoint
    private Transform currentCheckpoint; //We' 11 store our last checkpoint here
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }
    public void CheckRespawn()
    {
        // Check if checkpoint available 
        if (currentCheckpoint == null){
            // show game over screen
            uiManager.GameOver();
            return;
        }
        

        transform.position = currentCheckpoint.position; //Move player to checkpoint position}
        playerHealth.Respawn(); //Reset player health

        // activate room
        currentCheckpoint.parent.GetComponent<Room>().ActivateRoom(true);

        // Move camera to checkpoint room 
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform; // Store the new checkpoint
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false; // Disable the collider so we can't pick up the same checkpoint twice
            collision.GetComponent<Animator>().SetTrigger("Appear"); // Play the checkpoint animation
        }
    }
}
