using SQLite;

namespace KsWare.Data.SQLitePCL.ConsoleTestApp.net8;

internal class Program {

	static void Main(string[] args) {
		File.Delete("simple.db");
		using var db = new SQLiteConnection("simple.db");
		db.CreateTable<Stock>();
		db.CreateTable<Valuation>();
	}

}

[Table("Stocks")]	 
public class Stock {		
	[PrimaryKey, AutoIncrement]
	[Column("id")]		
	public int Id { get; set; }	

	[Column("symbol")]			
	public string Symbol { get; set; }		
}

[Table("Valuation")]
public class Valuation {

	[PrimaryKey, AutoIncrement]
	[Column("id")]
	public int Id { get; set; }

	[Indexed] [Column("stock_id")] 
	public int StockId { get; set; }

	[Column("time")] 
	public DateTime Time { get; set; }

	[Column("price")] 
	public decimal Price { get; set; }

}
