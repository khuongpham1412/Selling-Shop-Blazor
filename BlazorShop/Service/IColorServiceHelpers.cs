using BlazorShop.Entities;

namespace BlazorShop.Service
{
    public interface IColorServiceHelpers
    {
        ColorDB add(ColorDB colorDB);
        bool delete(string id);
        List<ColorDB> GetAllColor();
        ColorDB getColorFromId(string id);
        ColorDB update(ColorDB colorDB);
    }
}