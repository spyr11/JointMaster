using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _force;

    private bool _isForced;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isForced = true;
        }
    }

    private void FixedUpdate()
    {
        if (_isForced)
        {
            _rigidbody.AddForce(Vector3.forward * _force);

            _isForced = false;
        }
    }
}
