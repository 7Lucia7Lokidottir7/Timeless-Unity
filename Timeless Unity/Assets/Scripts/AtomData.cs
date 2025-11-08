using UnityEngine;

[CreateAssetMenu]
public class AtomData : ScriptableObject
{
    public string atomName;
    [Range(0, 1)] public float power;
    public float[] meanings;
}
