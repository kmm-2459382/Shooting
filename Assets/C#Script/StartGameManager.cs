using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    void Start()
    {
        // ゲーム開始時にすぐにGameOverSceneに遷移
        Invoke("GoToGameOverScene", 0.1f); // 0.1秒後に遷移
    }

    void GoToGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
