using Forward_test_task.Class.Class_engine;
using System;

namespace Forward_test_task.Class
{
    public class Stand
    {
        private double engine_temperature;
        private double ambient_temperature;
        private int _number_of_M_and_V;
        private const double ABSOLUTE_ERROR = 10e-2;
        private const double MAX_TIME = 1800;

        public Stand() { }
        public Stand(double ambient_temperature)
        {
            _number_of_M_and_V = 0;
            dvs._M_ = dvs.GetM(_number_of_M_and_V);
            dvs._V_ = dvs.GetV(_number_of_M_and_V);
            this.engine_temperature = ambient_temperature;
            this.ambient_temperature = ambient_temperature;      
        }


        private Internal_Combustion_Engine dvs = new Internal_Combustion_Engine(0.1, 110, 0.01, 0.0001, 0.1);
        public int Test_Number_One()
        {
            double a = dvs._M_ * dvs.I;
            double eps = dvs.Superheat_Temperature - engine_temperature;
            int time = 0;
            while (eps > ABSOLUTE_ERROR && time < MAX_TIME)
            {
                time++;
                dvs._V_ += a;
                if (_number_of_M_and_V < dvs.GetCountM() - 2)
                    _number_of_M_and_V += dvs._V_ < dvs.GetV(_number_of_M_and_V + 1) ? 0 : 1;
                double up = (dvs._V_ - dvs.GetV(_number_of_M_and_V));
                double down = (dvs.GetV(_number_of_M_and_V + 1) - dvs.GetV(_number_of_M_and_V));
                double factor = (dvs.GetM(_number_of_M_and_V + 1) - dvs.GetM(_number_of_M_and_V));
                dvs._M_ = up / down * factor + dvs.GetM(_number_of_M_and_V);

                engine_temperature += dvs.Vc(ambient_temperature, engine_temperature) + dvs.Vh();

                a = dvs._M_ * dvs.I;

                eps = dvs.Superheat_Temperature - engine_temperature;
            }
            return time;
        }

        public void Show_Test_Number_One(int time)
        {
            if (time == MAX_TIME)
                Console.WriteLine("At this ambient temperature, the engine does not overheat");
            else
                Console.WriteLine($"The time from the start of the internal combustion engine to the moment of its overheating {time} sec.");
        }

        public void Test_Number_Two()
        {
            for (int i = 0; i < dvs.GetCountM(); i++)
            {
               double result_max_power = dvs.N((double)dvs.GetM(i), (double)dvs.GetV(i));
                Console.Write($"Max power engine: {result_max_power}kW");
                Console.WriteLine($"\t\tCrankshaft speed: {dvs.GetV(i)} radian/sec");
            }
        }
    }
}
