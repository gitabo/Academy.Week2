using System;
using System.IO;

namespace Academy.Week2.EsercitazioneFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //(@"C:\Users\mauro.abozzi\source\repos\Academy.Week2\Academy.Week2.EsercitazioneFile");
            FileProcess fp = new FileProcess(10);
            fp.FileStart += fp_FileStart;
            fp.FileProgress += fp_FileProgress;
            fp.FileCompleted += fp_FileCompleted;


            fp.RunProcess();
            

        }



        //Event handlers

        private static void fp_FileCompleted(object sender, FileProcess.CountProcessEventArgs e)
        {
            Console.WriteLine($"Numero righe: {e.NumRows} Numero gender: {e.NumRowsGender}");
        }


        private static void fp_FileStart()
        {
            Console.WriteLine("=== Inizio lettura ===");
        }

        private static void fp_FileProgress(int nRows)
        {
            Console.WriteLine($"Lette {nRows} righe");
        }
    }
}
