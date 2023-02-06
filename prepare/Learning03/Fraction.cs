using System;

namespace Learning03
{
    
    public class Fraction
    {
        private int _top;
        private int _bottom;

        public Fraction() 
        {
            this._top = 1;
            this._bottom = 1;
        }

        public Fraction(int wholeNumber)
        {
            this._top = wholeNumber;
            this._bottom = 1;
        }

        public Fraction(int top, int bottom)
        {
            this._top = top;
            this._bottom = bottom;
        }

        public int getTop()
        {
            return _top;
        }

        public int getBottom() 
        {
            return _bottom;
        }

        public void setTop(int top) {
            _top = top;
        }

        public void setBottom(int bottom) 
        {
            _bottom = bottom;
        }

        public string getFractionString()
        {
            return _top + "/" + _bottom;
        }

        public double getDecimalValue()
        {
            return Convert.ToDouble(_top) / Convert.ToDouble(_bottom);
        }
    }

}