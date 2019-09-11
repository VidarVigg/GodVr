using UnityEngine;

public class TestAudioController
{
    #region Fields


    private TestAudioMaster testAudioMaster = null;

    private TestAudioConfig testAudioConfig = null;

    private TestAudioData testAudioData = null;

    #endregion

    #region Constructors

    private TestAudioController() { }
    public TestAudioController(TestAudioMaster testAudioMaster, TestAudioConfig testAudioConfig, TestAudioData testAudioData)
    {
        this.testAudioMaster = testAudioMaster;
        this.testAudioConfig = testAudioConfig;
        this.testAudioData = testAudioData;
    }

    #endregion

    #region Methods



    #endregion
}