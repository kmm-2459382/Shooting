using UnityEngine;

public class PositionFixer : MonoBehaviour
{
    // 固定したい位置を指定します
    public Vector3 fixedPosition = new Vector3(0, 0, 0);

    void Update()
    {
        // オブジェクトの位置を常に fixedPosition に設定
        transform.position = fixedPosition;
    }
}
