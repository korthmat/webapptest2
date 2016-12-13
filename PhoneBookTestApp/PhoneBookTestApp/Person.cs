using System.Text;

namespace PhoneBookTestApp
{
    public class Person
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(Name);
            builder.AppendLine(Address);
            builder.AppendLine(PhoneNumber);

            return builder.ToString();
        }
    }
}