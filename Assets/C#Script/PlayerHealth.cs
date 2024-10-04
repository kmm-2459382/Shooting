using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBarFill;

    private ScoreManager scoreManager; // ScoreManagerへの参照

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();

        // ScoreManagerを取得
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            float healthPercentage = (float)currentHealth / maxHealth;
            healthBarFill.fillAmount = healthPercentage;
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");

        // スコアを保存
        FindObjectOfType<GameManager>().SaveScore();

        // スコアをリセット
        FindObjectOfType<GameManager>().ResetScore();

        // GameOverScene へ遷移
        SceneManager.LoadScene("GameOverScene");
    }
}
