using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int score = 0; // 現在のスコア
    public TextMeshProUGUI scoreText; // スコア表示用のTextMeshProUGUI

    void Awake()
    {
        // シングルトンの実装
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // ゲーム中ずっと存在させる
        }
        else
        {
            Destroy(gameObject);  // 既存のインスタンスがある場合はこのオブジェクトを削除
        }
    }

    void Start()
    {
        // スコアの初期表示
        UpdateScoreText();
    }

    // スコアを加算するメソッド
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText(); // スコアを更新する
        Debug.Log("Score updated: " + score); // スコアが更新されたことをログに出力
    }

    // スコアを保存するメソッド
    public void SaveScore()
    {
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();
    }

    // スコアをリセットするメソッド
    public void ResetScore()
    {
        score = 0; // スコアをリセット
        UpdateScoreText(); // スコアテキストを更新
        Debug.Log("Score reset to: " + score); // リセットされたスコアをログに出力
    }

    // スコアテキストを更新するメソッド
    private void UpdateScoreText()
    {
        if (scoreText == null)
        {
            // シーン内の TextMeshProUGUI を探して設定
            scoreText = FindObjectOfType<TextMeshProUGUI>();
            if (scoreText == null)
            {
                Debug.LogWarning("ScoreText is not assigned in the inspector and could not be found in the scene.");
                return;
            }
        }

        scoreText.text = score + " pt"; // スコアをテキストに反映
    }
}
