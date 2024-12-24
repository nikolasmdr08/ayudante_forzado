using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEditor;

public class ScientistPot_Manager : MonoBehaviour
{
    public int arraySize;
    public int[] myarray;
    public float timmer;
    public bool vueltacompleta;
    public MeTheAssistant AssistantScript;
    public bool win;
    // Start is called before the first frame update
    void Start()
    {
        timmer = 0;
        arraySize = 4;
        vueltacompleta = true;
        win = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (vueltacompleta)
        {

            myarray = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                myarray[i] = Random.Range(1, 6);
                print(myarray[i]);
            }
            timmer = 10f;
            vueltacompleta = false;

        }
        else
        {
            if (timmer <= 0)
            {
                for (int i = 0; i < arraySize; i++)
                {
                    if (AssistantScript.inputArray[i] != myarray[i])
                    {
                        win = false;
                    }
                }
                if (win)
                {
                    print("Bien");
                }
                else
                {
                    print("Mal");
                }
                arraySize++;
                vueltacompleta = true;
                win = true;
            }
            else
            {
                timmer -= Time.deltaTime;
            }

        }



    }


}
