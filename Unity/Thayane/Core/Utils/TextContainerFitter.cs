using UnityEngine;
using TextMeshProUGUI = TMPro.TextMeshProUGUI;

[AddComponentMenu("Layout/TMP Container Size Fitter")]
public class TextContainerFitter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    public TextMeshProUGUI TextMeshPro
    {
        get
        {
            if (text == null && transform.GetComponentInChildren<TextMeshProUGUI>())
            {
                text = transform.GetComponentInChildren<TextMeshProUGUI>();
                m_TMPRectTransform = text.rectTransform;
            }
            return text;
        }
    }

    protected RectTransform m_RectTransform;
    public RectTransform rectTransform
    {
        get
        {
            if (m_RectTransform == null)
            {
                m_RectTransform = GetComponent<RectTransform>();
            }
            return m_RectTransform;
        }
    }

    protected RectTransform m_TMPRectTransform;
    public RectTransform TMPRectTransform { get { return m_TMPRectTransform; } }

    protected float m_PreferredHeight;
    public float PreferredHeight { get { return m_PreferredHeight; } }

    protected virtual void SetHeight()
    {
        if (TextMeshPro == null)
        {
            return;
        }

        m_PreferredHeight = TextMeshPro.preferredHeight;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, PreferredHeight);

        SetDirty();
    }

    protected virtual void OnEnable()
    {
        SetHeight();
    }

    protected virtual void Start()
    {
        SetHeight();
    }

    protected virtual void Update()
    {
        if (PreferredHeight != TextMeshPro.preferredHeight)
        {
            SetHeight();
        }
    }

    #region MarkLayoutForRebuild
    public virtual bool IsActive()
    {
        return isActiveAndEnabled;
    }

    protected void SetDirty()
    {
        if (!IsActive())
        {
            return;
        }

        UnityEngine.UI.LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
    }


    protected virtual void OnRectTransformDimensionsChange()
    {
        SetDirty();
    }


#if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        SetDirty();
    }
#endif

    #endregion
}