using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 画面タップや左クリック
        {
            // 現在のシーン名を取得
            string currentScene = SceneManager.GetActiveScene().name;

            // GameOverSceneならGameSceneに遷移させる
            if (currentScene == "GameOverScene")
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
