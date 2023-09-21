using UnityEngine;

public class TargetRotator : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotationStep;

    private Vector3 _targetDirection;
    private float _maxMagnitudeDelta = 0;

    private void Update()
    {
        _targetDirection = _target.position - transform.position;

        Vector3 _direction = Vector3.RotateTowards(
            transform.forward, 
            _targetDirection, 
            _rotationStep * Time.deltaTime, 
            _maxMagnitudeDelta);

        transform.rotation = Quaternion.LookRotation(_direction);
    }
}