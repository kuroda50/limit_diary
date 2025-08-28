using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class NetGenerator : MonoBehaviour
{
    [SerializeField] Canvas netGenerateCanvas;
    [SerializeField] GameObject netPrefab;
    [SerializeField] Vector3 generateNetOffset = new Vector3(-100, -100, 0);

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        Vector3 screenPos = Input.mousePosition;

        // Z（カメラからの距離）を指定する必要がある
        screenPos.z = 10f; // 例えばカメラから10ユニット先

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        Debug.Log($"クリックされたワールド座標: {worldPos}");

        var a = Instantiate(netPrefab, netGenerateCanvas.transform, default);
        a.transform.position = worldPos;
        a.transform.position += generateNetOffset;
    }
}
