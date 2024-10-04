using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    void Start()
    {
        // 初回実行かどうかを確認するフラグ
        if (PlayerPrefs.GetInt("HasStarted", 0) == 0)
        {
            // 初回の場合、GameOverSceneに遷移する
            Invoke("GoToGameOverScene", 0.1f); // 0.1秒後に遷移

            // 次回からはGameOverSceneに遷移しないようにフラグを設定
            PlayerPrefs.SetInt("HasStarted", 1);
            PlayerPrefs.Save();
        }
        else
        {
            // 2回目以降は通常のGameSceneが開始される
            Debug.Log("Game starts normally.");
        }
    }
}
