namespace Solution.Infrastructure.DataAccessObject
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context) { }
    }
}
