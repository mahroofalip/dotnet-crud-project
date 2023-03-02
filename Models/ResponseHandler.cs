namespace api.Models
{
    public class ResponseHandler
    {
        public static ApiResponse GetExpceptionResponse(Exception ex)
        {
            ApiResponse response = new ApiResponse();
            response.Code = "1"; 
            response.Message = ex.Message;
            return response;
        }
        public static ApiResponse GetAppResponse(ResponseType type, object? contract)
        {
            ApiResponse response;
            response = new ApiResponse { ResponseData = contract };
            switch (type) { 
               case ResponseType.Success:
                    response.Code = "0";
                    response.Message = "Success";
                    break;
                case ResponseType.NotFound:
                    response.Code = "2";
                    response.Message = "No Records Avalable";
                    break;

            }
            return response;
        }
    }
}
