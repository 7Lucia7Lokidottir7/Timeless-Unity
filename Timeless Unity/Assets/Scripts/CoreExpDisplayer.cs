using TMPro;
using UnityEngine;

public class CoreExpDisplayer : MonoBehaviour
{
    [SerializeField] private Core _core;
    [SerializeField] private TMP_Text _text;
    private void Awake()
    {
        SetText(_core.exp);
    }
    private void OnEnable()
    {
        _core.expChanged += SetText;
    }
    private void OnDisable()
    {
        _core.expChanged -= SetText;
    }
    void SetText(float value)
    {
        _text.text = $"{value}/{_core.maxExp}";
    }
}
