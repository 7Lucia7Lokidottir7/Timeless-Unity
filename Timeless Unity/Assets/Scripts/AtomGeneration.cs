using UnityEngine;

public class AtomGeneration : MonoBehaviour
{
    [SerializeField] private Atom[] _atomLures;
    [SerializeField] private AtomDataContainer _container; 
    [SerializeField] private Atom _atomPrefab;
    [SerializeField] private Transform _atomsPoint;
    [SerializeField] private float _radius = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        for (int i = 0; i < _atomLures.Length; i++)
        {
            _atomLures[i].data = _container.GetRandomAtomData(_atomLures);
        }

        for (int i = 0; i < _container.atomDatas.Count; i++)
        {
            bool isSkip = false;
            foreach (var item in _atomLures)
            {
                if (_container.atomDatas[i] == item.data)
                {
                    isSkip = true;
                    break;
                }
            }
            if (isSkip)
            {
                continue;
            }

            Vector3 position = _atomsPoint.position + Random.insideUnitSphere * _radius;
            position.y = _atomsPoint.position.y;
            Atom atom = Instantiate(_atomPrefab, position, Quaternion.identity, _atomsPoint);
            atom.data = _container.atomDatas[i];
        }
    }
}
