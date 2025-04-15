using System;                 // Importa a biblioteca padrão para funcionalidades básicas do C#
using System.Diagnostics;     // Importa a biblioteca que permite interagir com processos do sistema operacional

namespace EditorHtml           
{
    public static class Menu   // Declara uma classe estática chamada 'Menu', usada para gerenciar o menu principal
    {
        // Método que exibe o menu principal
        public static void Show()
        {
            Console.Clear();                      
            Console.BackgroundColor = ConsoleColor.Red;   
            Console.ForegroundColor = ConsoleColor.Blue;   

            DrawScreen();     // Chama o método que desenha a interface gráfica
            WriteOptions();   // Chama o método que exibe as opções disponíveis

            // Captura a opção digitada pelo usuário e converte para 'short' (um tipo de número inteiro pequeno)
            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option); // Chama o método que trata a opção escolhida
        }

        // Método que desenha o layout visual do menu (borda superior, inferior e laterais)
        public static void DrawScreen()
        {
            Console.Write("+");                     // Desenha o canto superior esquerdo
            for (int i = 0; i < 30; i++)            // Desenha a linha superior horizontal com 30 traços
                Console.Write("-");

            Console.Write("+");                     // Desenha o canto superior direito
            Console.Write("\n");                    // Pula para a linha de baixo

            for (int lines = 0; lines <= 10; lines++)  // Cria 10 linhas de "caixa"
            {
                Console.Write("|");                 // Borda lateral esquerda
                for (int i = 0; i < 30; i++)        // Espaços internos para manter o formato da caixa
                    Console.Write(" ");

                Console.Write("|");                 // Borda lateral direita
                Console.Write("\n");                // Pula para a próxima linha
            }

            Console.Write("+");                     // Desenha o canto inferior esquerdo
            for (int i = 0; i < 30; i++)            // Linha inferior horizontal com 30 traços
                Console.Write("-");

            Console.Write("+");                     // Desenha o canto inferior direito
            Console.Write("\n");                    // Pula para a próxima linha
        }

        // Método que exibe as opções disponíveis dentro do menu
        public static void WriteOptions()
        {
            Console.SetCursorPosition(3, 2);        // Define a posição do cursor para melhor alinhamento do texto
            Console.WriteLine("Editor HTML");      

            Console.SetCursorPosition(3, 3);
            Console.WriteLine("============");  

            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Selecione uma opção abaixo");

            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Novo arquivo");  

            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Abrir");          

            Console.SetCursorPosition(3, 9);
            Console.WriteLine("0 - Sair");           

            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");              
        }

        // Método que trata a opção escolhida pelo usuário
        public static void HandleMenuOption(short option)
        {
            
            switch (option)
            {
                case 1: 
                    Editor.Show();                 
                    break;

                case 2: 
                    Editor.Abrir();      
                    break;

                case 0:                           
                    Console.Clear();               
                    Environment.Exit(0);         
                    break;

                default: 
                    Show();                        
                    break;
            }
        }
    }
}
