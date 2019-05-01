using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sendtogooglesheet : MonoBehaviour
{
    public GameObject ID;
    public GameObject FullName;
    public GameObject Message;

    private string Id;
    private string Fullname;
    private string message;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSfQJo2t7T4QJYUyvFoCR04Ii0vv7BjKbZFyavunETd-qfbbEA/formResponse";

    IEnumerator Post(string id, string fullname, string message)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1126845662", id);
        form.AddField("entry.420563437", fullname);
        form.AddField("entry.700822663", message);

        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www; 

    }

    public void save()
    {
        Id = ID.GetComponent<InputField>().text;
        Fullname = FullName.GetComponent<InputField>().text;
        message = Message.GetComponent<InputField>().text;

        StartCoroutine(Post(Id, Fullname, message));
    }
}
