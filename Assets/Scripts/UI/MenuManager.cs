using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{ 
    public void StartGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level", 1));
        PlayerPrefs.SetInt("Score", 0);

    }
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }

    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }

}