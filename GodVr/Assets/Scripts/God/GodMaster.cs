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

    public InteractableWorldObject rock;
    public InteractableWorldObject displayItem = null;
    public InteractableWorldObject heldItem = null;

    public void WriteInput(BitArray input)
    {

        for (int i = 0; i < input.Length; i++)
        {
            Debug.Log(i + " = " + input[i]);
        }

        if (input[0] == true)
        {
            
            if (!heldItem)
            {
                displayItem = Instantiate(rock);
            }
            
        }

        if (input[1] == true)
        {

            if (displayItem)
            {
                Destroy(displayItem.gameObject);
                displayItem = null;
            }

        }

        if (input[2] == true)
        {

            if (displayItem)
            {
                //Close Menu
                heldItem = displayItem;
                displayItem = null;
            }
            
        }

        if (input[3] == true)
        {
            //Throw/Place/Drop
            heldItem = null;
        }

    } 

    #endregion

}