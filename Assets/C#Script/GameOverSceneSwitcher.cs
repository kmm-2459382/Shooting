using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneSwitcher : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリックまたはタップ
        {
            ScoreManager.Instance.ResetScore(); // スコアをリセット
            SceneManager.LoadScene("GameScene");
        }
    }
}
