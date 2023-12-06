using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

/*
 * Разработать класс «Счет для оплаты». В классе предусмотреть следующие
поля:
● оплата за день;
● количество дней;
● штраф за один день задержки оплаты;
● количество дней задержки оплаты;
● сумма к оплате без штрафа (вычисляемое поле);
● штраф (вычисляемое поле);
● общая сумма к оплате (вычисляемое поле).
Вычисляемые поля не сериализуются. Разработать приложение, в котором
необходимо продемонстрировать использование этого класса, результаты
должны записываться и считываться из файла.
 */

// я не до конца понял смысл полей класса, поэтому сделал в меру своего понимания
namespace Program
{
    [Serializable]
    public class InvoicePayment
    {
        private int _numberOfDays;
        private int _numberOfDaysOfPaymentDelay;

        public int NumberOfDays { get { return _numberOfDays; } }
        public int NumberOfDaysOfPaymentDelay { get { return _numberOfDaysOfPaymentDelay; } }

        private double _paymentPerDay;
        private double _penaltyForOneDayOfDelay;

        [NonSerialized] private double _amountToBePaidWithoutPenalty;
        [NonSerialized] private double _penalty;
        [NonSerialized] private double _amount;

        public double PaymentPerDay { get { return _paymentPerDay; } }
        public double PenaltyForOneDayOfDelay { get { return _penaltyForOneDayOfDelay; } }

        public InvoicePayment(int numberOfDays, int numberOfDaysOfPaymentDelay, double paymentPerDay, double penaltyForOneDayOfDelay)
        {
            _numberOfDays = numberOfDays;
            _numberOfDaysOfPaymentDelay = numberOfDaysOfPaymentDelay;
            _paymentPerDay = paymentPerDay;
            _penaltyForOneDayOfDelay = penaltyForOneDayOfDelay;

            Serialize(this);
        }

        public InvoicePayment() : this(1, 2, 1200d, 200d) { }

        public static void Serialize(InvoicePayment invoice)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fstream = new FileStream("Invoice.bin", FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(fstream, invoice);
            }
        }

        public static InvoicePayment Deserialize(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                using (FileStream fstream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    return (InvoicePayment)formatter.Deserialize(fstream);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Чтобы десериализовать данные, нужно сначала их сериализовать");
                return null;
            }
        }

        public double CalcAmountToBePaidWithoutPenalty(double[] prices)
        {

            for (int i = 0; i < prices.Length; i++)
                _amountToBePaidWithoutPenalty += prices[i];

            return _amountToBePaidWithoutPenalty;
        }

        public double CalcPenalty()
        {
            _penalty = _numberOfDaysOfPaymentDelay * _penaltyForOneDayOfDelay;

            return _penalty;
        }

        public double CalcAmount()
        {
            _amount = _amountToBePaidWithoutPenalty + _penalty;

            return _amount;
        }
    }
}
