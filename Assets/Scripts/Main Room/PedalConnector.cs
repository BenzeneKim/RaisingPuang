using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using UnityEngine;

public class PedalConnector : MonoBehaviour
{
    public static PedalConnector instance;
    private SerialPort _serialPort = new SerialPort();
    [SerializeField] private bool isConnected;
    public int pedalValue = 0;
    private Coroutine _reader;
    // Start is called before the first frame update
    void Awake()
    {
        // Ensure there is only one instance of GlobalVariables
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public List<string> GetPortList()
    {
        return SerialPort.GetPortNames() != null ? SerialPort.GetPortNames().ToList<string>() : null;
    }

    public bool Connect(string portName)
    {
        if (_serialPort.IsOpen) return true;
        try
        {
            _serialPort.PortName = portName;
            _serialPort.BaudRate = 115200;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Parity = Parity.None;
            _serialPort.Open();
            _reader = StartCoroutine(Reader());
            isConnected = true;
            return true;
        }
        catch (System.Exception ex)
        {
            isConnected = false;
            Debug.Log(ex.ToString());
            return false;
        }
    }
    public bool Disonnect()
    {
        if (!_serialPort.IsOpen) return true;
        try
        {
            StopCoroutine(_reader);
            _serialPort.Close();
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.ToString());
            return false;
        }
    }

    public string Read(){
        if (!_serialPort.IsOpen) return "0";
        else
        {
            string temp = _serialPort.ReadLine();
            //Debug.Log(temp);
            return temp;
        }
    }

    IEnumerator Reader()
    {
        while (true)
        {
            try
            {
                int temp= int.Parse(Read());
                pedalValue = temp;
            }
            catch(FormatException ex)
            {
            }
            yield return new WaitForSeconds(float.MinValue);
        }
    }
}
