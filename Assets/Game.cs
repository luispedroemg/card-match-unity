using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public int xBoardSize;
    public int yBoardSize;
    public GameObject[] cardTypes;
    public MatchUi userInterface;
    private int _numMoves;
    private Card[,] _grid; 

    private Card _firstCard;
    private Card _secondCard;

    private int _numMatchedCards;

    // Start is called before the first frame update
    void Start()
    {
        _grid = new Card[xBoardSize,yBoardSize];
        CreateBoard();
    }

    void CreateBoard()
    {
        int placedCards = 0;
        foreach (var cardType in cardTypes)
        {
            CreateCard(cardType);
            CreateCard(cardType);
            placedCards += 2;
            if (placedCards >= xBoardSize * yBoardSize)
            {
                break;
            }
        }
    }

    private Card CreateCard(GameObject cardType)
    {
        var card = Instantiate(cardType).GetComponentInChildren<Card>();
        card.SetCallBack(CardFlipped, CardTimeout);
        int x = (int) Mathf.Floor(Random.value * (xBoardSize));
        int y = (int) Mathf.Floor(Random.value * (yBoardSize));
        while (_grid[x, y] != null)
        {
            x = ++x % xBoardSize;
            y = ++y % yBoardSize;
        }
        _grid[x, y] = card;
        card.transform.parent.position = new Vector3(x * 10, y * 10, 0);
        return card;
    }

    private void CardTimeout(Card c)
    {
        if (c == _firstCard)
        {
            _firstCard = null;
        }
        else if (c == _secondCard)
        {
            _secondCard = null;
        }
    }

    private void CardFlipped(Card c)
    {
        if (_firstCard == null)
        {
            _firstCard = c;
        }
        else if (_secondCard == null)
        {
            if (_firstCard == c)
            {
                c.FlipCard();
                return;
            }
            _secondCard = c;
            _numMoves++;
            _firstCard.MoveTimerStart();
            _secondCard.MoveTimerStart();
            userInterface.SetNumMoves(_numMoves);
            if (CardMatch(_firstCard,_secondCard))
            {
                _firstCard = null;
                _secondCard = null;
            }
            if (_numMatchedCards == xBoardSize * yBoardSize)
            {
                processWin();
            }
        }
        else
        {
            _firstCard.FlipCard();
            _secondCard.FlipCard();
            c.FlipCard();
            _firstCard = null;
            _secondCard = null;
        }
    }

    private void processWin()
    {
        userInterface.ShowWin(_numMoves);
    }

    private bool CardMatch(Card card1, Card card2)
    {
        if (card1.transform.parent.name == card2.transform.parent.name && card1!=card2)
        {
            card1.MatchCard();
            card2.MatchCard();
            _numMatchedCards += 2;
            return true;
        }
        return false;
    }
}
