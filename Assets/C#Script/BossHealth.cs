using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;
    public Image healthBarFill;

    public delegate void BossDeathHandler();  // ボス死亡時のイベント
    public event BossDeathHandler OnBossDeath;  // ボス死亡イベント

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthBar();
    }

    void Die()
    {
        OnBossDeath?.Invoke();  // ボスが倒れたことを通知するイベント
        ScoreManager.Instance.AddScore(100); // ボスを倒したときに100ポイント加算
        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
