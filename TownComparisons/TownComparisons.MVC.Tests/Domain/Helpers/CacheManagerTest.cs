﻿using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TownComparisons.Domain.Helpers;

namespace TownComparisons.MVC.Tests.Domain.Helpers
{
    [TestClass]
    public class CacheManagerTest
    {
        private CacheManager _cacheManager;

        [TestInitialize]
        public void SetUp()
        {
            _cacheManager = new CacheManager();
        }


        /// <summary>
        /// Testing method SetCache(key, value, cacheitempolicy)
        /// 
        /// Sets value in cache and assert that the value exists. 
        /// </summary>
        [TestMethod]
        public void Test_SetCache_CheckHasValue()
        {
            string key = "SetCache";
            string value = "Testing";
            int cacheDuration = 30; //30 seconds

            _cacheManager.SetCache(key, value, cacheDuration);

            Assert.IsTrue(_cacheManager.HasValue(key));
        }

        /// <summary>
        /// Testing method SetCache(key, value, cacheitempolicy)
        /// 
        /// Sets value in cache and waits until expiration has passed, 
        /// then checks that cache not not contain this value
        /// 
        /// </summary>
        [TestMethod]
        public void Test_SetCache_CheckExpiration()
        {
            string key = "Expiration";
            string value = "TestingExpiration";
            int cacheDuration = 1;

            _cacheManager.SetCache(key, value, cacheDuration);
            //Waiting for cache policy to expire
            Thread.Sleep(1000);

            //Expiration has passed, key/value in cache no not exists
            Assert.IsFalse(_cacheManager.HasValue(key));
        }


        [TestMethod]
        public void Test_SetCache_CachePolicyDateTime()
        {
            string key = "ExpirationDateTime";
            string value = "TestingExpiration";
            
            _cacheManager.SetCache(key, value);

            Assert.IsTrue(_cacheManager.HasValue(key));
        }


        /// <summary>
        /// Get a value from cache
        /// </summary>
        [TestMethod]
        public void Test_GetCache_EvaluateCacheValue()
        {
            string key = "GetCache";
            string value = "CachedValue";

            _cacheManager.SetCache(key, value);

            string actual = _cacheManager.GetCache(key) as string;

            Assert.AreEqual(value, actual);
        }

        /// <summary>
        /// Deletes key/value from Cache
        /// </summary>
        [TestMethod]
        public void Test_RemoveFromCache()
        {
            string key = "RemoveCache";
            string value = "CachedValueToRemove";

            _cacheManager.SetCache(key, value);

            string actual = _cacheManager.GetCache(key) as string;

            Assert.AreEqual(value, actual);
            
            _cacheManager.RemoveFromCache(key);

            Assert.IsFalse(_cacheManager.HasValue(key));
        }

        /// <summary>
        /// Try to delete from cache with invalid key
        /// </summary>
        [TestMethod]
        public void Test_RemoveFromCache_UsingFaltyKeyName()
        {
            string key = "Remove";
            string value = "CachedValueToRemove";

            _cacheManager.SetCache(key, value);

            //Asure key does not exists
            Assert.IsFalse(_cacheManager.HasValue("ERROR"));

            //Trying to remove key that does not exist
            _cacheManager.RemoveFromCache("ERROR"); 
        }


    }
}
