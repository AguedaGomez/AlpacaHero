using UnityEngine;
using System.Collections;

public class AlpacaController : MonoBehaviour {

    public Sprite[] AlpacaSprites;

    int indice = 2;

    SpriteRenderer renderer;

    void Start() {
        renderer = this.GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (renderer.sprite != AlpacaSprites[indice]) {
           changeSprite(indice);
        }
    }

    public void changeIndexSprite(int i) {
        indice = i;
    }

     void changeSprite(int i) {
        renderer.sprite = AlpacaSprites[i];


    }
}
