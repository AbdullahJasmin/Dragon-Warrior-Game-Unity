
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private string scoreTextLabel;

    
    void Start()
    {
        if (scoreTextLabel == null)
            scoreTextLabel = "Score: ";
        if (PlayerPrefs.GetInt("Score") == 0)
            PlayerPrefs.SetInt("Score", 0);
        scoreText.text = scoreTextLabel + PlayerPrefs.GetInt("Score").ToString();
        
    }

    public void UpdateScore(int _score)
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + _score);
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("Score", 0);
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score").ToString();
    }

}
