using UnityEngine;
using UnityEngine.EventSystems;

public class DamageButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private float _damage;

    private HealthBehavior _healthBehavior;

    private void Awake()
    {
        _healthBehavior = FindObjectOfType<HealthBehavior>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _healthBehavior.DoDamage(_damage);
    }
}
