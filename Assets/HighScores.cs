using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{
    public HighScoreLine highScoreLine;

    public GameObject highScoreArea;
    // Start is called before the first frame update
    void Start()
    {
        var scores = ScoresRepo.GetInstance().GetScores();
        int i = 0;
        foreach (Score score in scores)
        {
            HighScoreLine line = Instantiate(highScoreLine, highScoreArea.transform, false);
            line.transform.localPosition += new Vector3(0,100 - i*50,0);
            line.SetName(score.name);
            line.SetScore(score.score);
            i++;
            if (i > 5)
            {
                break;
            }
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
