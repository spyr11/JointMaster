using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] private Catapult _catapult;
    [SerializeField] private Image _reload;
    [SerializeField] private Image _fire;

    private void OnEnable()
    {
        _catapult.Redied += ActivateFireUI;
        _catapult.Fired += ActivateReloadUI;
        _catapult.Reloaded += DisableReloadUI;
    }

    private void OnDisable()
    {
        _catapult.Redied -= ActivateFireUI;
        _catapult.Fired -= ActivateReloadUI;
        _catapult.Reloaded -= DisableReloadUI;
    }

    private void ActivateReloadUI()
    {
        _reload.gameObject.SetActive(true);
        DisableFireUI();
    }

    private void ActivateFireUI() => _fire.gameObject.SetActive(true);

    private void DisableReloadUI() => _reload.gameObject.SetActive(false);

    private void DisableFireUI() => _fire.gameObject.SetActive(false);
}
