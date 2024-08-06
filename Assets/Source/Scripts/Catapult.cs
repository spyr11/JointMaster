using System;
using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringSwitcher _springSwitcher;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Basket _basket;
    [SerializeField] private float _delay = 1f;

    private bool _hasBullet;

    private Coroutine _coroutine;

    public event Action Redied;
    public event Action Fired;
    public event Action Reloaded;

    private void OnValidate() => _delay = Mathf.Clamp(_delay, 0, float.MaxValue);

    private void OnEnable() => _basket.Hit += OnHit;

    private void OnDisable() => _basket.Hit -= OnHit;

    private void Start() => Fired?.Invoke();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _hasBullet)
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R) && _hasBullet == false && _coroutine == null)
        {
            _coroutine = StartCoroutine(Reload(_delay));

            Reloaded?.Invoke();
        }
    }

    private void Fire()
    {
        _springSwitcher.Fire();

        Fired?.Invoke();

        _hasBullet = false;

        _coroutine = null;
    }

    private void OnHit()
    {
        _hasBullet = true;

        Redied?.Invoke();
    }

    private IEnumerator Reload(float seconds)
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(seconds);

        yield return waitForSeconds;

        _springSwitcher.Reload();

        yield return waitForSeconds;

        _spawner.Drop();
    }
}