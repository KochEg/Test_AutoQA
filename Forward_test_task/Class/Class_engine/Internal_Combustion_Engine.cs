using System.Collections.Generic;


namespace Forward_test_task.Class.Class_engine
{
    public class Internal_Combustion_Engine : Engine
    {
        private List<int> M;                   //Кусочно-линейная зависимость крутящего момента
        private double _M;
        private List<int> V;                   //Скорость вращения коленвала (радиан/сек)
        private double _V;

        public Internal_Combustion_Engine(double i, double superheat_Temperature, double hm, double hv, double c) : base (i, superheat_Temperature, hm, hv, c)
        {
            M = new List<int>() { 20, 75, 100, 105, 75, 0 };
            V = new List<int>() { 0, 75, 150, 200, 250, 300 };
        }


        public int GetM(int index) { return M[index]; }
        public int GetV(int index) { return V[index]; }    
        public int GetCountM() { return M.Count; }

        public double _M_ { get { return _M; } set { _M = value; } }
        public double _V_ { get { return _V; } set { _V = value; } }

        public override double Vh()                      //Скорость нагрева двигателя
        {
            return _M * _Hm + _V * _V * _Hv;
        }

        public override double Vc(double ambbient_temperature, double engine_temperature) //Скорость охлаждения двигателя
        {
            return _C * (ambbient_temperature - engine_temperature);
        }

        public override double N(double m, double v)   //Мощность ДВС
        {
            return m * v / 1000;
        }
    }
}
