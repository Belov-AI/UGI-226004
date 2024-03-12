using System;

namespace AngleStruct
{
    public struct Angle
    {
        const int maxValue = 59;
        const int secondsInMinute = 60;
        const int secondsInDegree = 3600;

        public int Degrees { get; set; }

        int minutes;
        public int Minutes
        {
            get => minutes;
            set
            {
                if (value < 0 || value > maxValue)
                    throw new ArgumentException("Значение должно быть неотрицательным и не более 59");

                minutes = value;
            }
        }

        int seconds;
        public int Seconds
        {
            get => seconds;
            set
            {
                if (value < 0 || value > maxValue) 
                    throw new ArgumentException("Значение должно быть неотрицательным и не более 59");
                
                seconds = value;
            }
        }

        public int ValueInSeconds 
        {
            get => Math.Sign(Degrees) * (Math.Abs(Degrees) * secondsInDegree +
                Minutes * secondsInMinute + Seconds);
        }

        public Angle(int degrees, int minutes, int seconds) : this()
        {
            Degrees = degrees;
            Minutes = minutes;
            Seconds = seconds;
        }

        public override string ToString() => $"{Degrees}°{Minutes}'{Seconds}\"";

        public override bool Equals(object obj)
        {
            if (obj is Angle)
                return ValueInSeconds == ((Angle)obj).ValueInSeconds;

            throw new ArgumentException("Объект для сравнения не является углом");
        }

        public override int GetHashCode() => ValueInSeconds.GetHashCode(); 

        public static bool operator ==(Angle x, Angle y) => x.Equals(y);
        public static bool operator !=(Angle x, Angle y) => !x.Equals(y);

        public static Angle operator +(Angle x, Angle y) => 
            GetAngleByValueInseconds(x.ValueInSeconds + y.ValueInSeconds);

        public static Angle operator *(double k, Angle angle) =>
            GetAngleByValueInseconds((int)Math.Round(k * angle.ValueInSeconds));

        public static Angle operator *(Angle angle, double k) => k * angle;

        private static Angle GetAngleByValueInseconds(int val)
        {
            int seconds = Math.Abs(val);
            int degrees = Math.Sign(val) * (seconds / secondsInDegree);
            seconds %= secondsInDegree;
            int minutes = seconds / secondsInMinute;
            seconds %= secondsInMinute;

            return new Angle(degrees, minutes, seconds);
        }      
    }
}
