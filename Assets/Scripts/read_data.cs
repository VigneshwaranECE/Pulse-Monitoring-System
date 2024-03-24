using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class read_data : MonoBehaviour
{
    private const string apiUrl = "https://prayalabs.com/rest/api/heart-beat";

    [System.Serializable]
    private class HeartbeatResponse
    {
        public int pulserate;
        
    }

    private void Start()
    {
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
               

                Debug.Log("Received pulse-value: " + pulseValue);
              
            }
        }
    }
}
