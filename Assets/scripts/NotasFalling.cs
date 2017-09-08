using UnityEngine;
using System.Collections;

public class NotasFalling : MonoBehaviour {

    private float destroyLimit = -6f;

    private Transform indicador;

    private gameController gCScript;
    private float speedY;

    // Use this for initialization
    void Start () {
        indicador = this.GetComponent<Transform>();
        gCScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>(); ;
        speedY = gCScript.GetSpeedY();
    }

    // Update is called once per frame
    void Update () {

        indicador.position+= new Vector3(0f, speedY * Time.deltaTime,0f);

        if (indicador.position.y <= destroyLimit)
        {
            Destroy(this.gameObject);
        }

    }

 
  
}
