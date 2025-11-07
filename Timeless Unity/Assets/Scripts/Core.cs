using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Core : MonoBehaviour
{
    public float stability
    {
        get => Mathf.Clamp(_stability, 0f, 1f);
        set
        {
            _stability = value;
            stabilityChanged?.Invoke(_stability);
            if (_stability <= 0f)
            {
                dead?.Invoke();
            }
        }
    }
    private float _stability;

    public event System.Action<float> stabilityChanged;
    public event System.Action dead;

    public float exp
    {
        get => Mathf.Clamp(_exp, 0, maxExp);
        set
        {
            _exp = value;
            if (_exp == maxExp)
            {
                _levelUpEvent?.Invoke();
            }
        }
    }

    private float _exp;
    public float maxExp = 100;

    [SerializeField] private UnityEvent _levelUpEvent;

    public List<Atom> atoms = new List<Atom>();
}
