using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour {

    public Text scoreText;
    public Text ok;

    public void UpdateText(int p) {
        scoreText.text = "PUNTOS: " + p;
    }
}
