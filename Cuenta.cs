namespace Teoria5;
class Cuenta{
    private static int proximoID = 1;
    private static int cuentasCreadas = 0;
    private static int cantidadDepositos = 0;
    private static int cantidadExtracciones = 0;
    private static int cantidadExtraccionesDenegadas = 0;
    private static decimal totalDepositado = 0;
    private static decimal totalExtraido = 0;
    private static decimal saldoTotal = 0;
    private int ID;
    private decimal saldo;
    private static List<Cuenta> listaCuentas = new List<Cuenta>();
    // Punto 3)
    public static List<Cuenta> Cuentas {
        get {return new List<Cuenta>(listaCuentas);} // Solo lectura
    }

    public Cuenta (){
        ID = proximoID;
        proximoID++;
        saldo = 0;
        cuentasCreadas++;
        listaCuentas.Add(this);
        Console.WriteLine($"Se creo la cuenta ID = {ID}");
    }

    public Cuenta Depositar (decimal monto){
        saldo += monto;
        saldoTotal += monto;
        totalDepositado += monto;
        cantidadDepositos++;
        Console.WriteLine($"Se deposito {monto} en la cuenta {ID} (Saldo = {saldo})");
        return this;
    }

    public Cuenta Extraer (decimal monto){
        if (saldo >= monto){
            saldo -= monto;
            saldoTotal -= monto;
            totalExtraido += monto;
            cantidadExtracciones++;
            Console.WriteLine($"Se extrajo {monto} en la cuenta {ID} (Saldo = {saldo})");
        }
        else{
            cantidadExtraccionesDenegadas++;
            Console.WriteLine($"Operación denegada - Saldo insuficiente");
        }
        return this;
    }

    public static void ImprimirDetalle(){
        Console.WriteLine($"Cuentas creadas: {cuentasCreadas}");
        Console.WriteLine($"Depositos: {cantidadDepositos}");
        Console.WriteLine($"Extracciones: {cantidadExtracciones}");
        Console.WriteLine($"Total depositado: {totalDepositado}");
        Console.WriteLine($"Total extraido: {totalExtraido}");
        Console.WriteLine($"Saldo: {saldoTotal}");
        if (cantidadExtraccionesDenegadas > 0){
            Console.WriteLine($"Se denegaron {cantidadExtraccionesDenegadas} extracciones por falta de fondos");
        }
    }

    /* Punto 2)
        public static List<Cuenta> GetCuentas(){
        // Devuelve una copia superficial de la lista
        return new List<Cuenta>(listaCuentas);
        // Así, si borrás un elemento de la lista devuelta por GetCuentas(), no se borra del listado interno de la clase.
    }
    */
}