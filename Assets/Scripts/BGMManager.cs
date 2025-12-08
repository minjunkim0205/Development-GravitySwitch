using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;

    private AudioSource audioSource;

    public AudioClip startBGM;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;

        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        audioSource.volume = savedVolume;
    }

    private void Start()
    {
        if (startBGM != null)
        {
            PlayBGM(startBGM);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        if (clip == null) return;

        if (audioSource.clip == clip) return;

        audioSource.clip = clip;
        audioSource.Play();
    }

    public void SetVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }
}
