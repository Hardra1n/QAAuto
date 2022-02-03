namespace ModelNService.Service
{
    public static class AccountProvider
    {
        private static AccountReader _reader = new AccountReader();

        public static string GetUsername(string domainName) => _reader.GetValue(domainName, "username");

        public static string GetPassword(string domainName) => _reader.GetValue(domainName, "password");

        public static string GetEmail(string domainName) => _reader.GetValue(domainName, "email");
    }
}

