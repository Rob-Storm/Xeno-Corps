using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource musicSource;

    [SerializeField] private AudioClip[] geoscapeTracks;
    [SerializeField] private AudioClip[] briefingTracks;
    [SerializeField] private AudioClip[] battlescapeTracks;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    public void OnEnable()
    {
        GameManager.Instance.OnGameStateChanged += GameManager_OnGameStateChanged;
    }
    public void OnDisable()
    {
        GameManager.Instance.OnGameStateChanged -= GameManager_OnGameStateChanged;
    }

    private void Start()
    {
        musicSource.loop = true;
    }

    public void PlayRandomClip(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Geoscape:
                musicSource.clip = RandomSong(geoscapeTracks);
                break;
            case GameState.Briefing:
                musicSource.clip = RandomSong(briefingTracks);
                break;
            case GameState.BattleScape:
                musicSource.clip = RandomSong(battlescapeTracks);
                break;
            default:
                Debug.LogWarning("No Valid GameState Set!");
                break;
        }

        musicSource?.Play();
    }

    private AudioClip RandomSong(AudioClip[] audioClips) 
    {
        System.Random random = new System.Random();

        return audioClips[random.Next(0, audioClips.Length)];
    }

    private void GameManager_OnGameStateChanged(object sender, StateEventArgs e)
    {
        PlayRandomClip(e.NewGameState);
    }
}
