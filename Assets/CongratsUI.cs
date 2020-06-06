using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CongratsUI : MonoBehaviour
{
    public InputField highScoreName;
    public Text scoreText;

    private int _score;

    public void SetScore(int score)
    {
        _score = score;
        scoreText.text = "Score: " + score;
    }

    public void OnSubmitScore()
    {
        ScoresRepo.GetInstance().AddScore(_score, highScoreName.text);
        SceneManager.LoadScene("MainMenuScene");
    }
}
