using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    [SerializeField] private AudioConfig audioConfig = null;
    [SerializeField] private AudioData audioData = null;

    private AudioController audioController = null;

    private void Awake()
    {
        audioController = new AudioController(this, audioConfig, audioData);

    }

    void Start()
    {

    }


    void Update()
    {

    }
}
