namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            Validator.CallingValidating(number, "Invalid number!");

            return $"Dialing... {number}";
        }
    }
}
