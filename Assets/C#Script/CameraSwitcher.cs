using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    // メインカメラとサブカメラの参照
    public Camera mainCamera;
    public Camera subCamera;

    // UIボタンの参照
    public Button switchCameraButton;

    void Start()
    {
        // ゲーム開始時にサブカメラを有効にし、メインカメラを無効にする
        subCamera.enabled = true;
        mainCamera.enabled = false;

        // ボタンにリスナーを追加し、押されたときにカメラを切り替えるようにする
        if (switchCameraButton != null)
        {
            switchCameraButton.onClick.AddListener(SwitchCamera);
        }
        else
        {
            Debug.LogWarning("Switch Camera Button is not assigned in the Inspector.");
        }
    }

    void Update()
    {
        // Cキーが押されたらカメラを切り替える
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    // カメラを切り替えるメソッド
    void SwitchCamera()
    {
        // カメラを切り替える（サブカメラが有効ならメインカメラを有効にし、逆も同様）
        mainCamera.enabled = !mainCamera.enabled;
        subCamera.enabled = !subCamera.enabled;
    }
}
