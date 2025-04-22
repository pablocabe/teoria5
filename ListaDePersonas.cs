namespace Teoria5;

class ListaDePersonas{

    private List<Persona> personas = new List<Persona>();

    public void Agregar(Persona p){
        personas.Add(p);
    }

    public Persona this [int dniIndice]{
        get {
            foreach (Persona p in personas){
                if (p.DNI == dniIndice)
                    return p;
            }
            return null; // No se encontró ninguna persona con ese DNI

        // return personas.FirstOrDefault(p => p.DNI == dniIndice); // Más directo
        }
    }

    public List<string> this [char caracter]{
        get {
            List<String> listaNombres = new List<String>();
            foreach (Persona p in personas){
                if (!string.IsNullOrEmpty(p.Nombre) && p.Nombre[0] == caracter){ // (persona.Nombre.Length > 0
                    listaNombres.Add(p.Nombre);
                }
            }
            return listaNombres;
        }
    }

}

/*
Completarla y agregar dos indizadores de sólo lectura
Un índice entero que permite acceder a las personas de la lista por número de documento. Por ejemplo 
p=lista[30456345] devuelve el objeto Persona que tiene DNI=30456345 
o null en caso que no exista en la lista.
Un índice de tipo char que devuelve un List<string> con todos los nombres de las personas de la 
lista que comienzan con el carácter pasado como índice. 
*/