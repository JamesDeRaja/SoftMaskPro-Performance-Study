using UnityEngine;
using UnityEngine.UI;

public class RedrawStressDriver : MonoBehaviour
{
    [Header("Pick ONE to stress")]
    public Graphic targetGraphic;
    public RectTransform targetRect;

    public bool animateColor = true;
    public bool animateSize = false;

    float t;

    void Update()
    {
        t += Time.unscaledDeltaTime;

        if (animateColor && targetGraphic != null)
        {
            // Forces vertex/material updates depending on implementation
            var c = targetGraphic.color;
            c.a = 0.5f + 0.5f * Mathf.Sin(t * 6f);
            targetGraphic.color = c;
            targetGraphic.SetVerticesDirty();
        }

        if (animateSize && targetRect != null)
        {
            // Layout-ish churn
            float s = 0.9f + 0.1f * Mathf.Sin(t * 8f);
            targetRect.localScale = new Vector3(s, s, 1f);
            // This tends to ripple more rebuild work depending on layout setup
        }
    }
}