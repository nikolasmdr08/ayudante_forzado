using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeTheAssistant : MonoBehaviour
{
    public int[] ItemArray;
    public float Countdown;
    public ScientistPot_Manager ScientistScript;
    public bool Gamestart;

    public string currentInput = "";
    public int[] inputArray;
    public int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Gamestart = false;
        // Inicializar el array

        Debug.Log("Escribe un n�mero y presiona Enter. Se guardar�n en el array.");

    }

    // Update is called once per frame
    void Update()
    {
        gameplay();
    }

    void gameplay ()
    {
        
        if (ScientistScript.vueltacompleta)
        {

            inputArray = new int[ScientistScript.arraySize];
            currentIndex = 0;
        }
        else
        {
            // Capturar la entrada del teclado
            foreach (char c in Input.inputString)
            {
                if (char.IsDigit(c))
                {
                    // Agregar el d�gito al input actual
                    currentInput += c;
                }
                else if (c == '\n' || c == '\r') // Enter
                {
                    // Convertir y almacenar el n�mero si es v�lido
                    if (int.TryParse(currentInput, out int number))
                    {
                        if (currentIndex < ScientistScript.arraySize)
                        {
                            inputArray[currentIndex] = number;
                            Debug.Log($"N�mero {number} guardado en la posici�n {currentIndex}.");
                            currentIndex++;
                        }
                        else
                        {
                            Debug.Log("El array est� lleno. No se pueden agregar m�s n�meros.");
                        }
                    }
                    else
                    {
                        Debug.Log("Entrada inv�lida. Escribe un n�mero v�lido.");
                    }

                    // Reiniciar el input actual
                    currentInput = "";
                }
            }
        }

    }

}
