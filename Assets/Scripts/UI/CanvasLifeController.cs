using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLifeController : MonoBehaviour
{

    #region Fields/Properties

    // OPTIONS 3 & 4 need this:
    /*
    [SerializeField]
    [Tooltip("Player's LifeBehaviour component.")]
    private LifeBehaviour _playerLifeBehaviour;
    */ 

    private Text _label;

    private Text _value;

    #endregion

    #region Lifecycle

    private void Awake()
    {
        _label = transform.Find("Label").GetComponent<Text>();
        _label.color = Color.black;

        _value = transform.Find("Value").GetComponent<Text>();
        _value.color = Color.black;
    }

    // OPTIONS 3 & 4 need this:
    /*
    private void OnEnable()
    {
        _playerLifeBehaviour.OnLifeChangedEvent.AddListener(Refresh);
        // DUDA!
        //_playerLifeBehaviour.OnLifeChangedEvent.AddListener(Refresh); -- ¿Se añade otro?
    }

    private void OnDisable()
    {
        _playerLifeBehaviour.OnLifeChangedEvent.RemoveListener(Refresh);
    }
    */

    #endregion

    #region Methods

    public void Refresh(int currentLife)
    {
        if (currentLife <= 0)
        {
            _label.color = Color.red;
            _value.color = Color.red;
        }
        _value.text = Convert.ToString(currentLife);
    }

    #endregion

}
