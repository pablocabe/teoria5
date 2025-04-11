using Teoria5;
Cuenta.ImprimirResumen();
Cuenta c0 = new Cuenta();
// c0.ImprimirResumen(); // Hay que sacarle el static para que compile porque es una referencia

 Cuenta c1 = new Cuenta();
 Cuenta c2 = new Cuenta();
 c1.Monto = 20;
 Cuenta.Total += c1.Monto;
 c2.Monto = 30;
 Cuenta.Total += c2.Monto;
 Cuenta.ImprimirResumen();