﻿using System.Collections.Generic;

namespace VerifyMeIntegration.Dtos.Response.EmploymentResponse
{
    public class EmploymentHistoryListVerificationResponse
    {
        public Pagination _pagination { get; set; }
        public string Status { get; set; }
        public List<Data> Data { get; set; }
    }

    public class Pagination
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public int total { get; set; }
    }







}
