﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medo.Security.Cryptography.PasswordSafe;

namespace PasswordSafe.Test {
    [TestClass]
    public class RecordTests {

        [TestMethod]
        public void Record_New() {
            var field = new Record(RecordType.Title) { Text = "Test" };
            Assert.AreEqual("Test", field.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Record_New_WrongType() {
            var field = new Record(RecordType.Title) { Time = DateTime.Now };
        }


        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void Record_ReadOnly() {
            var doc = new Document();
            doc.Entries["Test"].Password = "Old";

            doc.IsReadOnly = true;
            doc.Entries[0].Records[RecordType.Password].Text = "New";
        }

    }
}
