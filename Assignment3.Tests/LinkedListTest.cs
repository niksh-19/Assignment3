using Assignment3.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    [TestFixture]
    public class LinkedListTest
    {
        private SLL linkedList;

        [SetUp]
        public void Setup()
        {
            linkedList = new SLL();
        }

        [Test]
        public void TestEmptyLinkedList()
        {
            Assert.IsTrue(linkedList.IsEmpty());
        }

        [Test]
        public void TestPrepend()
        {
            User user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddFirst(user1);
            Assert.AreEqual(user1, linkedList.GetValue(0));
        }

        [Test]
        public void TestAppend()
        {
            User user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddLast(user1);
            Assert.AreEqual(user1, linkedList.GetValue(0));
        }

        [Test]
        public void TestInsertAtIndex()
        {
            User user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddFirst(user1);
            User user2 = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            linkedList.Add(user2, 1);
            Assert.AreEqual(user2, linkedList.GetValue(1));
        }

        [Test]
        public void TestReplace()
        {
            User user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddFirst(user1);
            User newUser = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            linkedList.Replace(newUser, 0);
            Assert.AreEqual(newUser, linkedList.GetValue(0));
        }

        [Test]
        public void TestDeleteFirst()
        {
            User user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddFirst(user1);
            linkedList.RemoveFirst();
            Assert.IsTrue(linkedList.IsEmpty());
        }

        [Test]
        public void TestDeleteLast()
        {
            User user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddFirst(user1);
            linkedList.RemoveLast();
            Assert.IsTrue(linkedList.IsEmpty());
        }

        [Test]
        public void TestDeleteMiddle()
        {
            User user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            User user2 = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            User user3 = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            User user4 = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            linkedList.AddFirst(user1);
            linkedList.AddLast(user2);
            linkedList.AddLast(user3);
            linkedList.AddLast(user4);
            linkedList.Remove(1);
            Assert.AreEqual(user3, linkedList.GetValue(1));
        }

        [Test]
        public void TestFindAndRetrieve()
        {
            User user1 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            linkedList.AddFirst(user1);
            Assert.AreEqual(0, linkedList.IndexOf(user1));
            Assert.AreEqual(user1, linkedList.GetValue(0));
        }

        [Test]
        public void TestReverse()
        {
            linkedList.AddFirst(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            linkedList.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            linkedList.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            linkedList.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
            linkedList.Reverse();
            Assert.AreEqual("Ronald McDonald", linkedList.GetValue(0).Name);
            Assert.AreEqual("Colonel Sanders", linkedList.GetValue(1).Name);
            Assert.AreEqual("Joe Schmoe", linkedList.GetValue(2).Name);
            Assert.AreEqual("Joe Blow", linkedList.GetValue(3).Name);
        }

        [Test]
        public void TestToArray()
        {
            linkedList.AddFirst(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            linkedList.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            linkedList.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            linkedList.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
            User[] array = linkedList.ToArray();
            Assert.AreEqual(4, array.Length);
            Assert.AreEqual("Joe Blow", array[0].Name);
            Assert.AreEqual("Joe Schmoe", array[1].Name);
            Assert.AreEqual("Colonel Sanders", array[2].Name);
            Assert.AreEqual("Ronald McDonald", array[3].Name);
        }
        [TearDown]
        public void TearDown()
        {
            this.linkedList.Clear();
        }
    }
}