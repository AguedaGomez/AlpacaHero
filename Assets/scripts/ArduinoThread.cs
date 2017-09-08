using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class ArduinoThread:MonoBehaviour  {

    public FlautaScript[] flautas;
    //public Vector3 desactivadas;
    public int flauta;

    SerialPort sp = new SerialPort("COM9", 9600);
    int bitRead;

    // Use this for initialization
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 16;
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
                    Thread myThread = new Thread(new ThreadStart(ThreadTask));
                    myThread.Start();
                    activarFlauta();
                }
            }
            catch { }
        }
    }

    void ThreadTask()
    {
        try
        {
            if (bitRead == 49)
            {
               // Debug.Log("He soplado en el 1");

                flauta = 0;
            }
            else {
                desactivarFlauta(0);
            }


            if (bitRead == 50)
            {
             //   Debug.Log("He soplado en el 2");
                flauta = 1;

            }
            else
            {
                desactivarFlauta(1);
            }


            if (bitRead == 51)
            {
              //  Debug.Log("He soplado en el 3");
                flauta = 2;

            }
            else
            {
                desactivarFlauta(2);
            }


            if (bitRead == 52)
            {
             //   Debug.Log("He soplado en el 4");
                flauta = 3;
            }
            else
            {
                desactivarFlauta(3);
            }


        }
        catch { }

    }

    public void activarFlauta()
    {
        flautas[flauta].haySoplido();

    }

    public void desactivarFlauta(int f) {
     //   Debug.Log("Desactivo flauta " + f);
        flautas[f].noHaySoplido();
    }

  
}
