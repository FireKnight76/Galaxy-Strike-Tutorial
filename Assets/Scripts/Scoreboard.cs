using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    int score = 0;

    public void IncreaseScore(int amount)
    {
        score += amount;
        text.text = "Score: " + score.ToString();
    }
}
