using System;         // Biblioteca padrão para funcionalidades básicas do C#
using System.Text;    // Biblioteca para manipular textos usando StringBuilder (eficiente para manipular textos grandes)

namespace EditorHtml   
{
    public static class Editor // Classe estática 'Editor', responsável pelo modo de edição
    {
        // Método que exibe o modo Editor
        public static void Show()
        {
            Console.Clear();                          
            Console.BackgroundColor = ConsoleColor.White;  
            Console.ForegroundColor = ConsoleColor.Black;  
            Console.Clear();                         
            Console.WriteLine("MODO EDITOR");          
            Console.WriteLine("----------------------");
            Start();                                 
        }

        // Método que permite o usuário digitar o conteúdo do arquivo
        public static void Start()
        {
            var file = new StringBuilder();  // Cria um objeto StringBuilder para armazenar o texto digitado

            // Loop para capturar o texto digitado até que a tecla "Esc" seja pressionada
            do
            {
                file.Append(Console.ReadLine());       // Lê uma linha de texto e adiciona ao StringBuilder
                file.Append(Environment.NewLine);      // Adiciona uma quebra de linha após cada entrada
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape); // Continua até que a tecla 'Esc' seja pressionada

            // Exibe uma mensagem após sair do modo de edição
            // Envia o texto digitado para o modo visualização

           Salvar(file.ToString());
        }

        public static void Salvar(string text){
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o arquivo?");

            var path = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(path)){
                Console.WriteLine("Caminho inválido! opração cancelada");

            }

            using (var fiile = new StreamWriter(path)){
                fiile.Write(text);
            }

            Console.WriteLine($"Arquivo {path} Salvo com sucesso!");
    
            Console.WriteLine("-------------------");
            Console.WriteLine(" Deseja visualizar o arquivo?");
              
              
            Console.ReadKey();
            Menu.Show();
        }

        public static void Abrir(){
            Console.Clear();
            Console.WriteLine("Qual o Caminho do arquivo?");
            string path = Console.ReadLine();

            if (!File.Exists(path)){
                Console.WriteLine("Caminho inválido! Operação cancelada.");
                Console.ReadKey();
                Menu.Show();
                return;
            }

            var text = File.ReadAllText(path);
            Viewer.Show(text);

           
        }
    }
}
