namespace ApiPedidos.Services.Requests
{
    /// <summary>
    /// Classe schema de Item
    /// </summary>
    public class ItemSchema
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
