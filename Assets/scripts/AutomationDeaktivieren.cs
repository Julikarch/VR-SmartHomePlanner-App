using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomationDeaktivieren : MonoBehaviour
{
    [SerializeField]
    public UnityEvent deaktivieren;

    [SerializeField]
    public UnityEvent aktivieren;

    public void Deaktivieren()
    {
        deaktivieren.Invoke();
    }

    public void Aktivieren()
    {
        aktivieren.Invoke();
    }
}
