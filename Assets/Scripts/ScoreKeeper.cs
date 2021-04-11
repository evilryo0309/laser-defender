using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public static int ScoreNow = 0;
    Text myText;

    private void Start()
    {
        myText = GetComponent<Text>();
        ResetScore();
    }

    public void Score(int points)
    {
        ScoreNow += points;
        myText.text = ScoreNow.ToString();
    }

    public static void ResetScore()
    {
        ScoreNow = 0;
    }
        
}
