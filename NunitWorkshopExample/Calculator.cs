namespace NUnitWorkshopExample
{
    public class Calculator
    {
        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }

        public DivisionResult Divide(int dividend, int divisor)
        {
            int value = dividend / divisor;
            int rest = dividend % divisor;
            return new DivisionResult(value, rest);
        }
    }

    public class DivisionResult
    {
        public DivisionResult(int value, int rest)
        {
            Value = value;
            Rest = rest;
        }

        public int Value { get; }

        public int Rest { get; }
    }
}