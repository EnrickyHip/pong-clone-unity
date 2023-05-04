using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    public int pointsToWin = 5;

    public void GoalPlayer1()
    {
        this.scorePlayer1++;
        if (scorePlayer1 == this.pointsToWin)
            SceneManager.LoadScene("GameOver");


        TextMeshProUGUI uiScorePlayer1 = this.scoreTextPlayer1.GetComponent<TextMeshProUGUI>();
        uiScorePlayer1.text = this.scorePlayer1.ToString();
    }
    public void GoalPlayer2()
    {

        this.scorePlayer2++;
        if (scorePlayer2 == this.pointsToWin)
            SceneManager.LoadScene("GameOver");
        
        TextMeshProUGUI uiScorePlayer2 = this.scoreTextPlayer2.GetComponent<TextMeshProUGUI>();
        uiScorePlayer2.text = this.scorePlayer2.ToString();
    }
}
