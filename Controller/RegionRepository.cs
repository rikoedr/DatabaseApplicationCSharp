namespace DBApp;

public class RegionRepository : Repository<Region>
{
    public RegionRepository()
    {
        base.tableName = "regions";
        base.tableEntity = new Region();
    }

    public override List<Region> GetAll()
    {
        return base.GetAll();
    }

    public override Region GetById<U>(U id)
    {
        return base.GetById(id);
    }
}
