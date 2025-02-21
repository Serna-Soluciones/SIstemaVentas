namespace MSG.SistemaVentas.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
    }

    public class Venta
    {
        public int Id { get; set; }
        public DateOnly SaleDate { get; set; }
        public  decimal Amount { get; set; }
    }
}