using Grpc.Core;
using GrpcService1;

namespace GrpcService1.Services
{
    public class DataTransferService : DataTransfer.DataTransferBase
    {
        private readonly ILogger<DataTransferService> _logger;

        public DataTransferService(ILogger<DataTransferService> logger)
        {
            _logger = logger;
        }

        public override Task<DataResponse> SendData(DataRequest request, ServerCallContext context)
        {
            try
            {
                // Обработка данных
                return Task.FromResult(new DataResponse { Message = "Data received" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in SendData");
                throw;
            }
        }
    }
}
