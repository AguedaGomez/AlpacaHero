using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndSong : MonoBehaviour {

    public Text scoreText;
    public Image Alpaca;

    public Sprite[] AlpacaSprites;
    public AudioClip[] sounds;
    public AudioSource aSource;

    public static int puntuacion = 0;


    // Use this for initialization
    void Start () {
        scoreText.text =""+ puntuacion;

        if (gameController.puntuacion < 800) {
            Alpaca.sprite = AlpacaSprites[1];
            aSource.clip = sounds[0];
        }
        else
        {
            Alpaca.sprite = AlpacaSprites[0];
            aSource.clip = sounds[1];

        }
        aSource.Play();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void End() { Application.Quit(); }

    public void Restart()
    {

        Debug.Log("cambio escena");
        Application.LoadLevel(1);
    }
}
