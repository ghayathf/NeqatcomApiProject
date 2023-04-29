﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Neqatcom.Core.DTO
{
    public class RequestedLoan
    {
        public decimal Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string Categoryimage { get; set; }
        public decimal Lenderid { get; set; }
        public string Commercialregister { get; set; }
        public decimal? Lenderuserid { get; set; }
        public decimal? Registerstatus { get; set; }
        public decimal? Shadowstatus { get; set; }
        public string Companysize { get; set; }
        public string Siteurl { get; set; }
        public decimal? Warncounter { get; set; }
        public DateTime? Warndate { get; set; }
        public decimal Loanid { get; set; }
        public decimal? Totalmonths { get; set; }
        public decimal? Totalprice { get; set; }
        public decimal? Estimatedprice { get; set; }
        public decimal? Monthlyamount { get; set; }
        public decimal? Predayscounter { get; set; }
        public decimal? Latedayscounter { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public decimal? Offerid { get; set; }
        public decimal? Loaneeid { get; set; }
        public decimal? Loanstatus { get; set; }
        public decimal? Postponestatus { get; set; }
        public string Postponedate { get; set; }
        public string Nationalnumber { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Numoffamily { get; set; }
        public decimal? Creditscore { get; set; }
        public decimal? Loaneeuserid { get; set; }
        public decimal? Postponecounter { get; set; }
        public string Descriptions { get; set; }
        public decimal? Minmonth { get; set; }
        public decimal Userid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phonenum { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Userimage { get; set; }
    }
}
