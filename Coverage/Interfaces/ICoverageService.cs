using Coverage.Models;

namespace Coverage.Interfaces;

public interface ICoverageService
{
    Models.Coverage CreateCoverage(CoverageInfo coverageInfo);
    Models.Coverage GetCoverageById(string coverageId);
    Models.Coverage GetCoverageByCoverageNumber(string coverageNumber);
    List<Models.Coverage> GetCoveragesByName(string name);
    List<Models.Coverage> GetCoveragesByType(string type);
    List<Models.Coverage> GetCoveragesByExpiry(string expiry);
    List<Models.Coverage> GetCoveragesByEmail(string email);
    List<Models.Coverage> GetCoveragesByTelephone(string telephone);
    List<Models.Coverage> GetCoveragesByClientId(string clientId);
    Models.Coverage UpdateCoverageById(string coverageId, CoverageInfo coverageInfo);
    bool DeleteCoverageById(string coverageId);
    bool AssignCoverageToClient(string clientId, string coverageId);
    bool RemoveCoverageFromClient(string clientId, string coverageId);
}
