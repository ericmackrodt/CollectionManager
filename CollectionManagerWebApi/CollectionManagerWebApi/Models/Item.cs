using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace CollectionManagerBackend.Models
{
    public partial class Item
    {
        //private DateTimeWrapper dtw;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        public int? Year { get; set; }

        [StringLength(100)]
        public string Developer { get; set; }

        [StringLength(100)]
        public string Publisher { get; set; }

        [StringLength(100)]
        public string Manufacturer { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? DateAcquired
        //{
        //    get { return dtw; }
        //    set { dtw = value; }
        //}

        //[NotMapped]
        //public DateTimeOffset? DateAcquiredOffset
        //{
        //    get { return dtw; }
        //    set { dtw = value; }
        //}

        [StringLength(500)]
        public string YoutubeVideo { get; set; }

        public virtual ItemDescription Description { get; set; }

        public virtual ICollection<ItemImage> Images { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<ItemCharacteristic> Characteristics { get; set; }
    }

    //Temporary while Odata 4.0 doesn't support DateTime
    //Code from: http://stackoverflow.com/questions/25189557/how-to-get-web-api-odata-v4-to-use-datetime
    //public class DateTimeWrapper
    //{
    //    private readonly DateTime _dt;

    //    public static implicit operator DateTimeOffset(DateTimeWrapper p)
    //    {
    //        return DateTime.SpecifyKind(p._dt, DateTimeKind.Utc);
    //    }

    //    public static implicit operator DateTimeWrapper(DateTimeOffset dto)
    //    {
    //        return new DateTimeWrapper(dto.DateTime);
    //    }

    //    public static implicit operator DateTime(DateTimeWrapper dtr)
    //    {
    //        return dtr._dt;
    //    }

    //    public static implicit operator DateTimeWrapper(DateTime dt)
    //    {
    //        return new DateTimeWrapper(dt);
    //    }

    //    protected DateTimeWrapper(DateTime dt)
    //    {
    //        _dt = dt;
    //    }
    //}
}
