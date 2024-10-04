using UnityEngine;
using UnityEngine.UI;

public class PlayerUltimateAttack : MonoBehaviour
{
    public GameObject energyBallPrefab;  // エネルギーボールのPrefab
    public Transform firePoint;          // エネルギーボールの発射位置
    public Image gaugeImage;             // ゲージを表示するImage
    public Button ultimateButton;        // 必殺技を発動するボタン
    public float gaugeMaxTime = 5f;      // ゲージがマックスになるまでの時間
    public float bulletSpeed = 0f;      // エネルギーボールの速度

    private float gaugeTimer = 0f;       // ゲージの現在の時間

    void Start()
    {
        // ゲージを初期化
        gaugeImage.fillAmount = 0f;
        ultimateButton.interactable = false; // 最初はボタンが押せない状態
        ultimateButton.onClick.AddListener(OnUltimateButtonPressed); // ボタンのクリックイベント
    }

    void Update()
    {
        // ゲージがマックスでない場合、ゲージを進行させる
        if (gaugeImage.fillAmount < 1f)
        {
            gaugeTimer += Time.deltaTime;
            gaugeImage.fillAmount = gaugeTimer / gaugeMaxTime;

            // ゲージがマックスになったらボタンを有効にする
            if (gaugeImage.fillAmount >= 1f)
            {
                ultimateButton.interactable = true;
            }
        }

        // スペースキーが押され、ゲージがマックスになっている場合に必殺技を発射
        if (Input.GetKeyDown(KeyCode.Space) && gaugeImage.fillAmount >= 1f)
        {
            OnUltimateButtonPressed(); // 必殺技を発動
        }
    }

    // 必殺技ボタンが押されたとき、またはスペースキーが押されたときの処理
    public void OnUltimateButtonPressed()
    {
        // 必殺技を発射
        ShootEnergyBall();

        // ゲージとタイマーをリセット
        gaugeTimer = 0f;
        gaugeImage.fillAmount = 0f;

        // ボタンを無効にする
        ultimateButton.interactable = false;
    }

    // エネルギーボールを発射する
    void ShootEnergyBall()
    {
        if (energyBallPrefab != null && firePoint != null)
        {
            GameObject energyBall = Instantiate(energyBallPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = energyBall.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * bulletSpeed;  // エネルギーボールに速度を与える
        }
        else
        {
            Debug.LogWarning("Energy Ball Prefab or Fire Point not assigned.");
        }
    }
}
