using ENT.Log;
using ENT.pessoa;

namespace BLL.cargo
{
    public interface IBLL_cargo_Log
    {
        MOD_log ValidaLog(MOD_log ent);
        MOD_log CriarLog(MOD_cargo ent, string Operacao);
    }
}