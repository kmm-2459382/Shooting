using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowPlayerEnergyBall : MonoBehaviour
{
    public float speed = 10f;  // エネルギーボールの移動速度
    public float damage = 5f;  // 与えるダメージ量
    public float damageInterval = 0.25f;  // ダメージを与える間隔
    private HashSet<GameObject> hitEnemies = new HashSet<GameObject>(); // 既にダメージを与えている敵の追跡
    public float lifetime = 30f;  // エネルギーボールの寿命

    void Start()
    {
        // 指定した時間後にエネルギーボールを自動的に消去する
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // エネルギーボールを z 軸方向に進める
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Alien") || other.CompareTag("Ufo") || other.CompareTag("Boss"))
        {
            if (!hitEnemies.Contains(other.gameObject))
            {
                hitEnemies.Add(other.gameObject);
                StartCoroutine(DealDamageOverTime(other.gameObject));
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (hitEnemies.Contains(other.gameObject))
        {
            hitEnemies.Remove(other.gameObject);
        }
    }

    // 敵のタイプによってHealthクラスを指定
    private IEnumerator DealDamageOverTime(GameObject enemy)
    {
        while (hitEnemies.Contains(enemy))
        {
            if (enemy == null)
            {
                yield break; // enemyがnullの場合、コルーチンを終了
            }

            if (enemy.CompareTag("Alien"))
            {
                var health = enemy.GetComponent<AlienHealth>();
                if (health != null)
                {
                    health.TakeDamage(Mathf.RoundToInt(damage));
                }
            }
            else if (enemy.CompareTag("Ufo"))
            {
                var health = enemy.GetComponent<UfoHealth>();
                if (health != null)
                {
                    health.TakeDamage(Mathf.RoundToInt(damage));
                }
            }
            else if (enemy.CompareTag("Boss"))
            {
                var health = enemy.GetComponent<BossHealth>();
                if (health != null)
                {
                    health.TakeDamage(Mathf.RoundToInt(damage));
                }
            }
            yield return new WaitForSeconds(damageInterval); // damageInterval 秒待機
        }
    }
}
