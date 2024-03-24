using UnityEngine;

public class ArObjectcontroller : MonoBehaviour
{
    public GameObject[] objectToControl;

    bool flag;

    private void Start()
    {
        flag = false;
        for (int i = 0; i < objectToControl.Length; i++)
        {
            objectToControl[i].SetActive(false);
        }
    }
    public void SetActiveTrue()
    {
        if (!flag)
        {
            flag = true;
            for (int i = 0; i < objectToControl.Length; i++)
            {
                objectToControl[i].SetActive(true);
            }
            Debug.Log(flag);

        }
        else if(flag) 
        {
            flag = false;
            for (int i = 0; i < objectToControl.Length; i++)
            {
                objectToControl[i].SetActive(false);
            }
            Debug.Log(flag);

        }

        
    }
    /*
    public void SetActiveFalse()
    {
        if (!flag)
        {
            flag = false;
            for (int i = 0; i < objectToControl.Length; i++)
            {
                objectToControl[i].SetActive(true);
            }
        }
        
    }
    */
}
