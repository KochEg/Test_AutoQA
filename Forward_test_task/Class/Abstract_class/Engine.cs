using System.Runtime.InteropServices;

namespace Forward_test_task.Class
{
    public abstract class Engine
    {
        protected double _I;                         //Момент инерции двигателя (Н∙м)
        protected double _superheat_Temperature;     //Температура перегрева
        protected double _Hm;                     //Коэффициент зависимости скорости нагрева от крутящего момента
        protected double _Hv;                     //Коэффициент зависимости скорости нагрева от скорости вращения коленвала
        protected double _C;                      //Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды

        public Engine(double i, double superheat_Temperature, double hm, double hv, double c)
        {
            _I = i;
            _superheat_Temperature = superheat_Temperature;
            _Hm = hm;
            _Hv = hv;
            _C = c;
        }

        public double I{  get{ return _I; } }
        public double Superheat_Temperature { get { return _superheat_Temperature; } }
        public double Hm { get { return _Hm; } }
        public double Hv { get { return _Hv; } }
        public double C { get { return _C; } }




        public abstract double Vh();                                                       //Скорость нагрева двигателя
        public abstract double Vc(double ambbient_temperature, double engine_temperature); //Скорость охлаждения двигателя
        public abstract double N(double m, double v);                                      //Мощность двигателя
    }
}
