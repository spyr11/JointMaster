using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;

    private ObjectPool<Projectile> _pool;

    private void Awake()
    {
        int maxSize = 10;

        _pool = new ObjectPool<Projectile>(InstantiateProjectile,
                                           GetProjectile,
                                           ReleaseProjectile,
                                           DestroyProjectile,
                                           maxSize: maxSize);
    }

    public void Drop()
    {
        _pool.Get();
    }

    private Projectile InstantiateProjectile()
    {
        Projectile projectile = Instantiate(_projectilePrefab);

        projectile.Disabled += OnDisabled;

        return projectile;
    }

    private void DestroyProjectile(Projectile projectile)
    {
        projectile.Disabled -= OnDisabled;

        Destroy(projectile.gameObject);
    }

    private void OnDisabled(Projectile projectile)
    {
        _pool.Release(projectile);
    }

    private void GetProjectile(Projectile projectile)
    {
        projectile.transform.position = transform.position;
        projectile.gameObject.SetActive(true);
    }

    private void ReleaseProjectile(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
    }
}