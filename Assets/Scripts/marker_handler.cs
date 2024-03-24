using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marker_handler : MonoBehaviour
{
    public GameObject[] content;
    public void show_content()
    {
        for(int i = 0; i < content.Length; i++)
        {
            content[i].SetActive(true);
            content[i].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
       
    }
    public void hide_content()
    {
        for (int i = 0; i < content.Length; i++)
        {
            content[i].SetActive(false);
        }
    }
}
