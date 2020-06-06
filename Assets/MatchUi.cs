using UnityEngine;
using UnityEngine.UI;

public class MatchUi : MonoBehaviour
{
    
    public CongratsUI congrats;
    private int _score;
    private CanvasGroup _uiGroup;
    void Start()
    {
        _uiGroup = congrats.GetComponent<CanvasGroup>();
    }

    public void ShowWin(int score)
    {
        _score = score;
        congrats.SetScore(_score);
        _uiGroup.interactable = true;
        _uiGroup.alpha = 1;
        _uiGroup.blocksRaycasts = true;
    }

    public void SetNumMoves(int num)
    {
        GetComponentInChildren<Text>().text = "Move " + num;
    }
}
