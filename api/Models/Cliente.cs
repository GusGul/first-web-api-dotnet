namespace first_web_api_dotnet.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; } = default!;
        public string Telefone { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
