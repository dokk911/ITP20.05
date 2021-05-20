using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console20._05Dz
{
    class Fish
    {
        private int _age;
        private bool _isDead;

        public Fish()
        {
            _age = 0;
            _isDead = false;
        }

        public void ShowInfo(int number)
        {
            if (_isDead == true)
                Console.WriteLine($"{number} рыба - умерла");
            else
                Console.WriteLine($"{number} рыба - {_age} год");

        }

        public void Aging()
        {
            if (_isDead == false)
            {
                _age++;

                if (_age > 4)
                    _isDead = true;
            }
        }
    }

    class Aquarium
    {
        private int _minFish;
        private int _maxFish;
        private List<Fish> _fishes;

        public Aquarium(List<Fish> fishes)
        {
            _minFish = 0;
            _maxFish = 10;
            _fishes = fishes;
        }

        public void AddFish()
        {
            if (_fishes.Count <= _maxFish)
                _fishes.Add(new Fish());
            else
                Console.WriteLine("Нельзя добавить рыбу!");
        }

        public void RemoveFish(int number)
        {
            if (_fishes.Count > _minFish)
                _fishes.RemoveAt(number);
            else
                Console.WriteLine("Нельзя убрать рыбу!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Fish> fishes = new List<Fish>();
            Aquarium aquarium = new Aquarium(fishes);

            int answer = 0;
            int number = 0;
            bool isExit = false;

            while (isExit == false)
            {
                Console.Write("1)Добавить; 2)Убрать; 3)Показать; 4)Выйти: ");
                answer = int.Parse(Console.ReadLine());
                Console.Clear();

                for (int i = 0; i < fishes.Count; i++)
                    fishes[i].Aging();

                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Рыба добавлена!");
                        aquarium.AddFish();
                        break;
                    case 2:
                        for (int i = 0; i < fishes.Count; i++)
                            fishes[i].ShowInfo(i + 1);

                        Console.WriteLine();
                        Console.Write("Введите номер рыбки: ");
                        number = int.Parse(Console.ReadLine()) - 1;
                        aquarium.RemoveFish(number);
                        break;
                    case 3:
                        for (int i = 0; i < fishes.Count; i++)
                            fishes[i].ShowInfo(i + 1);
                        break;
                    case 4:
                        isExit = true;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
