namespace MSG.SistemaVentas.Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public DateOnly SaleDate { get; set; }
        public  decimal Amount { get; set; }
    }
}