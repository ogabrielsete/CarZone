using CarZone.Data;
using CarZone.Models;

namespace CarZone.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _bancoContext.UsuarioDB.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public Usuario ListarPorId(int id)
        {
            return _bancoContext.UsuarioDB.FirstOrDefault(x => x.Id == id);
        }

        public List<Usuario> GetAll()
        {
            return _bancoContext.UsuarioDB.ToList();
        }

        public Usuario Adicionar(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.UsuarioDB.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public Usuario Atualizar(Usuario attUsuario)
        {
            Usuario usuarioDB = ListarPorId(attUsuario.Id);

            if (usuarioDB == null) throw new Exception("Houve erro na atualização do Usuario");

            usuarioDB.Nome = attUsuario.Nome;
            usuarioDB.Login = attUsuario.Login;
            usuarioDB.Email = attUsuario.Email;
            usuarioDB.Perfil = attUsuario.Perfil;
            usuarioDB.DataCadastro = DateTime.Now;

            _bancoContext.UsuarioDB.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }
        public bool Apagar(int id)
        {
            Usuario usuarioDB = ListarPorId(id);
            if (usuarioDB == null) throw new Exception("Houve erro na exclusão do Usuário");

            _bancoContext.UsuarioDB.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }


    }
}
