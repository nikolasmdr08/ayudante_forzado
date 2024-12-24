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

        Debug.Log("Escribe un número y presiona Enter. Se guardarán en el array.");

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
                    // Agregar el dígito al input actual
                    currentInput += c;
                }
                else if (c == '\n' || c == '\r') // Enter
                {
                    // Convertir y almacenar el número si es válido
                    if (int.TryParse(currentInput, out int number))
                    {
                        if (currentIndex < ScientistScript.arraySize)
                        {
                            inputArray[currentIndex] = number;
                            Debug.Log($"Número {number} guardado en la posición {currentIndex}.");
                            currentIndex++;
                        }
                        else
                        {
                            Debug.Log("El array está lleno. No se pueden agregar más números.");
                        }
                    }
                    else
                    {
                        Debug.Log("Entrada inválida. Escribe un número válido.");
                    }

                    // Reiniciar el input actual
                    currentInput = "";
                }
            }
        }

    }

}
