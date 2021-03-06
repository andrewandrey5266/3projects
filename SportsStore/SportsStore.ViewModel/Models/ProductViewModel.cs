﻿using System;
using System.ComponentModel.DataAnnotations;
using SportsStore.Domain.Entities;
using System.Runtime.Serialization;
using System.Web.Mvc;
namespace SportsStore.ViewModel.Models
{
    [DataContract]
    public class ProductViewModel 
    {
        [DataMember]
        [HiddenInput(DisplayValue=false)]       
        public string Id { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [DataMember]        
        [Required(ErrorMessage = "Please enter a disctiption")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Please enter a price")]
        [Range(0.01, 999.00, ErrorMessage = "Please enter a positive price in range of [0.01, 999.00]")]
        public decimal Price { get; set; }

        public bool InStock { get; set; }

        [Required]
        public string CategoryName
        {
            get;
            set;
        }

        [Required]
        [Range(0, 100)]
        public int DiscountPercentage
        {
            get;set;
        }

        public ProductViewModel() { }

        public ProductViewModel(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Description = product.Description;
            this.Price = product.Price;
           this.DiscountPercentage = product.Discount.Percentage;
           this.InStock = product.InStock;
        }
    }
}
