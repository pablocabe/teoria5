namespace Teoria5;

class Persona{
    public string Nombre {get; set;}
    public char Sexo {get; set;}
    public int DNI {get; set;}
    public DateTime FechaNacimiento {get; set;}
    public int Edad {
        get {
            var hoy = DateTime.Today;
            var edad = hoy.Year - FechaNacimiento.Year;
            if (FechaNacimiento.Date > hoy.AddYears(-edad)){
                edad--;
            }
            return edad;
        }
    }

    public object this[int index]{
        get {
            return index switch{
                0 => Nombre,
                1 => Sexo,
                2 => DNI,
                3 => FechaNacimiento,
                4 => Edad,
                _ => throw new IndexOutOfRangeException("Índice inválido. Solo se permiten índices del 0 al 4.")
            };
        }

        set {
            switch (index){
                case 0:
                    Nombre = Convert.ToString(value);
                    break;
                case 1:
                    Sexo = Convert.ToChar(value);
                    break;
                case 2:
                    DNI = Convert.ToInt32(value);
                    break;
                case 3:
                    FechaNacimiento = Convert.ToDateTime(value);
                    break;
                case 4:
                    // Ignora el valor asignado a Edad porque es de solo lectura
                    break;
                default:
                    throw new IndexOutOfRangeException("Índice inválido. Solo se permiten índices del 0 al 4.");
            }
        }

    }
}

/*
Definir la clase Persona con las siguientes propiedades de lectura y escritura: Nombre de tipo 
string, Sexo de tipo char, DNI de tipo int, y FechaNacimiento de tipo DateTime. Además 
definir una propiedad de sólo lectura (calculada) Edad de tipo int. Definir un indizador de 
lectura/escritura que permita acceder a las propiedades a través de un índice entero. Así, si p es un 
objeto Persona, con p[0] se accede al nombre, p[1] al sexo p[2] al DNI, p[3] a la fecha de 
nacimiento y p[4] a la edad. En caso de asignar p[4] simplemente el valor es descartado. Observar 
que el tipo del indizador debe ser capaz almacenar valores de tipo int, char, DateTime y string.
*/