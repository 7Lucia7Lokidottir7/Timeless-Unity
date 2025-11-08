using System.Collections.Generic;
using UnityEngine;

public class AtomLure : MonoBehaviour
{
    [SerializeField] private Core _core;
    private List<Atom> atoms = new List<Atom>();
    [SerializeField] private float _targetDistance = 0.25f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Atom atom))
        {
            atom.atomMovement.targetPoint = transform.position;
            atoms.Add(atom);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!enabled)
        {
            return;
        }
        foreach (Atom atom in atoms)
        {
            if (!atom.atomMovement.enabled)
            {
                continue;
            }
            if (Vector3.Distance(atom.transform.position, transform.position) < _targetDistance)
            {
                if (_core.stability >= atom.data.power)
                {
                    _core.exp += atom.data.power;
                    atom.atomMovement.enabled = false;
                }
                else
                {
                    _core.Death();
                    enabled = false;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Atom atom))
        {
            atom.atomMovement.SetRandomPoint();
            atoms.Remove(atom);
        }
    }
}
