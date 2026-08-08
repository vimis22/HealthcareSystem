using Coverage.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataManager.Services.Coverage;

public class CoverageService : ICoverageService
{
    private readonly AppDbContext _db;

    public CoverageService(AppDbContext db)
    {
        _db = db;
    }

    public global::Coverage.Models.Coverage CreateCoverage(global::Coverage.Models.CoverageInfo coverageInfo)
    {
        var coverage = new global::Coverage.Models.Coverage
        {
            Id = Guid.NewGuid().ToString(),
            Name = coverageInfo.Name,
            Coveragenumber = coverageInfo.Coveragenumber,
            Type = coverageInfo.Type,
            Email = coverageInfo.Email,
            Telephone = coverageInfo.Telephone,
            Expiry = coverageInfo.Expiry
        };
        _db.Coverages.Add(coverage);
        _db.SaveChanges();
        return coverage;
    }

    public global::Coverage.Models.Coverage GetCoverageById(string coverageId)
    {
        return _db.Coverages.FirstOrDefault(c => c.Id == coverageId);
    }

    public global::Coverage.Models.Coverage GetCoverageByCoverageNumber(string coverageNumber)
    {
        return _db.Coverages.FirstOrDefault(c => c.Coveragenumber == coverageNumber);
    }

    public List<global::Coverage.Models.Coverage> GetCoveragesByName(string name)
    {
        return _db.Coverages.Where(c => c.Name == name).ToList();
    }

    public List<global::Coverage.Models.Coverage> GetCoveragesByType(string type)
    {
        return _db.Coverages.Where(c => c.Type == type).ToList();
    }

    public List<global::Coverage.Models.Coverage> GetCoveragesByExpiry(string expiry)
    {
        return _db.Coverages.Where(c => c.Expiry == expiry).ToList();
    }

    public List<global::Coverage.Models.Coverage> GetCoveragesByEmail(string email)
    {
        return _db.Coverages.Where(c => c.Email == email).ToList();
    }

    public List<global::Coverage.Models.Coverage> GetCoveragesByTelephone(string telephone)
    {
        return _db.Coverages.Where(c => c.Telephone == telephone).ToList();
    }

    public List<global::Coverage.Models.Coverage> GetCoveragesByClientId(string clientId)
    {
        var coverageIds = _db.Set<Dictionary<string, object>>("ClientCoverages")
            .Where(cc => EF.Property<string>(cc, "ClientId") == clientId)
            .Select(cc => EF.Property<string>(cc, "CoverageId"))
            .ToList();
        return _db.Coverages.Where(c => coverageIds.Contains(c.Id)).ToList();
    }

    public global::Coverage.Models.Coverage UpdateCoverageById(string coverageId, global::Coverage.Models.CoverageInfo coverageInfo)
    {
        var coverage = _db.Coverages.FirstOrDefault(c => c.Id == coverageId);
        if (coverage == null) return null;
        coverage.Name = coverageInfo.Name;
        coverage.Coveragenumber = coverageInfo.Coveragenumber;
        coverage.Type = coverageInfo.Type;
        coverage.Email = coverageInfo.Email;
        coverage.Telephone = coverageInfo.Telephone;
        coverage.Expiry = coverageInfo.Expiry;
        _db.SaveChanges();
        return coverage;
    }

    public bool DeleteCoverageById(string coverageId)
    {
        var coverage = _db.Coverages.FirstOrDefault(c => c.Id == coverageId);
        if (coverage == null) return false;
        _db.Coverages.Remove(coverage);
        _db.SaveChanges();
        return true;
    }

    public bool AssignCoverageToClient(string clientId, string coverageId)
    {
        var client = _db.Clients.FirstOrDefault(c => c.Id == clientId);
        var coverage = _db.Coverages.FirstOrDefault(c => c.Id == coverageId);
        if (client == null || coverage == null) return false;
        _db.Set<Dictionary<string, object>>("ClientCoverages").Add(new Dictionary<string, object>
        {
            { "ClientId", clientId },
            { "CoverageId", coverageId }
        });
        _db.SaveChanges();
        return true;
    }

    public bool RemoveCoverageFromClient(string clientId, string coverageId)
    {
        var entry = _db.Set<Dictionary<string, object>>("ClientCoverages")
            .FirstOrDefault(cc => EF.Property<string>(cc, "ClientId") == clientId && EF.Property<string>(cc, "CoverageId") == coverageId);
        if (entry == null) return false;
        _db.Set<Dictionary<string, object>>("ClientCoverages").Remove(entry);
        _db.SaveChanges();
        return true;
    }
}
