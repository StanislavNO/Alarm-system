using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private SafeHaven _safeHaven;
    [SerializeField] private float _speedTheft;

    private TargetMover _targetMover;
    private int _money = 0;


    private void Start()
    {
        _targetMover = GetComponent<TargetMover>();
    }

    public float ShowSpeedTheft() => _speedTheft;

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
