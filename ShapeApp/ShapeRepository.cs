using Microsoft.EntityFrameworkCore;
using ClassLibrary.Models;
using ClassLibrary.Data;


namespace ShapeApp
{
    public class ShapeRepository : IShapeRepository
    {
        private readonly AppDbContext _context;

        public ShapeRepository(AppDbContext context)
        {
            _context = context;
        }
        public void SaveShape(string shapeName, string parameters, double area, double perimeter)
        {
            var record = new ShapeRecord
            {
                ShapeName = shapeName,
                Parameters = parameters,
                Area = area,
                Perimeter = perimeter,
                CalculationDate = DateTime.Now
            };
            _context.ShapeRecords.Add(record);
            _context.SaveChanges();
        }

        public List<ShapeRecord> GetAllShapes()
        {
            return _context.ShapeRecords.ToList();
        }
        public bool UpdateShape(int id, string updatedParameters, double updatedArea, double updatedPerimeter)
        {
            var record = _context.ShapeRecords.Find(id);
            if (record == null) return false;

            record.Parameters = updatedParameters;
            record.Area = updatedArea;
            record.Perimeter = updatedPerimeter;

            _context.SaveChanges();
            return true;
        }
        public bool DeleteShape(int id)
        {
            var record = _context.ShapeRecords.Find(id);
            if (record == null) return false;

            record.IsDeleted = true; // Mark as soft deleted
            _context.SaveChanges();
            return true;
        }

        public ShapeRecord? GetShapeById(int id)
        {
            return _context.ShapeRecords.Find(id);
        }

        public bool RestoreShape(int id)
        {
            var record = _context.ShapeRecords
                .IgnoreQueryFilters()
                .FirstOrDefault(sr => sr.Id == id && sr.IsDeleted);
            if (record == null) return false;

            record.IsDeleted = false; // Unmark as deleted
            _context.SaveChanges();
            return true;
        }

    }
}

