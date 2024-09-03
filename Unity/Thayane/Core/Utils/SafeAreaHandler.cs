using UnityEngine;

public class SafeAreaHandler : MonoBehaviour
{
    private RectTransform panelSafeArea;
    private Rect currentSafeArea = new(0, 0, 0, 0);

    void Awake()
    {
        panelSafeArea = GetComponent<RectTransform>();
        ApplySafeArea();
    }

    void ApplySafeArea()
    {
        currentSafeArea = Screen.safeArea;

        var anchorMin = currentSafeArea.position;
        var anchorMax = currentSafeArea.position + currentSafeArea.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        panelSafeArea.anchorMin = anchorMin;
        panelSafeArea.anchorMax = anchorMax;
    }
}
