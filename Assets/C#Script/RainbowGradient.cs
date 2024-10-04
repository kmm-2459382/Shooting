using UnityEngine;
using UnityEngine.UI;

public class RainbowGradient : MonoBehaviour
{
    public Image targetImage; // 対象のImageコンポーネント
    public float speed = 1f;  // 色の変化速度
    private Color[] colors;

    void Start()
    {
        // 2^8^3色のグラデーションを生成
        colors = new Color[256 * 256 * 256];
        int index = 0;

        for (int r = 0; r < 256; r++)
        {
            for (int g = 0; g < 256; g++)
            {
                for (int b = 0; b < 256; b++)
                {
                    colors[index++] = new Color(r / 255f, g / 255f, b / 255f);
                }
            }
        }
    }

    void Update()
    {
        // 色を徐々に変化させる
        float time = Time.time * speed;
        int colorIndex = (int)(time % colors.Length);
        targetImage.color = colors[colorIndex];
    }
}
