namespace EmergencyAlert.Core
{
    public class ApiResponseFactory
    {
        public static ApiResponse<T> SuccessResponse<T>(T data)
        {
            return new ApiResponse<T>
            {
                Data = data,
                Status = StatusCodes.Status200OK,
                Message = null
            };
        }

        public static ApiResponse<bool> BadRequestResponse(string message)
        {
            return new ApiResponse<bool>
            {
                Data = false,
                Status = StatusCodes.Status400BadRequest,
                Message = message
            };
        }

        public static ApiResponse<bool> NotFoundResponse(string message)
        {
            return new ApiResponse<bool>
            {
                Data = default,
                Status = StatusCodes.Status404NotFound,
                Message = message
            };
        }
        public static ApiResponse<bool> ConflictResponse(string message)
        {
            return new ApiResponse<bool>
            {
                Data = default,
                Status = StatusCodes.Status409Conflict,
                Message = message
            };
        }
    }
}
