using UnityEngine;
using TMPro; // TextMeshPro を使う場合

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ScoreText を UI にアタッチ

    void Start()
    {
        // ScoreManagerからスコアを取得
        int finalScore = ScoreManager.Instance.score;

        // スコアを「score + "pt"」形式で表示
        scoreText.text = finalScore + " pt";
    }
}
