using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        MenuClick,
        PlayerMove,
        PlayerCraft,
        NormalAttack,
        CarBatteryAttack,
        DynamiteAttack,
        HammerHeadAttack,
        LighterAttack,
        RubberDuckAttack,
        SawBladeAttack,
        SwingSound,
        ChainAttack,
        DrillAttack,
        EnemyHit,
        EnemyDie,
        ItemPickUp
    }

    public static void PlaySound(Sound sound)
    {
        GameObject soundGO = new GameObject("Sound");
        AudioSource audioSource = soundGO.AddComponent<AudioSource>();
        audioSource.AddComponent<SoundDestroyer>();
        audioSource.GetComponent<SoundDestroyer>().timeToDestroy = GetAudioClip(sound).length;
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (Database.SoundAudioClip soundAudioClip in Database.getSoundAudioClipArray())
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}
