using UnityEngine;

[CreateAssetMenu(fileName = "LifeData", menuName = "Data/LifeData")]
public class LifeData : ScriptableObject
{

    #region Fields/Properties

    /// <summary>
    /// Max life value allowed for <see cref="LifeBehaviour"/>.
    /// </summary>
    public int MaxLife
    {
        get { return _maxLife; }
    }

    [SerializeField]
    private int _maxLife = 100;

    /// <summary>
    ///  Resistance value is substracted from every damage a <see cref="LifeBehaviour"/> receives.
    /// </summary>
    public int Resistance
    {
        get { return _resistance; }
    }

    [SerializeField]
    private int _resistance = 5;

    #endregion

}