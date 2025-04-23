using Teoria5;

Auto a = new Auto();
a.Marca = "Ford";
Console.WriteLine($"La marca es {a.Marca}");
Console.WriteLine(a.Marca);

class Auto {

	private string _marca;
	
	public string Marca{
		set{
			_marca = value;
		}
		get{
			return _marca;
		}
	}
}