using System.Collections.Generic;

public interface IScores
{
    void AddScore(int score, string name);
    List<Score> GetScores();
}

public class ScoresRepo : IScores
{
    private static ScoresRepo _instance;
    private readonly List<Score> _scores = new List<Score>();
    
    private ScoresRepo(){}
    public static IScores GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ScoresRepo();
        }

        return _instance;
    }

    public List<Score> GetScores()
    {
        _scores.Sort(CompareScore);
        return _scores;
    }

    public void AddScore(int score, string name)
    {
        _scores.Add(new Score(name, score));
    }

    private int CompareScore(Score x, Score y)
    {
        return x.score - y.score;
    }
}

public class Score
{
    public int score;
    public string name;
    public Score(string name, int score)
    {
        this.score = score;
        this.name = name;
    }
}