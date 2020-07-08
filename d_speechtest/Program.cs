using SpeechLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace speechtester
{
    class Program
    {
        static void Main(string[] args)
        {
            SpVoice spv = new SpVoice();
            ISpeechObjectTokens voices;

            ConsoleColor defForeC = Console.ForegroundColor;
            ConsoleColor defBackC = Console.BackgroundColor;

            while (true)
            {
                if (Environment.Is64BitProcess)
                    Console.WriteLine("64-bit process");
                else
                    Console.WriteLine("32-bit process");
                
                voices = spv.GetVoices("", "");
                
                Console.WriteLine("*************************************************");
                
                for (int i = 0; i < voices.Count; i++)
                {
                    var item = voices.Item(i);

                    if (i % 2 == 1)
                    {
                        Console.ForegroundColor = defBackC;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.ForegroundColor = defForeC;
                        Console.BackgroundColor = defBackC;
                    }

                    Console.WriteLine(i + "\t-\t" + item.Id.CutFromLastBackslash(), Console.BackgroundColor);
                }

                Console.ForegroundColor = defForeC;
                Console.BackgroundColor = defBackC;
                Console.WriteLine("*************************************************");

                Console.WriteLine();
                Console.WriteLine("Current selected voice: {0}", spv.Voice.Id.CutFromLastBackslash());
                
                Console.Write("Select nb of voice: ");
                string selectedVoice = Console.ReadLine();
                
                bool parseRes = Int32.TryParse(selectedVoice, out int iSelectedVoice);
                if (parseRes == true && (iSelectedVoice >= 0) && (iSelectedVoice < voices.Count))
                {
                    spv.Voice = voices.Item(iSelectedVoice);
                    Console.WriteLine("Current selected voice: {0}", spv.Voice.Id.CutFromLastBackslash());
                }
                else
                {
                    Console.WriteLine("Parse error.");
                    Console.WriteLine("Current selected voice: {0}", spv.Voice.Id.CutFromLastBackslash());
                }

                System.Threading.Thread.Sleep(200);
                Console.WriteLine();
                Console.WriteLine("Speak: \"Hello\"");
                
                try
                {
                    spv.Speak("Hello",SpeechVoiceSpeakFlags.SVSFlagsAsync);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: \"{0}\"",ex.Message);
                }
                
                Console.Write("Continue? [Y]/[Any other key to exit]: ");

                ConsoleKey contResult = Console.ReadKey().Key;
                if (contResult == ConsoleKey.Y)
                    Console.Clear();
                else
                    return;

            }
        }

       
    }
}
