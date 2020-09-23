using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    bool playedSF1;
    bool playedSF2;
    bool playedSF3;
    bool playedMenuMusic;

    GameObject managerObject;
    GameManager managerScript;

    public AudioClip lightsOn;
    public AudioClip gameMusic;
    public AudioClip applause;
    public AudioClip menuMusic;

    public AudioSource source1;
    public AudioSource source2;

    // Start is called before the first frame update
    void Start()
    {
        managerObject = GameObject.Find("ManagerHolder");
        managerScript = managerObject.GetComponent<GameManager>();

        playedSF1 = false;
        playedSF2 = false;
        playedSF3 = false;
        playedMenuMusic = false;

        source1.loop = false;
        source2.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(managerScript.currentLevel < 6)
        {
            if (!managerScript.levelStarted && !playedMenuMusic)
            {
                source2.clip = menuMusic;
                source2.loop = true;
                source2.Play();
                playedMenuMusic = true;
            }
            if (managerScript.levelStarted && !playedSF1)
            {
                source2.Stop();
                source1.PlayOneShot(lightsOn);
                playedSF1 = true;
            }
            if (!managerScript.levelWon && playedSF1 && source1.isPlaying == false && !playedSF2)
            {
                source1.clip = gameMusic;
                source1.loop = true;
                source1.Play();
                playedSF2 = true;
            }
            if (managerScript.levelWon)
            {
                if (source1.volume > 0)
                {
                    source1.volume -= 4 * Time.deltaTime;
                }
                else if (source2.volume <= 0)
                {
                    source1.Stop();
                }

                if (!playedSF3 && managerScript.currentLevel < 5)
                {
                    source2.PlayOneShot(applause);
                    playedSF3 = true;
                }
            }
        }
    }
}
