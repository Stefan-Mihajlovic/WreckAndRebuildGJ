using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    private AudioClip CalmEntry;
    [SerializeField]
    private AudioClip CalmLocation;
    [SerializeField]
    private AudioClip ChaoticFight;

    private float calmEntryLength, elapsedTime;
    private bool isEntryPlayed = false;
    private bool isFightMusicPlaying = false;

    public static MusicController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        calmEntryLength = CalmEntry.length;
        this.GetComponent<AudioSource>().loop = false;
        this.GetComponent<AudioSource>().clip = CalmEntry;
        this.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > calmEntryLength && !isEntryPlayed)
        {
            this.GetComponent<AudioSource>().clip = CalmLocation;
            this.GetComponent<AudioSource>().loop = true;
            this.GetComponent<AudioSource>().Play();
            isEntryPlayed = true;
        }
    }

    private void setFightMusic()
    {
        Debug.Log("Set Fight");
        this.gameObject.GetComponent<AudioSource>().clip = ChaoticFight;
        this.GetComponent<AudioSource>().Play();
        isFightMusicPlaying = true;
    }

    private void setCalmLocationMusic()
    {
        Debug.Log("Set Calm");
        this.gameObject.GetComponent<AudioSource>().clip = CalmLocation;
        this.GetComponent<AudioSource>().Play();
        isFightMusicPlaying = false;
    }

    public static void playFightMusic()
    {
        Debug.Log(instance);
        if (!instance.GetIsFightMusicPlaying())
        {
            instance.setFightMusic();
        }
    }

    public static IEnumerator stopFightMusic()
    {
        yield return new WaitForSeconds(2f);
        if (instance.GetIsFightMusicPlaying())
        {
            instance.setCalmLocationMusic();
        }
    }

    private bool GetIsFightMusicPlaying()
    {
        return instance.isFightMusicPlaying;
    }
}
