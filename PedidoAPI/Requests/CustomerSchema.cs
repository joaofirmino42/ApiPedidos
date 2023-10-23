namespace ApiPedidos.Services.Requests
{
    /// <summary>
    /// Classe schema de Customer
    /// </summary>
    public class CustomerSchema
    {
        public Guid CustomerId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }
}
