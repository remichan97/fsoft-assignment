namespace TPBank.Entities
{
    public static class ValidExtension
    {
        private static bool IsPatternMatch(string test)
        {
            return test.Any(ch => char.IsUpper(ch)) && test.Any(it => char.IsLower(it)) && test.Any(x => char.IsNumber(x));
        }

        public static bool IsCustomerCodeValid(this long customerCode)
        {
            return customerCode > 0;
        }

        public static bool IsCustomerNameValid(this string customerName)
        {
            return !string.IsNullOrWhiteSpace(customerName) && customerName.Length < 40;
        }

        public static bool IsPhoneNumberLengthValid(this string phoneNumber)
        {
            return phoneNumber.Length == 10;
        }

        public static bool IsUsernameNull(this string username)
        {
            return string.IsNullOrWhiteSpace(username);
        }

        public static bool IsPasswordValid(this string password)
        {
            return password.Length >= 6 && IsPatternMatch(password);
        }
    }
}