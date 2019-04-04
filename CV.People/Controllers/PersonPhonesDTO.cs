namespace CV.People.Controllers
{
    public class PersonPhonesDTO
    {
        public int PersonPhoneId { get; set; }
        public int PersonId { get; set; }
        public string PhoneNumer { get; internal set; }
        public byte PhoneTypeId { get; internal set; }
        public string PhoneType
        {
            get
            {
                return ((PhoneType)PhoneTypeId).ToString();
            }
        }

        public bool IsDefault { get; internal set; }
    }

    public enum PhoneType
    {
        Home = 1,
        CellPhone = 2,
        Work = 3
    }
}