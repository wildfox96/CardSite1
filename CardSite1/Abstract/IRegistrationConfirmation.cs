using CardSite1.Models;

namespace CardSite1.Abstract
{
    public interface IRegistrationConfirmation
    {
        void SendConfirmationLetter(RegistrationModel registration);
    }
}
