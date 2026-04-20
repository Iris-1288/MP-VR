using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public bool OnlyOnce = false;

    public void SetOnlyOnce(bool isture)
    {
        OnlyOnce = isture;
    }

    public UnityEvent OnTriggerEnterEvents;

    public UnityEvent OnTriggerStayEvents;

    public UnityEvent OnTriggerExitEvents;

    private void OnTriggerEnter(Collider other)
    {
        if(other != null && other.CompareTag("Player") && OnlyOnce)
        {
            OnTriggerEnterEvents?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other != null && other.CompareTag("Player") && OnlyOnce)
        {
            OnTriggerStayEvents?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.CompareTag("Player") && OnlyOnce)
        {
            OnTriggerExitEvents?.Invoke();
        }
    }

}
