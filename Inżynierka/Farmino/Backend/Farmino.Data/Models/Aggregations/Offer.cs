using Farmino.Data.Enums;
using Farmino.Data.Exceptions;
using Farmino.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Farmino.Data.Models.Aggregations 
{
    public class Offer
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public double MinQuantity { get; protected set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeightUnits MinWeightUnit { get; protected set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Regions Region { get; protected set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Categories Category { get; protected set; }
        public Guid FarmerId { get; protected set; }
        public Farmer Farmer { get; protected set; }
        public Product Product { get; protected set; }
        public string ImageName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; } 
        public IEnumerable<Order> Orders { get; protected set; }
        public IEnumerable<Observed> Observeds { get; protected set; }

        protected Offer() { }

        public Offer(Farmer farmer, string title, string description, WeightUnits minWeightUnit, 
            Regions region, Categories category, double minQuantity, string imageName ,Product product) 
        {
            Id = Guid.NewGuid();
            SetFarmer(farmer);
            SetTitle(title);
            SetDescription(description);
            SetMinWeightUnit(minWeightUnit);
            SetMinQuantity(minQuantity);
            SetCategory(category);
            SetRegion(region);
            SetProduct(product);
            SetImageName(imageName);
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public void SetRegion(Regions region)
        {
            if ((int)region > 15 || (int)region < 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductWeightUnit,
                    "Invalid product weight unit");
            }

            Region = region;
        }

        public void SetCategory(Categories category)
        {
            if ((int)category > 5 || (int)category < 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductWeightUnit,
                    "Invalid product weight unit");
            }

            Category = category;
        }

        public void SetMinQuantity(double minQuantity)
        {
            if (minQuantity <= 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidMinQuantity,
                    "MinQuantity cannot be less or equal zero");
            }

            MinQuantity = minQuantity;
        }

        public void SetMinWeightUnit(WeightUnits minWeightUnit)
        { 
            if ((int)minWeightUnit > 4 || (int)minWeightUnit < 0)
            {
                throw new DataExceptions(DataErrorCodes.InvalidProductWeightUnit,
                    "Invalid product weight unit");
            }

            MinWeightUnit = minWeightUnit;
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

        public void SetImageName(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
            {
                throw new DataExceptions(DataErrorCodes.InvalidImageName,
                    "Image name cannot be empty");
            }
            if (ImageName == imageName)
            {
                return;
            }

            ImageName = imageName;
            UpdatedAt = DateTime.Now;
        }

        public void SetProduct(Product product)
        {
            Product = product;
            UpdatedAt = DateTime.Now;
        }

        public void SetFarmer(Farmer farmer)
        {
            Farmer = farmer;
            UpdatedAt = DateTime.Now;
        }
    }
}
