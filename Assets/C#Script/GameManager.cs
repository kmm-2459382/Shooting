using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score = 0;
    private TextMeshProUGUI scoreText;

    void Awake()
    {
        // シングルトンパターンの実装
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // ゲーム中ずっと存在させる
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ゲーム開始時に GameScene をロード
        SceneManager.LoadScene("GameScene");
        // ScoreTextオブジェクトを取得
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        UpdateScoreText(); // スコアの初期表示
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score added: " + points + ", Total score: " + score);
        UpdateScoreText(); // スコアの更新を反映
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score + "pt";
            Debug.Log("Score text updated: " + scoreText.text);
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.Save();
    }
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText(); // スコアがリセットされたことをUIに反映
    }

}
