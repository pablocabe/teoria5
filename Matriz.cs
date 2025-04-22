namespace Teoria5;

class Matriz{

    private int _filas;
    private int _columnas;
    private double[,] _datos;

    public Matriz (int filas, int columnas){
        this._filas = filas;
        this._columnas = columnas;
        this._datos = new double [_filas, _columnas];
    }

    public Matriz(double[,] matriz){
        this._filas = matriz.GetLength(0);
        this._columnas = matriz.GetLength(1);
        this._datos = new double[_filas, _columnas];
        Array.Copy(matriz, _datos, matriz.Length);
    }

    public double this[int fila, int columna]{ // Indizador
        get { return _datos[fila, columna]; }
        set { _datos[fila, columna] = value; }
    }

    public void imprimir(){
        imprimir("{0:F2}"); // {0:F2} -> muestra con 2 decimales el primer elemento (0)
    }

    public void imprimir(string formatString){
        for (int i = 0; i < _filas; i++){
            for (int j = 0; j < _columnas; j++){
                Console.Write(string.Format(formatString + " ", _datos[i, j]));
            }
            Console.WriteLine();
        }
    }

    public double[] GetFila(int fila){

        double[] resultado = new double [_columnas];

        for (int j = 0; j < _columnas ; j++){
            resultado[j] = _datos[fila, j];
        }

        return resultado;
    }

    public double[] GetColumna(int columna){

        double[] resultado = new double [_filas];

        for (int i = 0 ; i < _filas ; i++){
            resultado[i] = _datos[i, columna];
        }

        return resultado;
    }

    // Las diagonales solo existen hasta donde haya filas y columnas.
    // Si tenés una matriz de 3x5, solo hay 3 elementos en la diagonal principal (porque no hay más filas).

    // Propiedad de sólo lectura para obtener la diagonal principal
    public double[] DiagonalPrincipal{
        get{
            int n = Math.Min(_filas, _columnas);
            double[] diagonal = new double[n];
            for (int i = 0; i < n; i++){
                diagonal[i] = _datos[i, i];
            }
            return diagonal;
        }
    }

    // Propiedad de sólo lectura para obtener la diagonal secundaria
    public double[] DiagonalSecundaria{
        get{
            int n = Math.Min(_filas, _columnas);
            double[] diagonal = new double[n];
            for (int i = 0; i < n; i++){
                diagonal[i] = _datos[i, _columnas - i - 1];
            }
            return diagonal;
        }
    }

    public double[][] getArregloDeArreglo(){

        double[][] arregloDeArreglo = new double[_filas][];

        for (int i = 0; i < _filas ; i++){
            arregloDeArreglo[i] = new double[_columnas];
            for (int j = 0; j < _columnas ; j++){
                {
                    arregloDeArreglo[i][j] = _datos[i,j];
                }
            }
        }

        return arregloDeArreglo;
    }

    public void sumarle(Matriz m){
        if (m._filas != _filas || m._columnas != _columnas)
            throw new ArgumentException("Dimensiones incompatibles para la suma");

        for (int i = 0; i < _filas ; i++){
            for (int j = 0; j < _columnas ; j++){
                _datos[i, j] += m._datos[i, j];
            }
        }
    }

    public void restarle(Matriz m){
        if (m._filas != _filas || m._columnas != _columnas)
            throw new ArgumentException("Dimensiones incompatibles para la resta");

        for (int i = 0; i < _filas ; i++){
            for (int j = 0; j < _columnas ; j++){
                _datos[i, j] -= m._datos[i, j];
            }
        }
    }

    public void multiplicarPor(Matriz m){
        if (m._filas != _filas || m._columnas != _columnas)
            throw new ArgumentException("Dimensiones incompatibles para la multiplicacion");

        for (int i = 0; i < _filas ; i++){
            for (int j = 0; j < _columnas ; j++){
                _datos[i, j] *= m._datos[i, j];
            }
        }
    }
}


/*
Modificar la definición de la clase Matriz realizada en la práctica 4. Eliminar los métodos 
SetElemento(...) y GetElemento(...). Definir un indizador adecuado para leer y escribir 
elementos de la matriz. Eliminar los métodos GetDiagonalPrincipal() y 
GetDiagonalSecundaria() reemplazándolos por las propiedades de sólo lectura 
DiagonalPrincipal y DiagonalSecundaria. 
*/