using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SoundDataBaseSO", menuName = "AudioCloud")]
public class SoundDataBaseSO : ScriptableObject
{
    [SerializeField] AudioClip PlayerShootSFX = default;
    [SerializeField] AudioClip PlayerHealthDownSFX = default;
    [SerializeField] AudioClip PlayerHealthUpSFX = default;
    [SerializeField] AudioClip PlayerDieSFX = default;
    [SerializeField] AudioClip EnemyShootSFX = default;
    [SerializeField] AudioClip EnemyDeathSFX = default;
    [SerializeField] AudioClip UIMusic = default;
    [SerializeField] AudioClip Level1Music = default;
    [SerializeField] AudioClip Level2Music = default;
    [SerializeField] AudioClip Level3Music = default;
    [SerializeField] AudioClip LevelBossMusic = default;
    [SerializeField] AudioClip CreditsMusic = default;
    [SerializeField] AudioClip SecretMusic = default;
    [SerializeField] AudioClip BossStartSFX = default;
    [SerializeField] AudioClip Win = default;
    [SerializeField] AudioClip MotoDie = default;
    [SerializeField] AudioClip DefaultSound = default;

    public AudioClip GetFromDTBase(AudioManagerScript.AudioSamples Audios) => Audios switch
    {
        AudioManagerScript.AudioSamples.Shoot => PlayerShootSFX,
        AudioManagerScript.AudioSamples.CharacterHit => PlayerHealthDownSFX,
        AudioManagerScript.AudioSamples.CharacterHealthUp => PlayerHealthUpSFX,
        AudioManagerScript.AudioSamples.PlayerDeath => PlayerDieSFX,
        AudioManagerScript.AudioSamples.EnemyShoot => EnemyShootSFX,
        AudioManagerScript.AudioSamples.UIMusic => UIMusic,
        AudioManagerScript.AudioSamples.GameplayMusicLVl1 => Level1Music,
        AudioManagerScript.AudioSamples.GameplayMusicLVl2 => Level2Music,
        AudioManagerScript.AudioSamples.GameplayMusicLVl3 => Level3Music,
        AudioManagerScript.AudioSamples.GameplayMusicBoss => LevelBossMusic,
        AudioManagerScript.AudioSamples.CreditsMusic => CreditsMusic,
        AudioManagerScript.AudioSamples.EnemyDie => EnemyDeathSFX,
        AudioManagerScript.AudioSamples.SecretMusic => SecretMusic,
        AudioManagerScript.AudioSamples.BossStart => BossStartSFX,
        AudioManagerScript.AudioSamples.MotoCrash => MotoDie,
        AudioManagerScript.AudioSamples.Win => Win,
        _ => DefaultSound
    }; 

}
