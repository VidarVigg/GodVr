using UnityEngine;

public class UnitAIMaster : MonoBehaviour
{

    #region Fields

    [SerializeField]
    private UnitAIConfig unitAIConfig = null;

    [SerializeField]
    private UnitAIData unitAIData = null;

    private UnitAIController unitAIController = null;

    #endregion

    #region Methods

    private void Awake()
    {
        unitAIController = new UnitAIController(this, unitAIConfig, unitAIData);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

}
