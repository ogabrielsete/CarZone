namespace CarZone.Helper
{
    public interface IEmail
    {
        public bool Enviar(string email, string assunto, string msg);
        
    }
}
