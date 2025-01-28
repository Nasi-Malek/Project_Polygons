using ClassLibrary.Models;


namespace ShapeApp
{
    public interface IShapeRepository
    {
        void SaveShape(string shapeName, string parameters, double area, double perimeter);
        List<ShapeRecord> GetAllShapes();
        bool UpdateShape(int id, string updatedParameters, double updatedArea, double updatedPerimeter);
        bool DeleteShape(int id);
        ShapeRecord? GetShapeById(int id);
    }

}
