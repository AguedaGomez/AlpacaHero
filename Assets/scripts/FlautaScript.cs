using UnityEngine;
using System.Collections;
using System.Threading;


public class FlautaScript : MonoBehaviour
{
    public GameObject gControllerGO;

    gameController gController;

    private bool activated = false;
    private bool hayColision = false;

    public int Index;


    // Use this for initialization
    void Start()
    {
        gController = gControllerGO.GetComponent<gameController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void haySoplido()
    {

        activated = true;
        if (hayColision) {

            Debug.Log("acierto");
            gController.SetNotasSegiudas();
            gController.setFeedback(Index, true);
           // gController.GoodMessageAppears();

        }
         


    }

    public void noHaySoplido()
    {
        activated = false;
        gController.setFeedback(Index, false);

        if (hayColision) {
            hayFallo();
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        hayColision = true;
        
        if (!activated)
        {
            hayFallo();
        }

       
    }

    void OnTriggerExit2D(Collider2D c)
    {
        hayColision = false;
       // gController.GoodMessageDesappears();
        noHaySoplido();

    }

    void hayFallo() {
        gController.SetNotasFalladasSegiudas();
        Debug.Log("fallo");
    }
}
