namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.ServiceModel;

    public static class ICommunicationObjectExtensions
    {
        public static void SafeClose(this ICommunicationObject communicationObject)
        {
            try
            {
                if (communicationObject.State == CommunicationState.Faulted)
                    communicationObject.Abort();
                else if (communicationObject.State != CommunicationState.Closed)
                    communicationObject.Close();
            }
            catch (CommunicationException)
            {
                communicationObject.Abort();
            }
            catch (TimeoutException)
            {
                communicationObject.Abort();
            }
        }
    }
}