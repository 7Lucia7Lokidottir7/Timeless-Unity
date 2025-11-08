using UnityEngine;

public class AtomMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    public Vector3 targetPoint;
    [SerializeField] private float _targetDistance = 0.5f;
    [SerializeField] private float _targetRandomRadius = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetRandomPoint();
    }
    public void SetRandomPoint()
    {
        targetPoint = transform.position + Random.insideUnitSphere * _targetRandomRadius;
        targetPoint.y = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, _speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPoint) < _targetDistance)
        {
            SetRandomPoint();
        }
    }
}
