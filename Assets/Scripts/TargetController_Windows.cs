using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class TargetController_Windows : MonoBehaviour
{
    SerialPort sp;
    float next_time; //int ii = 0;
    float serialData;
    // Use this for initialization
    void Start()
    {
        string the_com = "";
        next_time = Time.time;

        //this code scans available serial ports to see which one the sensor is communicating on
        foreach (string mysps in SerialPort.GetPortNames())
        {
            print(mysps);
            if (mysps != "COM1") { the_com = mysps; break; }
        }
        sp = new SerialPort("\\\\.\\" + the_com, 9600);
        if (!sp.IsOpen)
        {
            print("Opening " + the_com + ", baud 9600");
            sp.Open();
            sp.ReadTimeout = 100;
            sp.Handshake = Handshake.None;
            if (sp.IsOpen) { print("Open"); }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            //print("Open");
            try
            {
                //CHANGE CODE HERE//

                //this code is for button pushes
                // When left button is pushed
                if (sp.ReadByte() == 1)
                {
                    print(sp.ReadByte());
                    transform.Translate(Vector3.left * Time.deltaTime * 0.5f);
                }
                // When right button is pushed
                if (sp.ReadByte() == 2)
                {
                    print(sp.ReadByte());
                    transform.Translate(Vector3.right * Time.deltaTime * 0.5f);
                }
            }
            catch (System.Exception)
            {

            }

        }
    }
}