namespace ViewModels
{
    public class VMResponse
    {
        public VMResponse()
        {
            Success = true;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}