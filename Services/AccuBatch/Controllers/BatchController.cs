﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccuBatch.Controllers
{
    [Produces("application/json")]
    [Route("Batch")]
    public class BatchController : Controller
    {
        // GET: Batch
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string core = String.Empty;
            string host = String.Empty;

            try
            {
                core = SampleWapper.Wapper.Add(1, 2).ToString();
            }
            catch (Exception ex)
            {
                core = "FAILED - " + ex.Message;
            }

            try
            {
                host = Dns.GetHostName() + " - ";
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress addr in localIPs)
                {
                    if (addr.AddressFamily == AddressFamily.InterNetwork)
                    {
                        host = addr + " ";
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return new string[] { "CppWapper: " + core, "HostIP: " + host };
        }

        // GET: Batch/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: Batch
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: Batch/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
