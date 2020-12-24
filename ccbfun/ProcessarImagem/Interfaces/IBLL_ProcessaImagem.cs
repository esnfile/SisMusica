using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BLL.Funcoes
{
    public interface IBLL_ProcessaImagem
    {
        /// <summary>
        /// Função que carrega o Caminho da imagem e Converte em Binário
        /// </summary>
        /// <param name="caminho"></param>
        /// <returns></returns>
        byte[] ConvertImagemEmBinario(string caminho);

        /// <summary>
        /// Função que recebe o Binário e converte em Imagem
        /// </summary>
        /// <param name="imagem"></param>
        /// <returns></returns>
        Bitmap ConvertBinarioEmImagem(byte[] imagem);
    }
}