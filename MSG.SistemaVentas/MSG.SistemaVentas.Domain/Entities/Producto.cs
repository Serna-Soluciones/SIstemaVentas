﻿namespace MSG.SistemaVentas.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}