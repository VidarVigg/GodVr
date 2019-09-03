using System.Collections;
using UnityEngine;

public class GodMaster : MonoBehaviour
{

    #region Fields

    [SerializeField]
    private GodConfig config = null;

    [SerializeField]
    private GodData data = null;

    private GodController controller = null;

    #endregion

    #region Methods
    private void Awake()
    {
        controller = new GodController(this, config, data);
    }
    private void Start()
    {

    }

    private void Update()
    {
        controller.Update();
    }

    public void SetInput(BitArray input)
    {

        string result = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            result = string.Concat(result, input[i].ToString());
        }

        Debug.Log(result);
    } 

    #endregion

}