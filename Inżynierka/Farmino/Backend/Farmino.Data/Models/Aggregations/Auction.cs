using Farmino.Data.Exceptions;
using Farmino.Data.Models.Entities;
using System;
using System.Collections.Generic;

namespace Farmino.Data.Models.Aggregations
{
    public class Auction
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public decimal StartingPrice { get; protected set; }
        public Guid AuctionerId { get; protected set; }
        public Auctioner Auctioner { get; protected set; }
        public IEnumerable<ParticipantAuction> Participants { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; } 

        protected Auction() { }

        public Auction(string title, string description, DateTime startDate, DateTime endDate,
            decimal startingPrice, Auctioner auctioner)
        {
            Id = Guid.NewGuid();
            SetTitle(title);
            SetDescription(description);
            SetEndDate(endDate);
            SetStartDate(startDate);
            SetStartingPrice(startingPrice);
            Auctioner = auctioner;
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new DataExceptions(DataErrorCodes.InvalidTitle, 
                    "Title cannot be empty");
            }
            if (Title == title)
            {
                return;
            }

            Title = title;
            UpdatedAt = DateTime.Now;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DataExceptions(DataErrorCodes.InvalidDescription,
                    "Description cannot be empty");
            }
            if (Description == description)
            {
                return;
            }

            Description = description;
            UpdatedAt = DateTime.Now;
        }

        public void SetStartDate(DateTime startDate)
        {
            if (startDate < DateTime.Now)
            {
                throw new DataExceptions(DataErrorCodes.InvalidDate,
                    "StartDate is invalid, should be actual date or future date");
            }
            if (StartDate == startDate)
            {
                return;
            }

            StartDate = startDate;
            UpdatedAt = DateTime.Now;
        }

        public void SetEndDate(DateTime endDate)
        {
            if(endDate <= StartDate)
            {
                throw new DataExceptions(DataErrorCodes.InvalidDate,
                    "EndDate cannot be lesser than StartDate");
            }
            if (EndDate == endDate)
            {
                return;
            }

            EndDate = endDate;
            UpdatedAt = DateTime.Now;
        }

        public void SetStartingPrice(decimal startingPrice)
        {
            if (startingPrice <= decimal.Zero)
            {
                throw new DataExceptions(DataErrorCodes.InvalidStartingPrice,
                    "StartingPrice cannot be less or equal zero");
            }
            if (StartingPrice == startingPrice)
            {
                return;
            }

            StartingPrice = startingPrice;
            UpdatedAt = DateTime.Now;
        }
    }
}
