using System.ComponentModel.DataAnnotations;

namespace GalaxyApp.Share.ResponseBase.Paginations
{
    public enum ProductOrderEnum
    {
        //Id,
        //Name, NameDes,
        //Price, PriceDes,
        //Quantity, QuantityDes,
        //Discount, DiscountDes,
        //Evaluation, EvaluationDes

        [Display(Name = "Product ID")]
        Id,

        [Display(Name = "Product Name Ascending")]
        Name,

        [Display(Name = "Product Name Descending")]
        NameDes,

        [Display(Name = "Product Price Ascending")]
        Price,

        [Display(Name = "Product Price Descending")]
        PriceDes,

        [Display(Name = "Product Quantity Ascending")]
        Quantity,

        [Display(Name = "Product Quantity Descending")]
        QuantityDes,

        [Display(Name = "Product Discount Ascending")]
        Discount,

        [Display(Name = "Product Discount Descending")]
        DiscountDes,

        [Display(Name = "Product Evaluation Ascending")]
        Evaluation,

        [Display(Name = "Product Evaluation Descending")]
        EvaluationDes



    }
}
