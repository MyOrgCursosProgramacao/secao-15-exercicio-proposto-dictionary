using System;
using System.Collections.Generic;
using System.IO;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====  Seção 15: Exercício proposto dictionary  ====");


            string caminhPastaIo = @"C:\Users\alvar\OneDrive\Workspaces\ws-vs2019\secao-15-exercicio-proposto-dictionary\io\";
            string arquivoInput = @"input.txt";

            FileStream fsInput = null;
            try
            {
                fsInput = new FileStream(caminhPastaIo + arquivoInput, FileMode.Open);

                Dictionary<string, int> candidatos = new Dictionary<string, int>();

                using (StreamReader rsInput = new StreamReader(fsInput))
                {
                    while (!rsInput.EndOfStream)
                    {
                        string[] linha = rsInput.ReadLine().Split(',');
                        if (!candidatos.ContainsKey(linha[0]))
                        {
                            candidatos[linha[0]] = int.Parse(linha[1]);
                        }
                        else
                        {
                           int temp = candidatos[linha[0]];
                           candidatos[linha[0]] = temp + int.Parse(linha[1]);
                        }
                        
                    }
                }

                foreach (KeyValuePair<string, int> candidato in candidatos)
                {
                    Console.WriteLine(candidato.Key +": " + candidato.Value);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                if (fsInput != null) fsInput.Close();
            }
        }
    }
}
