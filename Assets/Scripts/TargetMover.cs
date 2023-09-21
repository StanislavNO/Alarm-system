using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            _target.position, 
            _speed * Time.deltaTime);
    }

    public void SetTarget(Vector3 position)
    {
        _target.position = position;
    }
}