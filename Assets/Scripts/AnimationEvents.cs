using UnityEngine;
using UnityEngine.Events;

public class AnimationEvents : MonoBehaviour
{
    public UnityEvent events;

    public void ani()
    {
        events?.Invoke();
    }
}
