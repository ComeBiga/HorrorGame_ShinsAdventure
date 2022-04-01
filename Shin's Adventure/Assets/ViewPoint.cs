using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewPoint : MonoBehaviour
{
    public UnityEvent OnPoint;

    public void OnViewPoint()
    {
        OnPoint.Invoke();
    }
}
