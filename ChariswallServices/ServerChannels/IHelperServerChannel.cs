using static HelperServer.DateConverter;

namespace ChariswallServices.ServerChannels
{
    public interface IHelperServerChannel
    {
        DateConverterClient GetClient();
    }
}
