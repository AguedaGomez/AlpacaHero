using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

    private float timeBetweenNotas=3f;
    private float ellapsedTime = 0f;

    private float actualVolume = 1f;
    private float SpeedY = -0.05f;
    private float actualSpeed = -0.05f;
    private float endSongTime;

    private int puntosAcierto = 10;

    private int notasSeguidas = 0;
    private int notasFalladasSeguidas=0;

    private bool changeParamaters = false;
    private bool ended = false;


    public static int puntuacion = 0;

    public GameObject scoreGO;
    public ScoreManagerScript scoreText;
    

    public GameObject[] notas;
    public Transform[] posiciones;
    public SpriteRenderer[] feedBackImages;
    private bool[] feedBackStates;


    public GameObject Alpaca;
    AlpacaController alpacaController;

    public AudioSource song;
    public AudioClip[] allSongs;

    AudioClip clip;

    void Start() {
        ended = false;
        int r =(int) Random.Range(0, allSongs.Length);
        clip = allSongs[r];
        song.clip = clip;
        song.Play();

        alpacaController = Alpaca.GetComponent<AlpacaController>();
        endSongTime = song.clip.length +10;
        feedBackStates = new bool[4];
        for (int i = 0; i < 4;i++) feedBackStates[i] = false;
    }


    void Update()
    {
        if (Time.time >= endSongTime) {
            ended = true;
            EndSong.puntuacion = puntuacion;
            Application.LoadLevel(2);

            return;
        }
        if (!ended)
        {
            if (Time.time - ellapsedTime >= timeBetweenNotas)
            {
                ellapsedTime = Time.time;
                createNota();
            }

            if (changeParamaters)
            {
                song.volume = actualVolume;

                changeParamaters = false;

            }

            for (int i = 0; i < 4; i++) {
                if (feedBackImages[i].enabled != feedBackStates[i])
                    feedBackImages[i].enabled = feedBackStates[i];
            }
        }
	}


    void createNota() {

        int r = Random.Range(0, 4);
        int s = Random.Range(1, 5);
        GameObject f= Instantiate(notas[r], posiciones[r].position, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
        f.transform.localScale = new Vector3(0.5f, s, 1f); 

    }

    
    public void AumentaPuntuacion() {

        puntuacion += puntosAcierto * notasSeguidas;
        scoreText.UpdateText(puntuacion);
        
    }


    public void SetNotasSegiudas() {
        notasSeguidas += 1;
        if (notasFalladasSeguidas != 0) notasFalladasSeguidas = 0;

        actualVolume+=  0.1f;
        actualSpeed -= 0.01f;
            

        if (actualVolume >1)     actualVolume =1f;
        if (actualSpeed < -0.1) actualSpeed = -0.1f;

        changeParamaters = true;
        AumentaPuntuacion();
        Debug.Log("NOTAS EGUIDAS: " + notasSeguidas);
        updateAlpaca();
    }


    public int GetNotasSeguidas() { return notasSeguidas; }


    public void SetNotasFalladasSegiudas() {
        notasFalladasSeguidas+= 1;
        if (notasSeguidas != 0) notasSeguidas = 0;

        actualVolume -=  0.1f;
        actualSpeed += 0.01f;

        if (actualVolume < 0)    actualVolume = 0f;
        if (actualSpeed > -0.05) actualSpeed = -0.05f;

        changeParamaters = true;
        Debug.Log("NOTAS EGUIDAS FALLADAS: " + notasFalladasSeguidas);

        updateAlpaca();

    }


    public int GetNotasFalladasSeguidas() { return notasFalladasSeguidas; }


    public int GetPuntuacion() { return puntuacion;}


    private void updateAlpaca() {

        int i;
        if (notasFalladasSeguidas > 3) { i = 0; }
        else if (notasFalladasSeguidas > 2) { i = 1; }
        else if (notasSeguidas >3) { i = 3; }
        else  { i = 2; }


        alpacaController.changeIndexSprite(i);

    }

    public void GoodMessageAppears()
    {
        scoreText.ok.color = new Color(0,0,0,1); //desencadenar una animación
    }

    public void GoodMessageDesappears()
    {
        scoreText.ok.color = new Color(0, 0, 0, 0);
    }

    public float GetSpeedY() { return SpeedY; }

    public void SetSpeedY(int s) { SpeedY = s; }

    public void setFeedback(int s, bool b) { feedBackStates[s] = b; }
}
