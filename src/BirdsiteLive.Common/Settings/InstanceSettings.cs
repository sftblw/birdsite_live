namespace BirdsiteLive.Common.Settings
{
    public class InstanceSettings
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string AdminEmail { get; set; }
        public bool ResolveMentionsInProfiles { get; set; }
        public bool PublishReplies { get; set; }
        public int MaxUsersCapacity { get; set; }

        public string UnlistedTwitterAccounts { get; set; }

        public string TwitterDomain { get; set; }

        public string InfoBanner { get; set; }

        public string TwitterDomainLabel { get; set; }

        public bool ShowAboutInstanceOnProfiles { get; set; }

    }
}