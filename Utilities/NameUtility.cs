namespace ServiceCore.Utilities
{
    public class NameUtility
    {
        public static string GetFirstName(string FullName)
        {
            int index = FullName.LastIndexOf(' ');
            string firstName = FullName;
            if(index >= 0) {
                firstName = FullName.Substring(index + 1);
                string lastName = FullName.Substring(0, index);
            }            
            return firstName;
        }

        public static string GetLastName(string FullName)
        {
            int index = FullName.LastIndexOf(' ');
            string lastName = "";
            if(index >= 0) {
                lastName = FullName.Substring(0, index);
            }                        
            return lastName;
        }
        public static string GetMiddleName(string FullName)
        {
            int FirstIndex = FullName.IndexOf(' ');
            int LastIndex = FullName.LastIndexOf(' ');
            return FullName.Substring(FirstIndex + 1, LastIndex - FirstIndex);
        }
    }
}