using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class Metodos
    {
        //Validar entrada de datos

        public int ValidarDatos()
        {
            int estrellas;

            Console.WriteLine("Califica nuestra aplicación: ");

            try
            {
                estrellas = int.Parse(Console.ReadLine());

            }catch(FormatException ex)
            {
                Console.WriteLine("Escribiste un valor inválido. Inténtalo de nuevo" + ex);
                estrellas = 0;

                if(estrellas == 0)
                {
                    ValidarDatos();
                }                
            }
            return estrellas;
        }

        //Conteo de palabras positivas
        public int ConteoPalabrasPositivas(HashSet<string> palabrasPositivas, string comentario)
        {
            int positiveWordsCount = 0;

            foreach (string word in palabrasPositivas)
            {
                Regex regex = new Regex("\\b" + word + "\\b", RegexOptions.IgnoreCase);
                positiveWordsCount += regex.Matches(comentario).Count;
            }

            return positiveWordsCount;
        }

        //Conteo de palabras negativas

        public int ConteoPalabrasNegativas(HashSet<string> palabrasNegativas, string comentario)
        {
            int negativeWordsCount = 0;

            foreach (string word in palabrasNegativas)
            {
                Regex regex = new Regex("\\b" + word + "\\b", RegexOptions.IgnoreCase);
                negativeWordsCount += regex.Matches(comentario).Count;
            }

            return negativeWordsCount;
        }

        //Método para evaluar la aplicación
        public int CalificacionUsuario(int estrellas)
        {
            int calificacionPositiva, calificacionNegativa;
            int excepcion = 0;
            try
            {
                if (estrellas >= 3 && estrellas <= 5)
                {
                    Console.WriteLine($"Tu calificación de nuestra aplicación fue de: {estrellas}\n");
                    Console.WriteLine($"El porcentaje es de: {(100) * estrellas/5}%");
                    calificacionPositiva = estrellas;

                    return calificacionPositiva;
                }

                 if (estrellas >= 0 && estrellas <= 2)
                {
                    Console.WriteLine($"Tu calificación de nuestra aplicación fue de: {estrellas}\n");
                    Console.WriteLine($"El porcentaje es de: {(100) * estrellas / 5}%");
                    calificacionNegativa = estrellas;

                    return calificacionNegativa;
                }

                 if (estrellas > 5)
                {
                    Console.WriteLine("Esta calificación no es válida: ");
                    excepcion = 0;

                    return excepcion;
                }

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.WriteLine("Escribe de nuevo la evaluación. ");

                CalificacionUsuario(estrellas);
                excepcion = 0;
            }

            return excepcion;
        }
    }
}
