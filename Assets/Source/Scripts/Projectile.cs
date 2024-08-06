using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 1f;

    private Coroutine _coroutine;
    private Rigidbody _rigidBody;

    public event Action<Projectile> Disabled;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        _coroutine = null;
        _rigidBody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Basket>(out _) == false && _coroutine == null)
        {
            _coroutine = StartCoroutine(TryDisable(_lifeTime));
        }
    }

    private IEnumerator TryDisable(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);

        Disabled?.Invoke(this);
    }
}