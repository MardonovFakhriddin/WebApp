namespace Infrastructure.Interfaces;
using Domain.Models;

public interface IBranch
{
    bool DeleteBranch(int id);
    bool UpdateBranch(Branch branch);
    bool InsertBranch(Branch branch);
    List<Branch> GetBranch();
    Branch GetBranchById(int id);
}