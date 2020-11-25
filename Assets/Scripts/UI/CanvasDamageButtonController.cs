using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasDamageButtonController : MonoBehaviour, IPointerClickHandler
{
    #region Fields/Properties

    [SerializeField]
    [Tooltip("LifeBehaviour affected by this damage source.")]
    private LifeBehaviour _damageTarget;

    [SerializeField]
    [Tooltip("Level of damage (in life points) of this damage source.")]
    private int _damageLevel = 1;

    #endregion

    #region IPointerClickHandler implementation

    /// <summary>
    /// Handles click inputs on the GameObject.
    /// </summary>
    /// <param name="pointerEventData">Event payload associated with pointer (mouse / touch) events.</param>
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        _damageTarget.ApplyDamage(_damageLevel);
    }

    #endregion

}
