namespace TPBank.Entities
{
    public class ResponseResult<TData> where TData : class
    {
        public bool Success { get; set; }
        public TData Result { get; set; }
        public string ErrorMessage { get; set; }

        public ResponseResult()
        {
            Success = true;
        }

        public ResponseResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}