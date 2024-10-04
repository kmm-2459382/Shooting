using TMPro;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    void Start()
    {
        // ScoreTextオブジェクトを取得
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        UpdateScoreDisplay(); // スコアを表示
    }

    // スコアを更新するメソッド
    void UpdateScoreDisplay()
    {
        scoreText.text = GameManager.Instance.score + "pt"; // スコアを表示
    }
}
