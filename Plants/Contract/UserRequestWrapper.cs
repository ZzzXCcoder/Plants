using WebApplication1.Models;

public class UserRequestWrapper
{
    private readonly Account us;

    public UserRequestWrapper(Account us)
    {
        this.us = us;
    }

    public string Name => us.Name;

    public string Image => us.ImagePath;

    // Дополнительные свойства и методы...
}