using System.Collections;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _money;

    private int _coin = 1;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Thief>(out Thief thief))
        {
            StartCoroutine(GetMoneyTimer(thief));
        }
    }

    private int GetMoney()
    {
        if (_money > 0)
        {
            _money--;

            return _coin;
        }
        else
        {
            return _money;
        }
    }

    private IEnumerator GetMoneyTimer(Thief thief)
    {
        WaitForSecondsRealtime delay =
            new WaitForSecondsRealtime(thief.ShowSpeedTheft());

        do
        {
            thief.SetMoney(GetMoney());

            yield return delay;
        }
        while (_money > 0);

        thief.SetMoney(GetMoney());
    }
}