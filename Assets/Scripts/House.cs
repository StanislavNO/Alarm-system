using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _leave;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            _entered.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            _leave.Invoke();
        }
    }
}