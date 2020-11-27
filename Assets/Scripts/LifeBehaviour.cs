using UnityEngine;
using UnityEngine.Events;

public class LifeBehaviour : MonoBehaviour
{

    #region Fields/Properties

    /// <summary>
    /// Current life (changed at runtime).
    /// </summary>
    public int CurrentLife
    {
        get { return _currentLife; }
    }

    [SerializeField]
    [Tooltip("Current life (changed at runtime). Initialized on start with LifeData.MaxLife.")]
    private int _currentLife = 100;

    [SerializeField]
    [Tooltip("LifeData for this LifeBehaviour.")]
    private LifeData _lifeData;

    // OPTION 1 (serialized private field):
    [SerializeField]
    [Tooltip("Methods subscribed to OnLifeChanged event.")]
    private UnityEvent<int> OnLifeChangedEvent; // Listeners can be added only in the inspector. Doesn't need instantiation from code (it happens someway before the object awakes).
    // OPTION 2 (public field):
    // public UnityEvent<int> OnLifeChangedEvent; // Listeners can be added in inspector and from other classes. Doesn't need instantiation from code (it happens someway before the object awakes).
    // OPTION 3 (public property):
    // public UnityEvent<int> OnLifeChangedEvent { get; private set; } // Not shown in inspector, ALL classes can access. Needs instantiation (here or in Awake).
    // OPTION 4 (internal field):
    // internal UnityEvent<int> OnLifeChangedEvent; // Not shown in inspector, but classes IN THE SAME ASSEMBLY can access. Needs instantiation (here or in Awake).

    #endregion

    #region Lifecycle

    // OPTIONS 3 & 4:
    /*
    private void Awake()
    {
        // WARNING: If you do this with options 1 & 2, listeners added in the inspector will be removed.
        OnLifeChangedEvent = new UnityEvent<int>();
    }
    */

    private void Start()
    {
        _currentLife = _lifeData.MaxLife;
        OnLifeChanged();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Apply damage to current life.
    /// </summary>
    /// <param name="damage">Points of damage.</param>
    public void ApplyDamage(int damage)
    {
        /// We'll try to change current life only if damage is greater than <see cref="_lifeData.Resistance">.
        if (damage > _lifeData.Resistance)
        {
            if (TryChangeCurrentLife(_lifeData.Resistance - damage))
            {
                OnLifeChanged();
            }
        }
    }

    /// <summary>
    /// Apply healing to current life.
    /// </summary>
    /// <param name="healing">Points of healing.</param>
    public void ApplyHealing(int healing)
    {
        if (TryChangeCurrentLife(healing))
        {
            OnLifeChanged();
        }
    }

    private void OnLifeChanged()
    {
        OnLifeChangedEvent?.Invoke(_currentLife);
    }

    private bool TryChangeCurrentLife(int delta)
    {
        int _previousLife = _currentLife;
        _currentLife = Mathf.Clamp(_currentLife + delta, 0, _lifeData.MaxLife);
        return _currentLife != _previousLife;
    }

    #endregion

}
