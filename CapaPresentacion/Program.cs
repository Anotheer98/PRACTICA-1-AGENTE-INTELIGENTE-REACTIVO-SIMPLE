using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CapaDatos;
using CapaNegocio;

namespace CapaPresentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PalabrasP_N palabras = new PalabrasP_N();
            Metodos metodos = new Metodos();
            string[] wordsPositive = palabras.GetWordsPositive();
            string[] wordsNegative = palabras.GetWordsNegative();

            string comentario = null;
            int evaluacion, estrellas = 0;

            //Contador de palabras positivas y negativas
            int positiveWordsCount = 0;
            int negativeWordsCount = 0;

            //Escribir comentario de la aplicación
            Console.WriteLine("Escribe un comentario acerca de nuestra aplicación: ");
            comentario = Console.ReadLine();

            //Calificar aplicación
            estrellas = metodos.ValidarDatos();

            HashSet<string> positive = new HashSet<string>(wordsPositive.Distinct(), StringComparer.OrdinalIgnoreCase);
            HashSet<string> negative = new HashSet<string>(wordsNegative.Distinct(), StringComparer.OrdinalIgnoreCase);

            //Métodos para contar palabras positivas y negativas

            positiveWordsCount = metodos.ConteoPalabrasPositivas(positive, comentario);
            negativeWordsCount = metodos.ConteoPalabrasNegativas(negative, comentario);

            //Llamado a la función para calificar aplicación
            evaluacion = metodos.CalificacionUsuario(estrellas);

            //Comparación de comentarios positivos y negativos
            if (positiveWordsCount > negativeWordsCount)
            {
                if (evaluacion >= 3 && evaluacion <= 5)
                {
                    Console.WriteLine("El comentario es positivo");
                }
            }

            if (negativeWordsCount > positiveWordsCount)
            {
                if (evaluacion >= 3 && evaluacion <= 5)
                {
                    Console.WriteLine("Tu comentario fue negativo, pero tu evaluación fue positiva.\n");
                    Console.WriteLine("El comentario es negativo");

                }
            }

            if (positiveWordsCount > negativeWordsCount)
            {
                if (evaluacion >= 0 && evaluacion < 3)
                {
                    Console.WriteLine("Tu comentario es positivo, pero la evaluacion que nos diste es negativa.");
                    Console.WriteLine("El comentario es positivo.");
                }
            }

            Console.WriteLine($"El número de palabras positivas es: {positiveWordsCount}\n");
            Console.WriteLine($"El número de palabras negativas es: {negativeWordsCount}\n");

            //Mostrar hora
            DateTime actual = DateTime.Now;
            Console.WriteLine($"La fecha y hora en que se escribió el comentario es: {actual}");
            
            Console.ReadKey();
        }                
    }   
}
