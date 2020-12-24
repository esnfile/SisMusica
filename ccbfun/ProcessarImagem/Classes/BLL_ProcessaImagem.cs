using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace BLL.Funcoes
{
    public class BLL_ProcessaImagem : IBLL_ProcessaImagem
    {

        /// <summary>
        /// Função que carrega a Imagem e Converte em Binário
        /// </summary>
        /// <param name="caminhoFoto"></param>
        /// <returns></returns>
        public byte[] ConvertImagemEmBinario(string caminhoFoto)
        {
            try
            {
                FileStream fs = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                byte[] foto = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

                return foto;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que recebe o Binário e converte em Imagem
        /// </summary>
        /// <param name="imagem"></param>
        /// <returns></returns>
        public Bitmap ConvertBinarioEmImagem(byte[] imagem)
        {
            byte[] bits = imagem;
            MemoryStream memorybits = new MemoryStream(bits);
            Bitmap bit = new Bitmap(memorybits);
            return bit;
        }
    }
}