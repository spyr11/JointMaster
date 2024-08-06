using UnityEngine;

public class SpringSwitcher : MonoBehaviour
{
    [SerializeField] private Joint _reload;
    [SerializeField] private Joint _fire;

    private void Awake()
    {
        _reload.gameObject.SetActive(false);
        _fire.gameObject.SetActive(false);
    }

    public void Fire()
    {
        _reload.gameObject.SetActive(false);
        _fire.gameObject.SetActive(true);
    }

    public void Reload()
    {
        _reload.gameObject.SetActive(true);
        _fire.gameObject.SetActive(false);
    }
}
