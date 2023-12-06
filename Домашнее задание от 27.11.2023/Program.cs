using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            InvoicePayment invoice = null;
            if (File.Exists("Invoice.bin"))
                invoice = InvoicePayment.Deserialize("Invoice.bin");

            else
            {
                invoice = new InvoicePayment(10, 5, 1200d, 200d); // создаю и сериализую(в конструкторе) объект класса
                invoice = null;
                invoice = InvoicePayment.Deserialize("Invoice.bin"); // десериализую созданный объект. Сделал так, потому что в задании написано "Информация должна браться из файла"
            }

            double[] prices = { 100d, 115.5d, 200.5d, 1200.5d };
            Console.WriteLine($" Оплата за день: {invoice.PaymentPerDay} рублей");
            Console.WriteLine($" Количество дней: {invoice.NumberOfDays}");
            Console.WriteLine($" Штраф за один день задержки: {invoice.PenaltyForOneDayOfDelay} рублей");
            Console.WriteLine($" Количество дней задержки оплаты: {invoice.NumberOfDaysOfPaymentDelay}");
            Console.WriteLine($" Сумма к оплате без штрафа: {invoice.CalcAmountToBePaidWithoutPenalty(prices)} рублей");
            Console.WriteLine($" Штраф: {invoice.CalcPenalty()} рублей");
            Console.WriteLine($" Сумма к оплате: {invoice.CalcAmount()} рублей");

        }
    }
}