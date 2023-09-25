using UnityEngine;

[RequireComponent(typeof(TargetMover))] 
public class Thief : MonoBehaviour
{
    [SerializeField] private SafeHaven _safeHaven;
    [SerializeField] private float _speedTheftSecond;
    [SerializeField] private int _money;

    private TargetMover _targetMover;

    private void Start()
    {
        _targetMover = GetComponent<TargetMover>();
    }

    public float ShowSpeedTheft() => _speedTheftSecond;

    public void SetMoney(int coin)
    {
        if (coin > 0)
        {
            _money++;
        }
        else
        {
            ChangedTargetMover(_safeHaven.transform.position);
        }
    }

    private void ChangedTargetMover(Vector3 target)
    {
        _targetMover.SetTarget(target);
    }
}
