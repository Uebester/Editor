using System;                     // Biblioteca padrão para funcionalidades básicas
using System.Text.RegularExpressions;  // Biblioteca para manipulação avançada de texto usando expressões regulares

namespace EditorHtml               
{
    public class Viewer            // Declara a classe 'Viewer', responsável por exibir o conteúdo digitado
    {
        // Método que exibe o modo de visualização
        public static void Show(string text)
        {
            Console.Clear();                         // Limpa a tela do console
            Console.BackgroundColor = ConsoleColor.White; 
            Console.ForegroundColor = ConsoleColor.Black; 
            Console.Clear();                         // Limpa a tela para aplicar as cores

            Console.WriteLine("MODO VISUALIZAÇÃO");   // Cabeçalho indicando o modo de visualização
            Console.WriteLine("-----------");

            Replace(text);                           // Chama o método que trata e exibe o texto

            Console.WriteLine("-----------");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");

            Console.ReadKey();                       
            Menu.Show();                             
        }

        // Método que processa e destaca partes específicas do texto (tags <strong>)
        public static void Replace(string text)
        {
            // Expressão regular que identifica textos dentro da tag <strong> (aceita letras maiúsculas e minúsculas)
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>", RegexOptions.IgnoreCase);

            // Divide o texto em palavras separadas por espaços
            var words = text.Split(' ');

            // Percorre cada palavra do texto
            for (var i = 0; i < words.Length; i++)
            {
                // Verifica se a palavra atual corresponde ao padrão da tag <strong>
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue; // Define a cor azul para destacar o texto em <strong>

                    // Extrai apenas o conteúdo dentro da tag <strong>
                    Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1,  // Localiza o primeiro '>'
                            (
                                words[i].LastIndexOf('<') - // Localiza o primeiro '<' de fechamento
                                 words[i].IndexOf('>') - 1  // Calcula o tamanho correto do conteúdo interno
                            )
                        )
                    );

                    Console.Write(" "); // Adiciona um espaço para manter a formatação do texto
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black; 
                    Console.Write(words[i]); 
                    Console.Write(" "); 
                }
            }
        }
    }
}
