using System;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public event Action Hit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Projectile>(out _))
        {
            Hit?.Invoke();
        }
    }
}
