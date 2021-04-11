using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Text>().text = ScoreKeeper.ScoreNow.ToString();
        ScoreKeeper.ResetScore();
    }
}
