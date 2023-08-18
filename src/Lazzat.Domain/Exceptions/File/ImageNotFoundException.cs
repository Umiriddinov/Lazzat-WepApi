namespace Lazzat.Domain.Exceptions.File;

public class ImageNotFoundException : NotFoundException
{
    public ImageNotFoundException()
    {
        this.TitleMessage = "Image not found!"; ;

    }
}
