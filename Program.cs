using System.IO;
using System.Diagnostics;
using System;

namespace EditorTextos
{
    class Program{
        public static void Main(string[] args)
        {
            Menu();
        }

        static void Menu(){
            Console.Clear();
            System.Console.WriteLine("Saudações, o que deseja fazer?");
            System.Console.WriteLine(" 1 - Abrir arquivo \r\n 2 - Criar novo arquivo\r\n 0 - Sair");
            short option = short.Parse(Console.ReadLine());
            Thread.Sleep(1000);

            switch(option){
                case 1 : Abrir();break;
                case 2 : Novo();break;
                case 0 : Bye();break;
                default:  
                System.Console.WriteLine("Opção digitada invalida.");
                Thread.Sleep(1000);
                Menu();break;
            }
        }

        private static void Bye()
        {
            System.Console.WriteLine("Obrigado pela visita, até a proxima.");
            Thread.Sleep(3000);
            System.Environment.Exit(0);
        }

        private static void Novo()
        {
            Console.Clear();
            System.Console.WriteLine("Digite seu texto abaixo:");
            System.Console.WriteLine("------------------------------");
            string texto = "";

            do{
                texto += Console.ReadLine();  
                texto += Environment.NewLine;  
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);

            System.Console.Write(texto);
            Salvar(texto);
            
        }

        private static void Abrir()
        {
           System.Console.WriteLine("Qual o caminho e nome do arquivo desejado?");
           var path = Console.ReadLine();
           using(var file = new StreamReader(path)){
                string texto = file.ReadToEnd();
                System.Console.WriteLine(texto);
           }

           System.Console.WriteLine("");
           Console.ReadLine();
           Menu();
        }

        private static void Salvar(string text){
            System.Console.WriteLine("Qual o caminho para salvar?");
            var path =  Console.ReadLine();
            using (var file = new StreamWriter(path)){
                file.Write(text);
            }

            Console.WriteLine($"Arquivo foi salvo com sucesso nesse endereço {path}!");
            Thread.Sleep(3000);
            Menu();
        }
    }
}
