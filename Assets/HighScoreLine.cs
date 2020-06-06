
using UnityEngine;
using UnityEngine.UI;

public class HighScoreLine : MonoBehaviour
{
    public new Text name;
    public Text score;
    // Start is called before the first frame update
    public void SetName(string n)
    {
        name.text = n;
    }

    public void SetScore(int n)
    {
        score.text = ""+n;
    }
}
