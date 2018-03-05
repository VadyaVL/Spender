namespace Spender.Services
{
    public interface ISettingService
    {
        bool IsFirstApplicationRun { get; set; }

        bool IsDefaultCategoryInit { get; set; }

        string LocalizationCode { get; set; }
    }
}