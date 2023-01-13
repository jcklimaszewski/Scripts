using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicLoop : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicStart;
    public bool isMuted;
    public GameObject playerSprite;
    public GameObject playerStillSprite;

    public TMP_Text muteButtonText;

    // Start is called before the first frame update
    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;

        if (isMuted)
        {
            AudioListener.pause = isMuted;
        }

        musicSource.PlayOneShot(musicStart);
        musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }
    void Update()
    {
        if(isMuted)
        {
            muteButtonText.text = "Unmute Music";
            playerSprite.gameObject.SetActive(false);
            playerStillSprite.gameObject.SetActive(true);
        }
        else
        {
            muteButtonText.text = "Mute Music";
            playerSprite.gameObject.SetActive(true);
            playerStillSprite.gameObject.SetActive(false);
        }
    }
    public void MuteMusic()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
    }
}