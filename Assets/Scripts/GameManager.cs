using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int score;
    public int highscore;
    public Text scoreText;
    public Text highscoreText;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;
    public Text gameOverPanelHighscoreText;


    [Header("Sounds")]
    public AudioClip[] eatSounds;
    public AudioClip hitSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
    }

    public void RestartGame()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOverPanel.SetActive(false);

        // foreach(GameObject g in GameObject.FindObjectsWithTag("Interactable"))
        // { Destroy(g); }

        // Time.timeScale = 1;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
    }

    public void PlayRandomEatSound()
    {
        AudioClip randSound = eatSounds[Random.Range(0, eatSounds.Length)];
        audioSource.PlayOneShot(randSound);
    }
}
