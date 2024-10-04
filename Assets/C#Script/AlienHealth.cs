using UnityEngine;
using UnityEngine.UI;

public class AlienHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public Image healthBarFill;

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
        ScoreManager.Instance.AddScore(5); // エイリアンを倒したときに5ポイント加算
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
