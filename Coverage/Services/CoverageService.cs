using Coverage.Interfaces;
using Coverage.Models;

namespace Coverage.Services;

public class CoverageService : ICoverageService
{
    public Models.Coverage CreateCoverage(CoverageInfo coverageInfo)
    {
        throw new NotImplementedException();
    }

    public Models.Coverage GetCoverageById(string coverageId)
    {
        throw new NotImplementedException();
    }

    public Models.Coverage GetCoverageByCoverageNumber(string coverageNumber)
    {
        throw new NotImplementedException();
    }

    public List<Models.Coverage> GetCoveragesByName(string name)
    {
        throw new NotImplementedException();
    }

    public List<Models.Coverage> GetCoveragesByType(string type)
    {
        throw new NotImplementedException();
    }

    public List<Models.Coverage> GetCoveragesByExpiry(string expiry)
    {
        throw new NotImplementedException();
    }

    public List<Models.Coverage> GetCoveragesByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public List<Models.Coverage> GetCoveragesByTelephone(string telephone)
    {
        throw new NotImplementedException();
    }

    public List<Models.Coverage> GetCoveragesByClientId(string clientId)
    {
        throw new NotImplementedException();
    }

    public Models.Coverage UpdateCoverageById(string coverageId, CoverageInfo coverageInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteCoverageById(string coverageId)
    {
        throw new NotImplementedException();
    }

    public bool AssignCoverageToClient(string clientId, string coverageId)
    {
        throw new NotImplementedException();
    }

    public bool RemoveCoverageFromClient(string clientId, string coverageId)
    {
        throw new NotImplementedException();
    }
}
