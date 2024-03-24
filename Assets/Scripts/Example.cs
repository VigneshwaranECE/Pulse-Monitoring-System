using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class Example : MonoBehaviour
{
    public Animator m_Animator;
    //Value from the slider, and it converts to speed level
    public int speed_val;
    public TMP_Text my_Text;
    public TMP_Text my1_Text;
    private const string apiUrl = "https://prayalabs.com/rest/api/heart-beat";

    [System.Serializable]
    private class HeartbeatResponse
    {
        public int pulserate;

    }

    void Start()
    {
        m_Animator.speed = speed_val;
        my_Text.text = "BP";
        my1_Text.text = "REMEDIES";
        //Get the animator, attached to the GameObject you are intending to animate.
        InvokeRepeating("data_parse", 1, 10);

    }
    void data_parse()
    {
        StartCoroutine(SendRequest());

    }

    private IEnumerator SendRequest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                // Parse the JSON response
                HeartbeatResponse response = JsonUtility.FromJson<HeartbeatResponse>(webRequest.downloadHandler.text);
                int pulseValue = response.pulserate;
                

                if(pulseValue > 0)
                {
                    m_Animator.speed = 1;
                    my_Text.text = pulseValue.ToString();
                    my1_Text.text = "Normal Pulse Rate";
                }
                else
                {
                    m_Animator.speed = 0;
                    my_Text.text = "Unable to Process";
                    my1_Text.text = "Unable to Process";
                }
                Debug.Log("Received pulse-value: " + pulseValue);

            }
        }
    }

  /*  void Update()
    {
        m_Animator.speed = speed_val;
        InvokeRepeating("Heart_Beat", 2.0f, 0.3f);
    }
    void Heart_Beat()
    {
        if(m_Animator.speed == 1)
        {
            my_Text.text = "Normal BP";
            my1_Text.text = "Engage in physical exercise everyday";
        }
        if (m_Animator.speed == 2)
        {
            my_Text.text = "High BP";
            my1_Text.text = "Stay calm & take a deep breath";
        }

    }*/

}