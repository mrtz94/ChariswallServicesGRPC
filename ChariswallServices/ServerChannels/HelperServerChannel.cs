using Grpc.Net.Client;
using static HelperServer.DateConverter;

namespace ChariswallServices.ServerChannels
{
    public class HelperServerChannel : IHelperServerChannel
    {
        GrpcChannel _channel;
        DateConverterClient _client;
        public HelperServerChannel(IConfiguration configuration)
        {
            _channel = GrpcChannel.ForAddress(configuration["grpcServers:grpcHelper"]);
            _client = new DateConverterClient(_channel);
        }
        public DateConverterClient GetClient()
        { return _client; }
    }
}
