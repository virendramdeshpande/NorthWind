namespace SOLID.Framwork
{
    public class Result<T>
    {
        public bool isSuccessful { get; set; }
        public Exception exception { get; set; }

        public T data { get; set; }

    }
}
