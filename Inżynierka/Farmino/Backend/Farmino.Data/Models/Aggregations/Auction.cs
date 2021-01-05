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
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception("Title cannot be empty");
            }
            if (Title == title)
            {
                return;
            }

            Title = title;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exception("Description cannot be empty");
            }
            if (Description == description)
            {
                return;
            }

            Description = description;
        }

        public void SetStartDate(DateTime startDate)
        {
            if (startDate >= EndDate)
            {
                throw new DataExceptions("");
            }

            StartDate = startDate;
        }

        public void SetEndDate(DateTime endDate)
        {
            if(endDate <= StartDate)
            {
                throw new DataExceptions("");
            }

            EndDate = endDate;
        }

        public void SetStartingPrice(decimal startingPrice)
        {
            if(startingPrice <= decimal.Zero)
            {
                throw new DataExceptions("");
            }

            StartingPrice = startingPrice;
        }
    }
}
