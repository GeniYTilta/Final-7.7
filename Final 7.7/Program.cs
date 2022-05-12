using System;

namespace unit7._7_Final_task
{
    class Program
    {
        static void Main(string[] args)
        {
            MobilePhone mobilePhone = new MobilePhone();
            Console.WriteLine($"Характеристики телефона: {mobilePhone.NameOfProduct()}");

            var casePhone = new CasePhone();
            var caseShop = casePhone.mobilePhone.model;
            Console.WriteLine($"Наименование чехла: {casePhone.ChangeCase(caseShop)}");


        }
    }
    abstract class Delivery
    {
        public string Address;
    }

    abstract class Electronics
    {
        public string manufactur;
        public string model;
        public int productionYear;

        public virtual string NameOfProduct() // переопределенный метод
        {
            return "производитель:" + manufactur + "модель:" + model + "год выпуска:" + productionYear;
        }
        //public abstract void Display(); // абастрактный класс
    }

    class MobilePhone : Electronics
    {
        public int numberSim; // число сим карт
        protected string communicationStandards; // стандарт связи

        public MobilePhone() // конструктор
        {
            manufactur = "Apple";
            model = "XR";
            productionYear = 2021;
            numberSim = 3;
            communicationStandards = "4G";
        }
        public int NumberSim // свойства
        {
            get
            {
                return numberSim;
            }
            set
            {
                if (value < 0 || value > 3)
                {
                    Console.WriteLine("Число сим карт д.б. 1 или 2");
                }
                else numberSim = value;
            }
        }

        public override string NameOfProduct() // переопределенный метод
        {
            return "производитель: " + manufactur + " модель: " + model + " год выпуска: " + productionYear + " число сим карт: " + numberSim + " стандарт связи: " + communicationStandards;
        }
    }

    class CasePhone
    {
        public MobilePhone mobilePhone;
        public CasePhone() // композиция
        {
            mobilePhone = new MobilePhone();
        }
        public string ChangeCase(string model)
        {
            switch (mobilePhone.model)
            {
                case "XR":
                    return "caseModelXR";
                case "XS":
                    return "caseModelXS";
                case "SE":
                    return "caseModelSE";
            }
            return "CaseIndefined";
        }
    }



    class Order<TDelivery, TMobilePhone, TCasePhone>
        where TDelivery : Delivery
        where TMobilePhone : MobilePhone
        where TCasePhone : CasePhone
    {
        public TDelivery Delivery;
        public TMobilePhone MobilePhone;
        public TCasePhone CasePhone;


        public int Number;

        public string Description;

        public void DisplayAddress(TDelivery Delivery)
        {
            Console.WriteLine("Адрес доставки" + Delivery);
        }

        public void DisplayProduct()
        {
            Console.WriteLine("Товар: " + MobilePhone.NameOfProduct());
        }
    }
}
