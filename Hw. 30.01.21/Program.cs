using System;


namespace Hw._30._01._21
{
    class Program
    {
        private const string Про_Лицензия = "131";
        private const string Экс_Лицензия = "311";
        static void Main(string[] args)
        {

            //task2
            Console.WriteLine("Текст действий:");


            IRecodable irecord = new Player();
            IPlayable iplay = new Player();
            irecord.Record();
            iplay.Play();
            iplay.Pause();
            iplay.Stop();

            //Task 1

            //Надо вести ключ лицензии
            Console.WriteLine("Введите лицензионный ключ:");
            var license = Console.ReadLine();

            //создания рабочего документа
            DocumentWorker worker;
            switch (license)
            {
                case Про_Лицензия: worker = new ProDocumentWorker(); break;
                case Экс_Лицензия: worker = new ExpertDocumentWorker(); break;
                default: worker = new DocumentWorker(); break;
            }

            //Надо вести команду
            while (true)
            {
                Console.WriteLine("Введите команды  (a/b/c/d): ");
                switch (Console.ReadLine())
                {
                    case "a": worker.OpenDocument(); break;
                    case "b": worker.EditDocument(); break;
                    case "c": worker.SaveDocument(); break;
                    case "d": return;
                }
            }
        }
    }
    //task2
    interface IRecodable
    {
        void Record();
        void Pause();
        void Stop();
    }
    interface IPlayable
    {
        void Play();
        void Pause();
        void Stop();
    }

    class Player : IPlayable, IRecodable
    {
        public void Play()
        {
            Console.WriteLine("Play");
        }

        public void Record()
        {
            Console.WriteLine("Record");
        }
        public void Pause()
        {
            Console.WriteLine("Pause");
        }
        public void Stop()
        {
            Console.WriteLine("Stop");
        }

    }

    //Task1
    class DocumentWorker
    {
        public virtual void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }

        public virtual void EditDocument()
        {
            Console.WriteLine("Редактирование документа доступно в версии Про");
        }

        public virtual void SaveDocument()
        {
            Console.WriteLine("Сохранение документа доступно в версии Про");
        }
    }

    class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }

        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
        }
    }

    class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
    }

}
 