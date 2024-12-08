using Dapper;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Services;
using Infrastructure.Interfaces;

public class BranchService : IBranch
{
    private readonly DapperContext context;

    public BranchService()
    {
        context = new DapperContext();
    }
    public bool DeleteBranch(int id)
    {
        try
        {
            string cmd = "Delete from Branch where id = @id";
            var deleted = context.Connection.Execute(cmd);
            return deleted > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool UpdateBranch(Branch branch)
    {
        try
        {
            string cmd =
                "Update Branch set branch_name=@branch_name, company_id=@company_id, branch_address=@branch_address ";
            var updated = context.Connection.Execute(cmd);
            return updated > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool InsertBranch(Branch branch)
    {
        try
        {
            string cmd = "Insert into Branch (branch_name, company_id, branch_address) " +
                         "values(@branch_name,@company_id,@branch_address) ";
            var inserted = context.Connection.Execute(cmd, branch);
            return (inserted > 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public List<Branch> GetBranch()
    {
        try
        {
            string cmd = "Select Branch from Branch";
            List<Branch> branches = context.Connection.Query<Branch>(cmd).ToList();
            return branches;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Branch GetBranchById(int id)
    {
        string cmd = "Select * from Branch where branch_id = @branch_id";
        Branch branches = context.Connection.QuerySingleOrDefault<Branch>(cmd, new { Branch_id = id });
        return branches;
    }
}