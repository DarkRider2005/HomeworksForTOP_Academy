using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    /*
     Создайте класс Fraction для описания дроби. У неё должны быть
свойства для числителя и знаменателя, открытые только для чтения. Добавьте
проверку, что числитель никогда не должен становится равен 0. Напишите
для этого класса перегрузку инкремента и декремента (изменяет числитель на
числитель * знаменатель), оператора отрицания (меняет знак числителя), а
также перегрузку true и false (класс равен false, если числитель равен 0).
     */
    public class Fraction
    {
        public int Numerator { get { return _numerator; } }
        public int Denominator { get { return _denominator; } }
        private int _numerator;
        private int _denominator;

        public Fraction(int numerator, int denominator)
        {
            _numerator = numerator;
            if (_numerator == 0)
                throw new ArgumentException("Числитель равен нулю", nameof(numerator));
            
            _denominator = denominator;
        }

        public static Fraction operator ++(Fraction frac)
        {
            return new Fraction(frac.Numerator * frac.Denominator, frac.Denominator);
        }

        public static Fraction operator --(Fraction frac)
        {
            return new Fraction(frac.Numerator * frac.Denominator, frac.Denominator);
        }

        public static Fraction operator -(Fraction frac)
        {
            return new Fraction(-frac._numerator, frac._denominator);
        }

        public static bool operator true(Fraction frac)
        {
            if (frac.Numerator != 0)
                return true;
            else return false;
        }
        public static bool operator false(Fraction frac)
        {
            if (frac.Numerator == 0)
                return true;
            else return false;
        }
    }
}
