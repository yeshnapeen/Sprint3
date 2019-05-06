using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;



public class annotations : MonoBehaviour {


    public Vector3 vector;
    public Text text;

    public void constr(Vector3 vect, Text tex)
    {
        vector = vect;
        text = tex;
    }

    public ArrayList saveList(float vectx, float vecty, float vectz,string text,string time)
    {
        ArrayList al = new ArrayList();
        StringBuilder csvcontent = new StringBuilder();

        if (text != "")
        {
            string strin1 = vectx.ToString();
            string strin2 = vecty.ToString();
            string vectorstring = text + "," + strin1 + "," + strin2 + "," + time + "\r\n";
            al.Add(vectorstring);
            csvcontent.AppendLine(vectorstring);
            string csvpath = "file.csv";
            File.AppendAllText(csvpath, vectorstring);
        }


        return al;


    }







    public GameObject TextPrabs;
    public InputField text_input;

    Vector3 tempos;


    // Use this for initialization
    void Start()
    {

        //tempos = Textpr.transform.position;
        Instantiate(TextPrabs);
    }

    // Update is called once per frame
    void Update()
    {
      

        ArrayList al = new ArrayList();
        string time = "";
        if (Input.GetMouseButtonDown(0))
        {
           
            print("the left mouse button was pressed");
            Vector3 mousepos = Input.mousePosition;
            Debug.Log(mousepos.x);
            Debug.Log(mousepos.y);
            Vector3 temp = new Vector3(mousepos.x, mousepos.y, mousepos.z);
            Debug.Log(temp);
            TextPrabs.transform.position = new Vector3(mousepos.x, mousepos.y, mousepos.z);

           // Debug.Log(Textpr.transform.position);
            Instantiate(TextPrabs);
            time = DateTime.UtcNow.ToString("HH:mm dd MMMM, yyyy");
            al = saveList(mousepos.x,mousepos.y,mousepos.z,text_input.text,time);


        }

        if (Input.GetMouseButtonDown(1))
        {
            print("the right mouse button was pressed");
            Vector3 mousepos = Input.mousePosition;
            Debug.Log(mousepos.x);
            Debug.Log(mousepos.y);
            Vector3 temp = new Vector3(mousepos.x, mousepos.y, mousepos.z);
            Debug.Log(temp);
            TextPrabs.transform.position = new Vector3(mousepos.x, mousepos.y, mousepos.z);
            float vect1 = mousepos.x;
            float vect2 = mousepos.y;
            float vect3 = mousepos.z;
            // Debug.Log(Textpr.transform.position);
            Instantiate(TextPrabs);
            time = DateTime.UtcNow.ToString("HH:mm dd MMMM, yyyy");
            al = saveList(mousepos.x, mousepos.y, mousepos.z, text_input.text, time);

        }
    }




}
