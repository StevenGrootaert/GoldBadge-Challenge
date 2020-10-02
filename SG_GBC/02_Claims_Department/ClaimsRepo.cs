﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Department
{
    public class ClaimsRepo
    {
       // private List<Claim> _claimsList = new List<Claim>();
        private Queue<Claim> _claimsQueue = new Queue<Claim>();


        // ---- CRUD ----
        // Create
        public void AddClaimToQueue(Claim incident)
        {
            _claimsQueue.Enqueue(incident);
        }

        // Read
        public Queue<Claim> GetClaimQueue()
        {
            return _claimsQueue;
        }

        public Claim ViewNextClaim()
        {
            
            return _claimsQueue.Peek();
            //Console.WriteLine("next",_claimsQueue.Peek());
        }

        public void ProcessClaim()
        {
            _claimsQueue.Dequeue();
        }
        // Update
        public bool UpateClaimQueue(int claimID, Claim newClaimDetails)
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

        // public void deal with queue next or whatever
        //display (you an instance of the queue?) get claims methid all claims
        //peek see next queue on top
        // display item in queue add a cw that asks if they want to deal w/ the queue n/ means remove from queue. 

        // --- helper methods ---
        public Claim GetClaimByID(int claimID)
        {
            foreach (Claim claim in _claimsQueue)
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
