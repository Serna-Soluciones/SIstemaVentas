namespace MSG.SistemaVentas.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}