using UnityEngine;

public class TestAudioMaster : MonoBehaviour
{

    [SerializeField]
    private TestAudioConfig testAudioConfig = null;
    [SerializeField]
    private TestAudioData testAudioData = null;

    private TestAudioController testAudioController = null;

    private void Awake()
    {
        testAudioController = new TestAudioController(this, testAudioConfig, testAudioData);
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
}
