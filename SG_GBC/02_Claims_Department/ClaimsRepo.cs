using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Department
{
    public class ClaimsRepo
    {
        private List<Claim> _claimsList = new List<Claim>();

        // ---- CRUD ----
        // Create
        public void AddClaimToList(Claim incident)
        {
            _claimsList.Add(incident);
        }

        // Read
        public List<Claim> GetClaimList()
        {
            return _claimsList;
        }

        // Update
        public bool UpateClaimList(int claimID, Claim newClaimDetails)
        {
            Claim existingClaimDetails = GetClaimByID(claimID);
            if(existingClaimDetails != null)
            {
                existingClaimDetails.ClaimID = newClaimDetails.ClaimID;
                existingClaimDetails.TypeOfClaim = newClaimDetails.TypeOfClaim;
                existingClaimDetails.Description = newClaimDetails.Description;
                existingClaimDetails.ClaimAmount = newClaimDetails.ClaimAmount;
                existingClaimDetails.DateOfIncident = newClaimDetails.DateOfIncident;
                existingClaimDetails.DateOfClaim = newClaimDetails.DateOfClaim;
                existingClaimDetails.IsValid = newClaimDetails.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete (not sure we ever want to delete a claim so I'm not going to write this method)

        // --- helper methods ---
        public Claim GetClaimByID(int claimID)
        {
            foreach (Claim claim in _claimsList)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
