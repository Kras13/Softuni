using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Tuple<TFirst, TSecond, TThird>
    {
        public TFirst FirstElement { get; private set; }

        public TSecond SecondElement { get; private set; }

        public TThird ThirdElement { get; private set; }


        public Tuple(TFirst firstElement, TSecond secondElement, TThird thirdElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
            ThirdElement = thirdElement;
        }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement} -> {ThirdElement}";
        }
    }
}
