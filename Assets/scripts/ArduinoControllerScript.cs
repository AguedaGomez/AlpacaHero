using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;


public class ArduinoControllerScript : MonoBehaviour
{
    public FlautaScript[] flautas;
    public Vector3 desactivadas;

    SerialPort sp = new SerialPort("COM9", 9600);
    int bitRead;

    // Use this for initialization
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {

                if ((bitRead = sp.ReadByte()) != 0)
                {


                    if (bitRead == 49)
                    {
                        // Debug.Log("He soplado en el 1");
                        flautas[0].haySoplido();
                        desactivadas = new Vector3(1, 2, 3);

                    }


                    if (bitRead == 50)
                    {
                        // Debug.Log("He soplado en el 2");
                        flautas[1].haySoplido();
                        desactivadas = new Vector3(0, 2, 3);

                    }


                    if (bitRead == 51)
                    {
                        //Debug.Log("He soplado en el 3");
                        flautas[2].haySoplido();
                        desactivadas = new Vector3(0, 1, 3);

                    }


                    if (bitRead == 52)
                    {
                        // Debug.Log("He soplado en el 4");
                        flautas[3].haySoplido();
                        desactivadas = new Vector3(0, 1, 2);

                    }

                    desactivarFlauta();

                }

            }
            catch
            {

            }

        }
    }

    public void desactivarFlauta()
    {/*
        for (int i = 0; i < 3; i++)
        {
            flautas[(int)desactivadas[i]].apagarFlash();
        }*/
    }
}

