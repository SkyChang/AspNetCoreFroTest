namespace AspNetCoreFroTest.Web.Bll
{
    public interface ILoginBiz
    {
        bool Login(string userName, string pw);
    }
}