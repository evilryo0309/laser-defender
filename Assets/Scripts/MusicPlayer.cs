using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	static MusicPlayer instance = null;

    public AudioClip StartMenu;
    public AudioClip Game;
    public AudioClip TryAgainMenu;

    AudioSource music;
	
	void Start () {
        music = GetComponent<AudioSource>();

		if (instance != null && instance != this)
        {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else
        {
			instance = this;
			DontDestroyOnLoad(gameObject);
            music.clip = StartMenu;
            music.loop = true;
            music.Play();
		}
	}

    private void OnLevelWasLoaded(int level)
    {
        music.Stop();
        if (level == 0)
            music.clip = StartMenu;
        else if (level == 1)
            music.clip = Game;
        else if (level == 2)
            music.clip = TryAgainMenu;
        music.loop = true;
        music.Play();
    }
}
