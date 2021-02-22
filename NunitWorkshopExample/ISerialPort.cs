namespace NUnitWorkshopExample
{
    public interface ISerialPort
    {
        void Open();

        void WriteLine(string sendData);

        string ReadLine();
    }
}