using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.EsercitazioneFile
{
    public delegate void FileStartEvent();
    public delegate void FileProgressEvent(int nRows);
    public class FileProcess
    {
        public event FileStartEvent FileStart;
        public event FileProgressEvent FileProgress;
        public event EventHandler<CountProcessEventArgs> FileCompleted;


        public int n { get; set; }

        public FileProcess(int num)
        {
            n = num;
        }

        public void RunProcess() 
        {
            using StreamReader reader = File.OpenText(@"C:\Users\mauro.abozzi\source\repos\Academy.Week2\Academy.Week2.EsercitazioneFile\employees.csv");
            if (FileStart != null)
                FileStart();
            string line = reader.ReadLine();

            int countGender = 0;
            int count = 0;

            //Lettura righe
            while ((line = reader.ReadLine()) != null)
            {
                string[] lineSplit = line.Split(",");
                string gender = lineSplit[4];

                if(!gender.ToUpper().Equals("MALE") && !gender.ToUpper().Equals("FEMALE")) 
                    countGender++;
                count++;
                    
                if (count % n == 0)
                    if (FileProgress != null)
                        FileProgress(count);
            }

            if (FileCompleted != null)
                FileCompleted(
                    this,
                    new CountProcessEventArgs
                    {
                        NumRows = count,
                        NumRowsGender = countGender
                    }
                );

         
        }

        public class CountProcessEventArgs : EventArgs
        {
            public int NumRows { get; set; }

            public int NumRowsGender { get; set; }
        }
    }
}
