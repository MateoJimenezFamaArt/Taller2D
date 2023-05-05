using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField] SoundDataBaseSO SoundDTBase;
    public SoundDataBaseSO PublicAudioDatabase => SoundDTBase;
    [SerializeField] AudioSource audioSourceSFX, audioSourceMusic;
    public static AudioManagerScript instance = null;
    public enum AudioSamples
    {
        //GamePLaySfx
        Shoot = 0, EnemyShoot = 1, CharacterHit = 2, CharacterHealthUp = 3, EnemyDie = 4, PlayerDeath = 5,
        //Music For Game
        UIMusic = 6, GameplayMusicLVl1 = 7, GameplayMusicLVl2 = 8, GameplayMusicLVl3 = 9 , GameplayMusicBoss = 10, CreditsMusic = 11, SecretMusic = 12
    }

    private void Awake()
    {
        if(instance  != null && instance != this)
        {
            
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
       
        DontDestroyOnLoad(gameObject);

    }

    public void PlaySFXs(AudioSamples SFXSamples)
    {
        AudioClip currentClip = SoundDTBase.GetFromDTBase(SFXSamples);
        audioSourceSFX.PlayOneShot(currentClip);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += PlayMusic;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= PlayMusic;
    }

    public void PlayMusic(Scene scene,LoadSceneMode loadscenemode)
    {
        scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "MainMenu'":
                AudioClip currentClip = SoundDTBase.GetFromDTBase(AudioSamples.UIMusic);
                audioSourceMusic.clip = currentClip;
                audioSourceMusic.Stop();
                audioSourceMusic.Play();
                break;
            case "FirstLevel":
                AudioClip currentClipA = SoundDTBase.GetFromDTBase(AudioSamples.GameplayMusicLVl1);
                audioSourceMusic.clip = currentClipA;
                audioSourceMusic.Stop();
                audioSourceMusic.Play();
                break;
            case "SecondLevel":
                AudioClip currentClipB = SoundDTBase.GetFromDTBase(AudioSamples.GameplayMusicLVl2);
                audioSourceMusic.clip = currentClipB;
                audioSourceMusic.Stop();
                audioSourceMusic.Play();
                break;
            case "ThridLevel":
                AudioClip currentClipC = SoundDTBase.GetFromDTBase(AudioSamples.GameplayMusicLVl3);
                audioSourceMusic.clip = currentClipC;
                audioSourceMusic.Stop();
                audioSourceMusic.Play();
                break;
            case "BossScene":
                AudioClip currentClipD = SoundDTBase.GetFromDTBase(AudioSamples.GameplayMusicBoss);
                audioSourceMusic.clip = currentClipD;
                audioSourceMusic.Stop();
                audioSourceMusic.Play();
                break;
            case "Creds":
                AudioClip currentClipE = SoundDTBase.GetFromDTBase(AudioSamples.CreditsMusic);
                audioSourceMusic.clip = currentClipE;
                audioSourceMusic.Stop();
                audioSourceMusic.Play();
                break;
            case "SecretScene":
                AudioClip currentClipF = SoundDTBase.GetFromDTBase(AudioSamples.SecretMusic);
                audioSourceMusic.clip = currentClipF;
                audioSourceMusic.Stop();
                audioSourceMusic.Play();
                break;
        }
    }


}

