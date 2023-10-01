using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{

    [SerializeField] private AudioClip levelEnd;
    [SerializeField] private int nextLevel;

    private float victoryTime = 3;
    private float idletime;



    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.gameObject.tag == "Player")
        {

            // play sound
            SoundManager.instance.PlaySound(levelEnd);
            // after 3 seconds load next level

            collission.GetComponent<PlayerMovement>().enabled = false;
            collission.GetComponent<Animator>().SetBool("Run", false);
            Invoke("LoadNextLevel", victoryTime);
            // stop player movement
        }
    }

    private void LoadNextLevel()
    {
        if (nextLevel == 0)
        {
            SceneManager.LoadScene("MainMenu");
            return;
        }
        SceneManager.LoadScene(PlayerPrefs.GetInt("level", nextLevel));
    }

}
