﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
using System.IO;
using System.Text;

public class socket2 : MonoBehaviour
{
	// internal Boolean socketReady = false;
     
 //     TcpClient mySocket;
 //     NetworkStream theStream;
 //     StreamWriter theWriter;
 //     StreamReader theReader;
 //     String Host = "localhost";
 //     Int32 Port = 5679;
     
 //     void Start () {
 //         setupSocket();
 //         writeSocket("Hello");
 //     }
 //     void Update () {
 //     }
 
 //     void OnApplicationQuit()
 //     {
 //         try
 //         {
 //             closeSocket();
 //         }
 //         catch(Exception e)
 //         {
 //             Debug.Log(e.Message);
 //         }
 //     }
 //     // **********************************************
 //     public void setupSocket() {
 //         try {
 //             mySocket = new TcpClient(Host, Port);
 //             theStream = mySocket.GetStream();
 //             theWriter = new StreamWriter(theStream);
 //             theReader = new StreamReader(theStream);
 //             socketReady = true;
 //         }
 //         catch (Exception e) {
 //             Debug.Log("Socket error: " + e);
 //         }
 //     }
 
 //     public void writeSocket(string theLine) {
 //         if (!socketReady)
 //             return;
 //         String foo = theLine + "\r\n";
 //         theWriter.Write(foo);
 //         theWriter.Flush();
 //     }
 //     public String readSocket() {
 //         if (!socketReady)
 //             return "";
 //         if (theStream.DataAvailable)
 //             return theReader.ReadLine();
 //         return "";
 //     }
 //     public void closeSocket() {
 //         if (!socketReady)
 //             return;
 //         theWriter.Close();
 //         theReader.Close();
 //         mySocket.Close();
 //         socketReady = false;
 //     }
	// Use this for initialization
    internal Boolean socketReady = false;
    TcpClient mySocket;
    NetworkStream theStream;
    StreamWriter theWriter;
    StreamReader theReader;
    String Host = "localhost";
    Int32 Port = 5679;
    String msg;

    // Start is called before the first frame update
    void Start()
    {
    	setupSocket ();
        Debug.Log ("socket is set up");
    }

    // Update is called once per frame
    void Update()
    {
    	msg = readSocket();
    	print(msg);  
    }

    public void setupSocket() {
        try {
            mySocket = new TcpClient(Host, Port);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            theStream.ReadTimeout = 1;
            socketReady = true;
            Byte[] sendBytes = System.Text.Encoding.UTF8.GetBytes("yah!! it works");
			mySocket.GetStream().Write(sendBytes, 0, sendBytes.Length);
            Debug.Log ("socket is sent");
        }
        catch (Exception e) {
            Debug.Log("Socket error: " + e);
        }
    }

    public String readSocket() {
    	if (!socketReady)
        	return "";
    	try {
    		Debug.Log("success?");
        	return theReader.ReadLine();
        	
    	} 
    	catch (Exception e) {
        	return "";
    	}
 	}

 	public void closeSocket() {
    	if (!socketReady)
        	return;
     	theWriter.Close();
     	theReader.Close();
     	mySocket.Close();
     	socketReady = false;
	}


}
