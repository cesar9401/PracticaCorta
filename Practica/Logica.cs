using System;
using System.Collections.Generic;

namespace Practica
{
    public class Logica
    {
        private String oracion;
        private String[] partes;
        private const char SPACE = ' ';
        private const char POINT = '.';
        private const String MONEDA = "Q";

        private String palabras = "Palabras: ";
        private String numeros = "Numeros: ";
        private String decimales = "Decimales: ";
        private String monedas = "Monedas: ";
        private String errores = "Errores: ";


        public void setOracion(String oracion)
        {
            this.oracion = oracion;
            partes = this.oracion.Split(SPACE);
            descomponerOracion();
        }

        //Descomponer en tokens
        public void descomponerOracion()
        {
            for (int i = 0; i < partes.Length; i++)
            {
                if (isWord(partes[i]))
                {
                    palabras += partes[i] + ", ";
                }
                else if (isNumber(partes[i]))
                {
                    numeros += partes[i] + ", ";
                }
                else if (isDecimal(partes[i]))
                {
                    decimales += partes[i] + ", ";
                }
                else if (isMoneda(partes[i]))
                {
                    monedas += partes[i] + ", ";
                }
                else 
                {
                    errores += partes[i] + ", ";
                }
            }
        }

        //Para determinar si es una palabra
        public Boolean isWord(String cadena)
        {
            int contador = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                char ch = cadena[i];
                int codigo = (int)ch;

                //Letras mayusculas y minusculas, ñ mayuscula y minuscula
                if (codigo >= 65 && codigo <= 90 || codigo >= 97 && codigo <= 122 || codigo == 209 || codigo == 241)
                {
                    contador++;
                }
            }

            return contador == cadena.Length;
        }

        //Para verificar si es un numero
        public Boolean isNumber(String cadena)
        {
            int contador = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                char ch = cadena[i];
                int codigo = (int)ch;
                //Numeros 0 - 9
                if (codigo >= 48 && codigo <= 57)
                {
                    contador++;
                }
            }

            return contador == cadena.Length;
        }

        //Para verificar si es un decimal
        public Boolean isDecimal(String cadena)
        {
            if (cadena.Contains("."))
            {
                string[] part = cadena.Split(POINT);
                if (part.Length == 2)
                {
                    if (isNumber(part[0]) && isNumber(part[1]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Para verifcar si es una moneda Q
        public Boolean isMoneda(String cadena)
        {
            if (cadena.StartsWith(MONEDA))
            {
                String subCadena = cadena.Remove(0, 1);
                if (isNumber(subCadena) || isDecimal(subCadena))
                {
                    return true;
                }
            }
            return false;
        }

        public String Palabras()
        {
            return palabras;
        }
        public String Numeros()
        {
            return numeros;
        }
        public String Decimales()
        {
            return decimales;
        }

        public String Monedas()
        {
            return monedas;
        }
        public String Errores()
        {
            return errores;
        }
    }
}
