namespace BlitzFiles.Models
{
    public class CRUDResult<T> where T : IDTO
    {
        public T? DTO { get; set; }
        public OperationResult Result { get; set; }

        public CRUDResult()
        {
            Result = OperationResult.ERROR;
        }

        public CRUDResult(T dto)
        {
            DTO = dto;
            Result = OperationResult.OK;
        }
    }
}
