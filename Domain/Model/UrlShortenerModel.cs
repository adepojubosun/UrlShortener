using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Domain.Model
{
    public class UrlShortenerModel
    {
        public int Id {get;set;}
        [StringLength(50)]
        [Required]
        public string ShortUrl {get; set;}
        [StringLength(250)]
        [Required]
        public string LongUrl {get; set;}
        public DateTime CreatedDate {get; set;}
        public DateTime ExpiredDate {get; set;}
        [StringLength(9)]
        [Required]
        public string UniqueId {get; set;}
        public string UrlDescription {get; set;}
        [DefaultValue(0)]
        public int VisitCount {get; set;}
    }
    
}