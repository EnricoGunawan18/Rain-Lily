
public class ScoreHome
{
    private static int cookScore = 0;
    private static int pazzleScore = 0;

    public int GetCookScore
    {
        get
        {
            return cookScore;
        }

        set
        {
            cookScore = value;
        }
    }

    public int GetPazzleScore
    {
        get
        {
            return pazzleScore;
        }
        set
        {
            pazzleScore = value;
        }
    }
}
